using WBPlatform.StaticClasses;

namespace WBPlatform.WebManagement.Tools
{
    public class WeChatSentMessage
    {
        public WeChatSentMessage(WeChatSMsg type, string title, string content, string uRL_OnClick, params string[] toUser)
        {
            Content = content;
            this.toUser = toUser;
            this.type = type;
            Title = title;
            URL_OnClick = uRL_OnClick;
        }

        public string Content { get; set; }
        public string[] toUser { get; set; }
        public WeChatSMsg type { get; set; }
        public string Title { get; set; }
        public string URL_OnClick { get; set; }
    }
}
