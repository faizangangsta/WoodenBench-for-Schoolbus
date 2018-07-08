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
                    LogWritter.ErrorMessage(ex.Message);
                    continue;
                }

                //获取客户端的IP和端口号  
                IPAddress clientIP = (connection.RemoteEndPoint as IPEndPoint).Address;
                int clientPort = (connection.RemoteEndPoint as IPEndPoint).Port;

                //客户端网络结点号  
                string remoteEndPoint = connection.RemoteEndPoint.ToString();
                //显示与客户端连接情况
                LogWritter.DebugMessage("成功与" + remoteEndPoint + "客户端建立连接!");
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
            Socket socket = socketclientpara as Socket;
            byte[] arrServerRecMsg;

            while (true)
            {
                string _MessageId = "";
                try
                {
                    arrServerRecMsg = new byte[1024 * 1024];
                    int length = socket.Receive(arrServerRecMsg);
                    string requestString = Encoding.UTF8.GetString(arrServerRecMsg, 0, length);
                    arrServerRecMsg = null;

                    _MessageId = requestString.Substring(0, 5);
                    requestString = requestString.Substring(5);

                    if (clientQueryStrings.ContainsKey(socket.RemoteEndPoint.ToString()))
                    {
                        clientQueryStrings[socket.RemoteEndPoint.ToString()] = requestString;
                    }
                    else
                    {
                        clientQueryStrings.Add(socket.RemoteEndPoint.ToString(), requestString);
                    }

                    if (requestString == "openConnection")
                    {
                        LogWritter.DebugMessage("C: Recieve an OpenConnection Request, from " + socket.RemoteEndPoint.ToString());
                        byte[] arrSendMsg = Encoding.UTF8.GetBytes(_MessageId + socket.RemoteEndPoint.ToString());
                        socket.Send(arrSendMsg);
                        LogWritter.DebugMessage("C: Replied an OpenConnection Request, to " + socket.RemoteEndPoint.ToString());
                    }
                    else if (requestString == "HeartBeat")
                    {
                        LogWritter.DebugMessage("B: Recieve a HearBeat, from " + socket.RemoteEndPoint.ToString());
                        DateTime senttime = DateTime.Parse(requestString.Substring(9));
                        DateTime replyTime = DateTime.Now;
                        byte[] arrSendMsg = Encoding.UTF8.GetBytes(_MessageId + replyTime.ToString());
                        socket.Send(arrSendMsg);
                        LogWritter.DebugMessage("C: Replied a HearBeat, to " + socket.RemoteEndPoint.ToString());
                    }
                    else
                    {
                        LogWritter.DebugMessage("Q: " + socket.RemoteEndPoint.ToString() + " :: " + requestString);
                        //Main Entry........
                        string returnStr = DatabaseCore.ProcessRequest(requestString);
                        socket.Send(Encoding.UTF8.GetBytes(_MessageId + returnStr));
                        LogWritter.DebugMessage("P: " + socket.RemoteEndPoint.ToString() + " :: " + returnStr);
                    }
                }
                catch (SocketException ex)
                {
                    LogWritter.DebugMessage("Client Count:" + clientConnectionItems.Count);
                    LogWritter.ErrorMessage("Client " + socket.RemoteEndPoint + " Cuts down the connection. " + "\r\n" + ex.Message + "\r\n" + ex.StackTrace + "\r\n");
                  
                    clientConnectionItems.Remove(socket.RemoteEndPoint.ToString());
                    clientQueryStrings.Remove(socket.RemoteEndPoint.ToString());
                    socket.Disconnect(true);
                    socket.Close();
                    socket.Dispose();
                    socket = null;
                    break;
                }
                catch (Exception ex)
                {
                    LogWritter.DebugMessage("Exception Occured! " + ex.Message);
                    socket.Send(Encoding.UTF8.GetBytes(_MessageId + "Exception " + ex.Message));
                }
            }
            LogWritter.ErrorMessage("A Socket Recieve Thread Stoped! " + socket.RemoteEndPoint.ToString());
        }
    }
}
