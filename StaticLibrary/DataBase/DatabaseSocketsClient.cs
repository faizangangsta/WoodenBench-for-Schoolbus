using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using WBPlatform.Database.DBIOCommand;
using WBPlatform.StaticClasses;

namespace WBPlatform.Database.Connection
{
    public static class DatabaseSocketsClient
    {
        //创建 1个客户端套接字 和1个负责监听服务端请求的线程  
        private static Thread ReceiverThread = new Thread(Recv);
        private static Thread DataBaseConnectionMaintainer = new Thread(new ThreadStart(Maintain));
        private static TcpClient socketclient = new TcpClient();
        private static NetworkStream stream;
        private static IPEndPoint remoteEndpoint;

        private static TimeSpan WaitTimeout = new TimeSpan(0, 0, 20);
        private static bool IsFirstTimeInit { get; set; } = true;

        public static bool Connected { get { return socketclient.Connected; } }

        private static Dictionary<string, string> _messages { get; set; } = new Dictionary<string, string>();
        public static void StartThread()
        {
            ReceiverThread.Start();
            DataBaseConnectionMaintainer.Start();
        }
        public static bool Initialise(IPAddress ServerIP)
        {
            socketclient = new TcpClient();
            remoteEndpoint = new IPEndPoint(ServerIP, 8098);
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    socketclient.Connect(remoteEndpoint);
                    stream = socketclient.GetStream();
                    LW.D("\tDatabase Connection Estabilished!");
                    if (IsFirstTimeInit)
                    {
                        StartThread();
                        IsFirstTimeInit = false;
                    }
                    SendData("openConnection", "00000", out string token);
                    LW.D("\tDatabase Connected! Identity: " + token);
                    return true;
                }
                catch (Exception ex)
                {
                    LW.E("\t\tDatabase connection to server: " + ServerIP + " failed. " + ex.Message);
                    Thread.Sleep(1000);
                }
            }
            return false;
        }

        // 接收服务端发来信息的方法    
        static void Recv()
        {
            while (true)
            {
                while (Connected)
                {
                    try
                    {
                        string requestString = PublicTools.DecodeMessage(stream);
                        _messages.Add(requestString.Substring(0, 5), requestString.Substring(5));
                    }
                    catch { Thread.Sleep(500); }
                }
                while (!Connected)
                {
                    LW.E("Message Recieve waiting for connection......");
                    Thread.Sleep(500);
                }
            }
        }

        private static void Maintain()
        {
            while (true)
            {
                try
                {
                    string _mid = Cryptography.RandomString(5, false);
                    byte[] packet = PublicTools.EncodeMessage(_mid, "HeartBeat");
                    if (CoreSend(packet, _mid, out string reply))
                    {
                        LW.D("HeartBeat Succeed! " + reply);
                    }
                    else
                    {
                        throw new Exception("CoreSend Error: Timeout");
                    }
                    Thread.Sleep(5000);
                }
                catch (Exception ex)
                {
                    LW.E("Heartbeat Error! " + ex.Message);
                    socketclient.CloseAndDispose();
                    stream.CloseAndDispose();
                    Initialise(remoteEndpoint.Address);
                    Thread.Sleep(10000);
                }
            }
        }

        //发送字符信息到服务端的方法
        public static bool SendData(string sendMsg, string MessageId, out string rcvdMessage)
        {
            rcvdMessage = "";
            byte[] mergedPackage = PublicTools.EncodeMessage(MessageId, sendMsg);
            while (!Connected)
            {
                LW.E("Message Sent Waiting for connection....");
                Thread.Sleep(500);
            }
            return CoreSend(mergedPackage, MessageId, out rcvdMessage);
        }

        private static bool CoreSend(byte[] packet, string MessageId, out string rcvdMessage)
        {
            stream.Write(packet, 0, packet.Length);
            DateTime _timeoutTime = DateTime.Now.Add(WaitTimeout);
            while (true)
            {
                if (_messages.ContainsKey(MessageId))
                {
                    rcvdMessage = _messages[MessageId];
                    _messages.Remove(MessageId);
                    return true;
                }
                Thread.Sleep(10);
                if (_timeoutTime.Subtract(DateTime.Now).TotalMilliseconds <= 0)
                {
                    rcvdMessage = null;
                    return false;
                }
            }
        }
    }
}
