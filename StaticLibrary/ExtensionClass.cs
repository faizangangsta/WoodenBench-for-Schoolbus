using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using WBPlatform.Database;
using WBPlatform.Database.DBIOCommand;

namespace WBPlatform.StaticClasses
{
    public static class ExtensionClass
    {
        public static string ToNormalString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static void CloseAndDispose(this Socket socket)
        {
            socket?.Disconnect(true);
            socket?.Close();
            socket?.Dispose();
            socket = null;
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
        public static T[] MoveToArray<T>(this T dbio) => new T[] { dbio };

        public static string ToParsedString(this object value) => JsonConvert.SerializeObject(value);

        public static bool ToParsedObject<T>(this string JSON, out T data)
        {
            try
            {
                data = JsonConvert.DeserializeObject<T>(JSON);
                return data != null;
            }
            catch (Exception ex)
            {
                LW.E(ex);
                data = default(T);
                return false;
            }
        }

        public static string GetString(this DataBaseIO io, string Key) => io.GetT<string>(Key);

        public static List<string> GetList(this DataBaseIO io, string Key)
        {
            string _listString = GetString(io, Key);
            return string.IsNullOrWhiteSpace(_listString) ? new List<string>() : _listString.Split(',').ToList();
        }

        public static bool GetBool(this DataBaseIO io, string Key) => io.GetT<bool>(Key);

        public static int GetInt(this DataBaseIO io, string Key) => io.GetT<int>(Key);

        public static DateTime GetDateTime(this DataBaseIO io, string Key) => io.GetT<DateTime>(Key);
    }
}
