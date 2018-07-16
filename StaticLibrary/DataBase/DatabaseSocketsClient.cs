using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using WBPlatform.StaticClasses;

namespace WBPlatform.Database.Connection
{
    public static class DatabaseSocketsClient
    {
        //创建 1个客户端套接字 和1个负责监听服务端请求的线程  
        private static Thread threadclient = null;
        private static Thread DataBaseConnectionMaintainer = new Thread(new ThreadStart(Maintain));
        private static TcpClient socketclient = new TcpClient();
        private static NetworkStream stream;

        private static string Message { get; set; } = "";
        public static bool Connected { get { return socketclient.Connected; } }

        private static Dictionary<string, string> _messages { get; set; } = new Dictionary<string, string>();
        public static bool Initialise(IPAddress ServerIP)
        {
            socketclient = new TcpClient();
            IPEndPoint point = new IPEndPoint(ServerIP, 8098);
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    socketclient.Connect(point);
                    stream = socketclient.GetStream();
                    LW.D("\tDatabase Connection Estabilished!");
                    break;
                }
                catch (Exception ex)
                {
                    LW.E("\t\tDatabase connection to server: " + ServerIP + " failed. " + ex.Message);
                    Thread.Sleep(1000);
                }
                if (i == 5)
                {
                    return false;
                }
            }

            threadclient = new Thread(Recv) { IsBackground = true };
            threadclient.Start();
            return true;
        }

        // 接收服务端发来信息的方法    
        static void Recv()
        {
            byte[] arrRecvmsg = new byte[1024 * 1024];
            while (true)
            {
                try
                {
                    string requestString = PublicTools.DecodeMessage(stream);
                    _messages.Add(requestString.Substring(0, 5), requestString.Substring(5));
                    arrRecvmsg = null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("远程服务器已经中断连接" + ex.Message + "\r\n\r\n");
                    break;
                }
            }
        }

        private static void Maintain()
        {
            while (true)
            {
                Thread.Sleep(2000);
            }
        }

        //发送字符信息到服务端的方法
        public static bool SendDatabaseOperations(string sendMsg, string MessageId, out string rcvdMessage)
        {
            rcvdMessage = "";
            if (Connected)
            {
                byte[] mergedPackage = PublicTools.EncodeMessage(MessageId, sendMsg);
                stream.Write(mergedPackage, 0, mergedPackage.Length);
                while (true)
                {
                    if (_messages.ContainsKey(MessageId))
                    {
                        rcvdMessage = _messages[MessageId];
                        _messages.Remove(MessageId);
                        return true;
                    }
                    Thread.Sleep(10);
                }
            }
            else return false;
        }
    }
}
