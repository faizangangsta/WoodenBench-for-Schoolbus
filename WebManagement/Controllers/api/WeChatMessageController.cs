using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using WBServicePlatform.WebManagement.Tools;

namespace WBServicePlatform.WebManagement.Controllers.api
{
    [Produces("application/json")]
    [Route("api/WeChatMessage")]
    public class WeChatMessageController : Controller
    {
        /// <summary>
        /// USED TO SERIFY THE WECHAR MESSAGE <![CDATA[WECHAT_MESSAGE_VERIFY]]>
        /// </summary>
        /// <param name="msg_signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="echostr"></param>
        [HttpGet]
        public void Get(string msg_signature, string timestamp, string nonce, string echostr)
        {
            int ret = 0;
            string sEchoStr = "";
            ret = Program._WeChatEncryptor.VerifyURL(msg_signature, timestamp, nonce, echostr, ref sEchoStr);
            if (ret != 0)
            {
                return;
            }
            byte[] SendingByte = Encoding.UTF8.GetBytes(sEchoStr);
            Response.Body.Write(SendingByte, 0, SendingByte.Length);
        }
        /// <summary>
        /// Whatever they are sending....
        /// </summary>
        /// <param name="msg_signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        [HttpPost]
        public void POST(string msg_signature, string timestamp, string nonce)
        {
            MemoryStream ms = new MemoryStream();
            Request.Body.CopyTo(ms);
            string XML_Message = "";
            int ret = Program._WeChatEncryptor.DecryptMsg(msg_signature, timestamp, nonce, Encoding.UTF8.GetString(ms.ToArray()), ref XML_Message);
            if (ret != 0)
            {
                Response.StatusCode = 500;
                return;
            }
            lock (WeChatMessageProc.MessageList)
            {
                WeChatMessageProc.MessageList.Add(new WeChatMessage(XML_Message));
            }
            Response.StatusCode = 200;
            Response.WriteAsync("");
        }
    }
}
