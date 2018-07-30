using System;
using System.Drawing;
using System.Xml;

using WBPlatform.StaticClasses;

namespace WBPlatform.WebManagement.Tools
{
    public class WeChatRcvdMessage
    {
        public WeChatRMsg MessageType { get; set; }
        public WeChatEvent Event { get; set; }
        public PointF Location { get; set; }
        public decimal Precision { get; set; }
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public int AgentID { get; set; }
        public string TextContent { get; set; }
        public string MessageID { get; set; }
        public ulong CreateTime { get; set; }
        public string PicUrl { get; set; }
        public string MediaId { get; set; }
        public string EventKey { get; set; }
        public DateTime RecievedTime { get; }

        public WeChatRcvdMessage() { }
        public WeChatRcvdMessage(string XMLMessage, DateTime time)
        {
            RecievedTime = time;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(XMLMessage);
            XmlNode root = doc.FirstChild;
            MessageType = (WeChatRMsg)Enum.Parse(typeof(WeChatRMsg), root["MsgType"].InnerText, true);

            FromUser = root["FromUserName"].InnerText;
            ToUser = root["ToUserName"].InnerText;
            CreateTime = Convert.ToUInt64(root["CreateTime"].InnerText);
            AgentID = Convert.ToInt32(root["AgentID"].InnerText);

            switch (MessageType)
            {
                case WeChatRMsg.text:
                    TextContent = root["Content"].InnerText;
                    MessageID = root["MsgId"].InnerText;
                    break;
                case WeChatRMsg.image:
                    PicUrl = root["PicUrl"].InnerText;
                    MediaId = root["MediaId"].InnerText;
                    break;
                case WeChatRMsg.EVENT:
                    Event = (WeChatEvent)Enum.Parse(typeof(WeChatEvent), root["Event"].InnerText, true);
                    switch (Event)
                    {
                        case WeChatEvent.LOCATION:
                            Location = new PointF((float)Convert.ToDecimal(root["Latitude"].InnerText), (float)Convert.ToDecimal(root["Longitude"].InnerText));
                            Precision = Convert.ToDecimal(root["Precision"].InnerText);
                            break;
                        case WeChatEvent.click:
                            EventKey = root["EventKey"].InnerText;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
