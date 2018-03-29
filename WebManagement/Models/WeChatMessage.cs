using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using WBServicePlatform.StaticClasses;

namespace WBServicePlatform.WebManagement.Tools
{
    public class WeChatMessage
    {
        public WeChat.RcvdMessageType MessageType { get; set; }

        public WeChat.Event Event { get; set; }

        public PointF Location { get; set; }
        public decimal Precision { get; set; }

        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public int AgentID { get; set; }
        public string TextContent { get; set; }
        public string MessageID { get; set; }
        public string CreateTime { get; set; }
        public string PicUrl { get; set; }
        public string MediaId { get; set; }
        public string EventKey { get; set; }

        public WeChatMessage() { }
        public WeChatMessage(string XMLMessage)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(XMLMessage);
            XmlNode root = doc.FirstChild;
            MessageType = (WeChat.RcvdMessageType)Enum.Parse(typeof(WeChat.RcvdMessageType), root["MsgType"].InnerText, true);

            FromUser = root["FromUserName"].InnerText;
            ToUser = root["ToUserName"].InnerText;
            CreateTime = root["CreateTime"].InnerText;
            AgentID = Convert.ToInt32(root["AgentID"].InnerText);

            switch (MessageType)
            {
                case WeChat.RcvdMessageType.text:
                    TextContent = root["Content"].InnerText;
                    MessageID = root["MsgId"].InnerText;
                    break;
                case WeChat.RcvdMessageType.image:
                    PicUrl = root["PicUrl"].InnerText;
                    MediaId = root["MediaId"].InnerText;
                    break;
                case WeChat.RcvdMessageType.EVENT:
                    Event = (WeChat.Event)Enum.Parse(typeof(WeChat.Event), root["Event"].InnerText, true);
                    switch (Event)
                    {
                        case WeChat.Event.LOCATION:
                            Location = new PointF((float)Convert.ToDecimal(root["Latitude"].InnerText), (float)Convert.ToDecimal(root["Longitude"].InnerText));
                            Precision = Convert.ToDecimal(root["Precision"].InnerText);
                            break;
                        case WeChat.Event.click:
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
