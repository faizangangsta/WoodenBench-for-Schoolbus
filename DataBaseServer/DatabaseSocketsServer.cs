using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using WBPlatform.StaticClasses;

namespace WBPlatform.Database.DBServer
{
    public class DatabaseSocketsServer
    {
        static Socket socketwatch = null;
        //定义一个集合，存储客户端信息
        static Dictionary<string, Socket> clientConnectionItems { get; set; } = new Dictionary<string, Socket>();
        public static Dictionary<string, string> clientQueryStrings { get; set; } = new Dictionary<string, string>();
        public static void InitialiseSockets()
        {
            socketwatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint point = new IPEndPoint(IPAddress.Any, 8098);
            socketwatch.Bind(point);
            socketwatch.Listen(20);

            //负责监听客户端的线程:创建一个监听线程  
            Thread threadwatch = new Thread(WatchConnecting) { IsBackground = true };
            threadwatch.Start();
        }

        //监听客户端发来的请求  
        private static void WatchConnecting()
        {
            Socket connection = null;

            while (true)
            {
                try
                {
                    connection = socketwatch.Accept();
                }
                catch (Exception ex)
                {
                    LW.E(ex.Message);
                    continue;
                }

                //获取客户端的IP和端口号
                IPAddress clientIP = (connection.RemoteEndPoint as IPEndPoint).Address;
                int clientPort = (connection.RemoteEndPoint as IPEndPoint).Port;

                //客户端网络结点号
                string remoteEndPoint = connection.RemoteEndPoint.ToString();
                //显示与客户端连接情况
                LW.D("Socceed Connected to " + remoteEndPoint);
                //添加客户端信息  
                clientConnectionItems.Add(remoteEndPoint, connection);

                IPEndPoint netpoint = connection.RemoteEndPoint as IPEndPoint;

                //创建一个通信线程
                ParameterizedThreadStart pts = new ParameterizedThreadStart(Recv);
                Thread thread = new Thread(pts)
                {
                    //设置为后台线程，随着主线程退出而退出
                    IsBackground = true
                };
                //启动线程
                thread.Start(connection);
            }
        }

        private static void Recv(object socketclientpara)
        {
            Socket baseSocket = socketclientpara as Socket;
            NetworkStream stream = new NetworkStream(baseSocket);
            string remoteEP = baseSocket.RemoteEndPoint.ToString();

            while (true)
            {
                string _MessageId = "";
                try
                {
                    string requestString = PublicTools.DecodeMessage(stream);

                    _MessageId = requestString.Substring(0, 5);
                    requestString = requestString.Substring(5);

                    if (clientQueryStrings.ContainsKey(remoteEP))
                    {
                        clientQueryStrings[remoteEP] = requestString;
                    }
                    else
                    {
                        clientQueryStrings.Add(remoteEP, requestString);
                    }

                    if (requestString == "openConnection")
                    {
                        LW.D("C: Recieve an OpenConnection Request, from " + remoteEP);
                        byte[] arrSendMsg = PublicTools.EncodeMessage(_MessageId, remoteEP);
                        stream.Write(arrSendMsg, 0, arrSendMsg.Length);
                        LW.D("C: Replied an OpenConnection Request, to " + remoteEP);
                    }
                    else if (requestString == "HeartBeat")
                    {
                        LW.D("B: Recieve a HearBeat, from " + remoteEP);
                        DateTime senttime = DateTime.Parse(requestString.Substring(9));
                        DateTime replyTime = DateTime.Now;
                        byte[] arrSendMsg = PublicTools.EncodeMessage(_MessageId, replyTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        stream.Write(arrSendMsg, 0, arrSendMsg.Length);
                        LW.D("C: Replied a HearBeat, to " + remoteEP);
                    }
                    else
                    {
                        LW.D("Q: " + remoteEP + " :: " + requestString);
                        //Main Entry........
                        string returnStr = DatabaseCore.ProcessRequest(requestString);
                        byte[] arrSendMsg = PublicTools.EncodeMessage(_MessageId, returnStr);
                        stream.Write(arrSendMsg, 0, arrSendMsg.Length);
                        LW.D("P: " + remoteEP + " :: " + returnStr);
                    }
                }
                catch (SocketException ex)
                {
                    LW.D("Client Count:" + clientConnectionItems.Count);
                    LW.E("Client " + remoteEP + " drops the connection. " + "\r\n" + ex.Message + "\r\n" + ex.StackTrace + "\r\n");

                    clientConnectionItems.Remove(remoteEP);
                    clientQueryStrings.Remove(remoteEP);
                    baseSocket.Disconnect(true);
                    baseSocket.Close();
                    baseSocket.Dispose();
                    baseSocket = null;
                    break;
                }
                catch (Exception ex)
                {
                    LW.D("Exception Occured! " + ex.Message);
                    byte[] arrSendMsg = PublicTools.EncodeMessage(_MessageId, "Exception " + ex.Message);
                    stream.Write(arrSendMsg, 0, arrSendMsg.Length);
                }
            }
            LW.E("A Socket Recieve Thread Stoped! ");
        }

    }
}
