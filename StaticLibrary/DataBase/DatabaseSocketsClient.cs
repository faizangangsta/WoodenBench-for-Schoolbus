using System;
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
        private static Socket socketclient = null;

        private static string Message { get; set; } = "";
        private static bool Received { get; set; } = false;
        private static bool Read { get; set; } = false;
        private static bool Connected { get; set; } = false;
        public static bool Initialise(IPAddress ServerIP)
        {
            socketclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint point = new IPEndPoint(ServerIP, 8098);
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    socketclient.Connect(point);
                    Connected = true;
                    break;
                }
                catch (Exception ex)
                {
                    LogWritter.ErrorMessage("Database connection to server: " + ServerIP + " failed. " + ex.Message);
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
                    arrRecvmsg = new byte[1024 * 1024];
                    //定义一个1M的内存缓冲区，用于临时性存储接收到的消息  
                    int length = socketclient.Receive(arrRecvmsg);
                    string strRevMsg = Encoding.UTF8.GetString(arrRecvmsg, 0, length);
                    Message = strRevMsg;
                    Received = true;
                    while (!Read)
                    {
                        Thread.Sleep(100);
                    }
                    Read = false;
                    Received = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("远程服务器已经中断连接" + ex.Message + "\r\n\n");
                    Connected = false;
                    break;
                }
            }
        }


        //发送字符信息到服务端的方法  
        public static bool SendDatabaseOperations(string sendMsg, out string rcvdMessage)
        {
            rcvdMessage = "";
            if (Connected)
            {
                byte[] arrClientSendMsg = Encoding.UTF8.GetBytes(sendMsg);
                socketclient.Send(arrClientSendMsg);
                while (!Received)
                {
                    //WAIT FOR RCVD....
                    Thread.Sleep(50);
                }
                rcvdMessage = Message;
                Received = false;
                Read = true;
                return true;
            }
            else return false;
        }
    }
}
