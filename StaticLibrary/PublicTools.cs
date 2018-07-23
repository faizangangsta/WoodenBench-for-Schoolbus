using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace WBPlatform.StaticClasses
{
    public static class PublicTools
    {
        public static object EncodeString(object item) => item is string ? HttpUtility.UrlPathEncode(item as string) : item;
        public static object DecodeObject(object item) => item is string ? HttpUtility.UrlDecode(item as string) : item;

        public static Dictionary<string, string> HTTPGet(string URL)
        {
            LW.D("HTTP - GET-rqst: " + URL);
            HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string resp = reader.ReadToEnd();
            LW.D("HTTP - GET-rply: " + resp);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(resp);
        }

        public static Dictionary<string, string> HTTPPost(string postUrl, string paramData)
        {
            LW.D("HTTP - POST-rqst: " + postUrl + " WITH DATA : " + paramData);
            byte[] byteArray = Encoding.UTF8.GetBytes(paramData);
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
            webReq.Method = "POST";
            webReq.ContentType = "application/x-www-form-urlencoded";

            webReq.ContentLength = byteArray.Length;
            Stream newStream = webReq.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Flush();
            newStream.Close();
            newStream.Dispose();
            HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string ret = sr.ReadToEnd();
            sr.Close();
            response.Close();

            LW.D("HTTP - POST-rply: " + ret);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (KeyValuePair<string, object> item in JsonConvert.DeserializeObject<Dictionary<string, object>>(ret))
            {
                dict.Add(item.Key, item.Value == null ? "" : item.Value.ToString());
            }
            return dict;
        }

        public static byte[] Int2Bytes(int n)
        {
            byte[] b = new byte[4];
            for (int i = 0; i < 4; i++) { b[i] = (byte)(n >> (24 - (i * 8))); }
            return b;
        }


        public static int BytesToInt(byte[] b)
        {
            int mask = 0xff;
            int temp = 0;
            int n = 0;
            for (int i = 0; i < b.Length; i++)
            {
                n <<= 8;
                temp = b[i] & mask;
                n |= temp;
            }
            return n;
        }
        public static string DecodeMessage(NetworkStream stream)
        {
            byte[] fsBytes;
            int ContentLenth;
            byte[] arrServerRecMsg = new byte[1];
            stream.Read(arrServerRecMsg, 0, 1);
            int HeaderLenth = BytesToInt(arrServerRecMsg);

            arrServerRecMsg = new byte[HeaderLenth];
            stream.Read(arrServerRecMsg, 0, HeaderLenth);
            ContentLenth = BytesToInt(arrServerRecMsg);

            int total = 0;
            int dataleft = ContentLenth;
            fsBytes = new byte[ContentLenth];
            int recv;
            while (total < ContentLenth)
            {
                recv = stream.Read(fsBytes, total, dataleft);
                if (recv == 0) break;
                total += recv;
                dataleft -= recv;
            }
            return Encoding.UTF8.GetString(fsBytes, 0, ContentLenth);
        }
        public static byte[] EncodeMessage(string MessageId, string sendMsg)
        {
            List<byte> mergedPackage = new List<byte>();
            byte[] arrClientSendMsg = Encoding.UTF8.GetBytes(MessageId + sendMsg);
            byte[] Header = Int2Bytes(arrClientSendMsg.Length);
            byte HeaderSize = Convert.ToByte(Header.Length);
            mergedPackage.Add(HeaderSize);
            mergedPackage.AddRange(Header);
            mergedPackage.AddRange(arrClientSendMsg);
            return mergedPackage.ToArray();
        }

        public static string ToNormalString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static void CloseAndDispose(this Socket _socket)
        {
            _socket?.Disconnect(true);
            _socket?.Close();
            _socket?.Dispose();
            _socket = null;
        }
        public static void CloseAndDispose(this TcpClient client)
        {
            client?.Close();
            client = null;
        }
        public static void CloseAndDispose(this NetworkStream stream)
        {
            stream?.Close();
            stream?.Dispose();
            stream = null;
        }
    }
}
