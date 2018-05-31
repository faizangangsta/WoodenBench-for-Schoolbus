using System;
using System.Collections.Generic;

using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;

namespace WBPlatform.WebManagement.Tools
{
    public static class Sessions
    {
        private static Dictionary<string, SessionInfo> __SessionCollection { get; set; } = new Dictionary<string, SessionInfo>();

        private static string _GetSessionString(UserObject LogonUser, string UA)
            => Crypto.SHA512Encrypt(Crypto.RandomString(10, true) + LogonUser.UserName + new Random().NextDouble().ToString() + LogonUser.UserGroup.ToString() +
                DateTime.Now.TimeOfDay.TotalMilliseconds.ToString() + LogonUser.Password + UA + LogonUser.UserGroup.ToString());

        public struct SessionInfo
        {
            public string UserAgent;
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
                    user = sessionInfo,
                    UserAgent = UserAgent
                });
                return _Str;
            }
        }

        public static bool OnSessionReceived(string SessionString, string UserAgent, out UserObject user)
        {
            user = null;
            if (SessionString == null || UserAgent == null) return false;
            if (__SessionCollection.ContainsKey(SessionString) && __SessionCollection[SessionString].UserAgent == UserAgent)
            {
                SessionInfo SI = __SessionCollection[SessionString];
                SI.LastSeenAlive = DateTime.Now;
                lock (__SessionCollection)
                {
                    __SessionCollection[SessionString] = SI;
                }
                user = __SessionCollection[SessionString].user;
                return true;
            }
            else return false;
        }


        public static string OnWeChatCodeRcvd_Login(string Code, string UserAgent, out object LogonUser)
        {
            WeChat.ReNewWCCodes();
            LogonUser = null;
            Dictionary<string, string> JSON = HTTPOperations.HTTPGet("https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token=" + WeChat.AccessToken + "&code=" + Code);
            if (!JSON.ContainsKey("UserId")) return null;
            string WeiXinID = JSON["UserId"];
            switch (Database.QueryMultipleData(new DatabaseQuery().WhereEqualTo("Username", WeiXinID), out List<UserObject> UserList))
            {
                case DatabaseQueryResult.INTERNAL_ERROR: return null;
                case DatabaseQueryResult.NO_RESULTS:
                    LogonUser = WeiXinID;
                    return "0";
                case DatabaseQueryResult.ONE_RESULT:
                    LogonUser = UserList[0];
                    string SessionString = _GetSessionString((UserObject)LogonUser, UserAgent);
                    lock (__SessionCollection)
                    {
                        __SessionCollection.Add(SessionString, new SessionInfo()
                        {
                            LastSeenAlive = DateTime.Now,
                            UserAgent = UserAgent,
                            user = (UserObject)LogonUser,
                        });
                        return SessionString;
                    }
                default: return null;
            }
        }
    }
}
