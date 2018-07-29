using System;
using System.Collections.Generic;

using WBPlatform.WebManagement.Tools;

namespace WBPlatform.StaticClasses
{
    public enum ServerAction
    {
        WeChatLogin_PreExecute,
        WeChatLogin_PostExecute,

        Home_Index,
        MyAccount_UserRegister,
        Home_BugReport,

        BusManage_Index,
        BusManage_SignStudents,
        BusManage_CodeGenerate,
        BusManage_DataModify,
        BusManage_WeekIssue,

        MyChild_Index,
        MyChild_MarkAsArrived,

        MyClass_Index,

        MyAccount_Index,
        MyAccount_CreateChangeRequest,

        General_ViewStudent,
        General_ViewChangeRequests,

        Manage_Index,
        Manage_UserManage,
        Manage_VerifyChangeRequest,

        INTERNAL_ERROR
    }

    public enum TicketUsage
    {
        //WeChatLogin,
        UserRegister,
        AddPassword
    }
    public static class WeChat
    {
        public const int agentId = 41;

        public const string CorpID = "wx68bec13e85ca6465";
        public const string CorpSecret = "DatZ0P349SEAS-yDiqpHbb_3VR-kAnKtSaZj39KuWmhJqiiIjmW83LDpIvE49-Gt";
        public const string sToken = "2Sfp4gdyUgxDYFvKNRDkgcrJ";
        public const string sEncodingAESKey = "ak5E1GUNu5TAeEnpfUykRKNxoxe5cFo1dh1bTbKjcgB";

        public static WXEncryptedXMLHelper WeChatEncryptor { get; set; }
        public static string AccessTicket { get; set; }
        public static string AccessToken { get; set; }
        public static DateTime AvailableTime_Ticket { get; set; }
        public static DateTime AvailableTime_Token { get; set; }
        public const string GetAccessToken_Url = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?" + "corpid=" + CorpID + "&corpsecret=" + CorpSecret;
        public enum Event
        {
            subscribe,
            enter_agent,
            LOCATION,
            batch_job_result,
            change_contact,
            click,
            view,
            scancode_push,
            scancode_waitmsg,
            pic_sysphoto,
            pic_photo_or_album,
            pic_weixin,
            location_select
        }
        public enum RcvdMessageType { text, image, voice, video, location, link, EVENT /*, _INJECTION_DEVELOPER_ERROR_REPORT*/ }
        public enum SentMessageType { text, image, voice, video, file, textcard, news, mpnews }

        private static bool InitialiseWeChatCodes()
        {
            LW.D("Query New WeChat Keys....");
            Dictionary<string, string> JSON;
            LW.D("\tGetting Access Token....");
            JSON = PublicTools.HTTPGet(GetAccessToken_Url);
            AccessToken = JSON["access_token"];
            AvailableTime_Token = DateTime.Now.AddSeconds(int.Parse(JSON["expires_in"]));
            LW.D("\tGetting Ticket....");
            JSON = PublicTools.HTTPGet("https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token=" + AccessToken);
            AccessTicket = JSON["ticket"];
            AvailableTime_Ticket = DateTime.Now.AddSeconds(int.Parse(JSON["expires_in"]));
            LW.D("WeChat Keys Initialised Successfully!");
            return true;
        }
        public static bool ReNewWCCodes()
        {
            LW.D("Started Renew WeChat Operation Codes.....");
            LW.D("\tChecking Access Tickets...");
            if (AvailableTime_Ticket.Subtract(DateTime.Now).TotalMilliseconds <= 0) { InitialiseWeChatCodes(); return false; }
            LW.D("\tChecking Tokens...");
            if (AvailableTime_Token.Subtract(DateTime.Now).TotalMilliseconds <= 0) { InitialiseWeChatCodes(); return false; }
            return true;
        }
    }
}