using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WBServicePlatform.WebManagement.Tools
{
    public class HTTPOperations
    {
        public static Dictionary<string, string> HTTPGet(string URL)
        {
            HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string resp = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(resp);
        }

        public static Dictionary<string, string> HTTPPost(string postUrl, string paramData)
        {
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(paramData);
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";

                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);
                newStream.Flush();
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();

                Dictionary<string, string> dict = new Dictionary<string, string>();
                Dictionary<string, object> m = SimpleJson.SimpleJson.DeserializeObject<Dictionary<string, object>>(ret);
                foreach (KeyValuePair<string, object> item in m)
                {
                    dict.Add(item.Key, item.Value == null ? "" : item.Value.ToString());
                }
                return dict;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}