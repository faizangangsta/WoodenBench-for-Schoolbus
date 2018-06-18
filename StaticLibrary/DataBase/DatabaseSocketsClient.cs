using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WBPlatform.Databases.DataBaseCore
{
    public static class DatabaseSocketsClient
    {
        //创建 1个客户端套接字 和1个负责监听服务端请求的线程  
        private static Thread threadclient = null;
        private static Socket socketclient = null;


        public static void Initialise()
        {
            //定义一个套接字监听  
            socketclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //获取文本框中的IP地址  
            IPAddress address = IPAddress.Parse("127.0.0.1");

            //将获取的IP地址和端口号绑定在网络节点上  
            IPEndPoint point = new IPEndPoint(address, 8098);

            try
            {
                //客户端套接字连接到网络节点上，用的是Connect  
                socketclient.Connect(point);
            }
            catch (Exception)
            {
                Console.WriteLine("连接失败\r\n");
                return;
            }

            threadclient = new Thread(Recv) { IsBackground = true };
            threadclient.Start();
        }

        // 接收服务端发来信息的方法    
        static void Recv()
        {
            int x = 0;
            //持续监听服务端发来的消息 
            while (true)
            {
                try
                {
                    //定义一个1M的内存缓冲区，用于临时性存储接收到的消息  
                    byte[] arrRecvmsg = new byte[1024 * 1024];

                    //将客户端套接字接收到的数据存入内存缓冲区，并获取长度  
                    int length = socketclient.Receive(arrRecvmsg);

                    //将套接字获取到的字符数组转换为人可以看懂的字符串  
                    string strRevMsg = Encoding.UTF8.GetString(arrRecvmsg, 0, length);
                    if (x == 1)
                    {
                        Console.WriteLine("服务器:" + DateTime.Now + "\r\n" + strRevMsg + "\r\n\n");
                    }
                    else
                    {
                        Console.WriteLine(strRevMsg + "\r\n\n");
                        x = 1;
                        ClientSendMsg("TEST");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("远程服务器已经中断连接" + ex.Message + "\r\n\n");
                    break;
                }
            }
        }


        //发送字符信息到服务端的方法  
        static void ClientSendMsg(string sendMsg)
        {
            //将输入的内容字符串转换为机器可以识别的字节数组     
            byte[] arrClientSendMsg = Encoding.UTF8.GetBytes(sendMsg);
            //调用客户端套接字发送字节数组     
            socketclient.Send(arrClientSendMsg);
            //将发送的信息追加到聊天内容文本框中     
            Debug.WriteLine("hello...." + ": " + DateTime.Now + "\r\n" + sendMsg + "\r\n\n");
        }
    }
}
