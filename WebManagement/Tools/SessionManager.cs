using cn.bmob.io;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;

namespace WBServicePlatform.WebManagement.Tools
{
    public static class Sessions
    {
        private static Dictionary<string, SessionInfo> __SessionCollection { get; set; } = new Dictionary<string, SessionInfo>();
        
        private static string _GetSessionString(UserObject LogonUser, string UA)
            => Crypto.SHA512Encrypt(Crypto.RandomString(10, true) + LogonUser.WeChatID + new Random().NextDouble().ToString() + LogonUser.UserGroup.ToString() +
                DateTime.Now.TimeOfDay.TotalMilliseconds.ToString() + LogonUser.Password + UA + LogonUser.UserGroup.ToString());



        public struct SessionInfo
        {
            public string USER_objectId;
            public string UserAgent;
            public string SessionString;
            public DateTime LastSeenAlive;
            public UserObject user;
        }


        public static string RenewSession(string SessionString, string UserAgent, UserObject sessionInfo)
        {
            string _Str = _GetSessionString(sessionInfo, UserAgent);
            lock (__SessionCollection)
            {
                if (__SessionCollection.ContainsKey(SessionString))
                {
                    __SessionCollection.Remove(SessionString);
                }
                __SessionCollection.Add(_Str, new SessionInfo()
                {
                    LastSeenAlive = DateTime.Now,
                    SessionString = _Str,
                    user = sessionInfo,
                    USER_objectId = sessionInfo.objectId,
                    UserAgent = UserAgent
                });
                return _Str;
            }
        }

        public static bool OnSessionReceived(string SessionString, string UserAgent, out UserObject user)
        {
            user = null;
            if (SessionString == null || UserAgent == null) return false;
            lock (__SessionCollection)
            {
                if (__SessionCollection.ContainsKey(SessionString) && __SessionCollection[SessionString].UserAgent == UserAgent)
                {
                    SessionInfo SI = __SessionCollection[SessionString];
                    SI.LastSeenAlive = DateTime.Now;
                    __SessionCollection[SessionString] = SI;
                    user = __SessionCollection[SessionString].user;
                    return true;
                }
                else return false;
            }
        }


        public static string OnWeChatCodeRcvd_Login(string Code, string UserAgent, out object LogonUser)
        {
            ReNewWCCodes();
            LogonUser = null;
            Dictionary<string, string> JSON = HTTPOperations.HTTPGet("https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token=" + WeChat.AccessToken + "&code=" + Code);
            if (!JSON.ContainsKey("UserId")) return null;
            string WeiXinID = JSON["UserId"];
            switch (QueryHelper.BmobQueryData(new BmobQuery().WhereContainedIn("WeChatID", WeiXinID), out List<UserObject> UserList))
            {
                case -1: return null;
                case 0: return "0";
                case 1:
                    LogonUser = UserList[0];
                    string SessionString = _GetSessionString((UserObject)LogonUser, UserAgent);
                    lock (__SessionCollection)
                    {
                        __SessionCollection.Add(SessionString, new SessionInfo()
                        {
                            LastSeenAlive = DateTime.Now,
                            USER_objectId = ((UserObject)LogonUser).objectId,
                            UserAgent = UserAgent,
                            user = (UserObject)LogonUser,
                            SessionString = SessionString
                        });
                        return SessionString;
                    }
                default: return null;
            }
        }


        public static bool InitialiseWeChatCodes()
        {
            Dictionary<string, string> JSON;
            JSON = HTTPOperations.HTTPGet(WeChat.GetAccessToken_Url);
            WeChat.AccessToken = JSON["access_token"];
            WeChat.AvailableTime_Token = DateTime.Now.AddSeconds(int.Parse(JSON["expires_in"]));


            JSON = HTTPOperations.HTTPGet("https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token=" + WeChat.AccessToken);
            WeChat.AccessTicket = JSON["ticket"];
            WeChat.AvailableTime_Ticket = DateTime.Now.AddSeconds(int.Parse(JSON["expires_in"]));

            return true;
        }
        public static bool ReNewWCCodes()
        {
            if (WeChat.AvailableTime_Ticket.Subtract(DateTime.Now).TotalMilliseconds <= 0)
            {
                InitialiseWeChatCodes();
                return false;
            }
            if (WeChat.AvailableTime_Token.Subtract(DateTime.Now).TotalMilliseconds <= 0)
            {
                InitialiseWeChatCodes();
                return false;
            }
            return true;
        }
    }
}
