using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using WBPlatform.Database.Internal;
using WBPlatform.StaticClasses;

namespace WBPlatform.Database.DBServer
{
    public class DatabaseSocketsServer
    {
        static Socket socketwatch = null;
        //定义一个集合，存储客户端信息
        //static Dictionary<string, Socket> clientConnectionItems { get; set; } = new Dictionary<string, Socket>();
        public static AutoDictionary<string, string> QueryStrings { get; set; } = new Dictionary<string, string>();
        public static void InitialiseSockets()
        {
            socketwatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint point = new IPEndPoint(IPAddress.Any, 8098);
            socketwatch.Bind(point);
            socketwatch.Listen(20);

            //负责监听客户端的线程:创建一个监听线程  
            Thread threadwatch = new Thread(WatchConnecting) { IsBackground = true };
            threadwatch.Name = "DBServer Connection Watching Thread";
            threadwatch.Start();
        }

        //监听客户端发来的请求  
        private static void WatchConnecting()
        {
            while (true)
            {
                Socket connection = null;
                try
                {
                    connection = socketwatch.Accept();
                }
                catch (Exception ex)
                {
                    LW.E(ex.Message);
                    continue;
                }

                string remoteEndPoint = connection.RemoteEndPoint.ToString();
                LW.D("Estalished a connection with " + remoteEndPoint);

                Thread thread = new Thread(new ParameterizedThreadStart(Recv))
                {
                    IsBackground = true,
                    Name = remoteEndPoint + " Worker Thread"
                };
                thread.Start(connection);
            }
        }

        private static void Recv(object socketclientpara)
        {
            Socket baseSocket = socketclientpara as Socket;
            NetworkStream stream = new NetworkStream(baseSocket);
            string remoteEP = baseSocket.RemoteEndPoint.ToString();
            bool _connectionOpened = false;
            while (true)
            {
                try
                {
                    string requestString = PublicTools.DecodeMessage(stream);
                    LW.D("Recived Data: " + requestString);
                    if (requestString.Length <= 5)
                    {
                        baseSocket.CloseAndDispose();
                        break;
                    }
                    string _MessageId = requestString.Substring(0, 5);
                    requestString = requestString.Substring(5);

                    QueryStrings[remoteEP] = requestString;

                    if (requestString == "openConnection")
                    {
                        LW.D("C: Recieve an OpenConnection Request, from " + remoteEP);
                        byte[] arrSendMsg = PublicTools.EncodeMessage(_MessageId, remoteEP);
                        stream.Write(arrSendMsg, 0, arrSendMsg.Length);
                        stream.Flush();
                        LW.D("C: Replied an OpenConnection Request, to " + remoteEP);
                        _connectionOpened = true;
                    }
                    else if (_connectionOpened)
                    {
                        if (requestString == "HeartBeat")
                        {
                            LW.D("B: Recieve a HearBeat, from " + remoteEP);
                            DateTime rtime = DateTime.Now;
                            byte[] arrSendMsg = PublicTools.EncodeMessage(_MessageId, rtime.ToNormalString());
                            stream.Write(arrSendMsg, 0, arrSendMsg.Length);
                            stream.Flush();
                            LW.D("C: Replied a HearBeat, to " + remoteEP);
                        }
                        else if (DBInternalRequest.FromJSONString(requestString, out var request))
                        {
                            LW.D("Q: " + remoteEP + " :: " + requestString);
                            //It takes Time.....
                            string returnStr = DatabaseCore.ProcessRequest(request);
                            byte[] arrSendMsg = PublicTools.EncodeMessage(_MessageId, returnStr);
                            stream.Write(arrSendMsg, 0, arrSendMsg.Length);
                            stream.Flush();
                            LW.D("P: " + remoteEP + " :: " + returnStr);
                        }
                        else
                        {
                            //Invalid Connection......
                            LW.D("E: " + remoteEP + " :: JSON Parse Exception!");
                            baseSocket.CloseAndDispose();
                            QueryStrings.Remove(remoteEP);
                            break;
                        }
                    }
                    else
                    {
                        LW.E("Connection to " + remoteEP + " is not marked as 'Opened'");
                        baseSocket.CloseAndDispose();
                        QueryStrings.Remove(remoteEP);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    LW.E("Client " + remoteEP + " drops the connection. " + "\r\n" + ex.Message + "\r\n" + ex.StackTrace + "\r\n");
                    QueryStrings.Remove(remoteEP);
                    baseSocket.CloseAndDispose();
                    break;
                }
            }
            QueryStrings.Remove(remoteEP);
            LW.E("A Socket Recieve Thread Stoped! ");
        }
    }
}
