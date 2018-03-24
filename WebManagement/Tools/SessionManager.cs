using cn.bmob.io;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using static WBServicePlatform.WebManagement.Program;

namespace WBServicePlatform.WebManagement.Tools
{
    public static class Sessions
    {
        public static Dictionary<string, string> JumpToken = new Dictionary<string, string>();
        private static Dictionary<string, SessionInfo> _Sessions { get; set; } = new Dictionary<string, SessionInfo>();
        private struct SessionInfo
        {
            public string USER_objectId;
            public string UserAgent;
            public string SessionString;
            public DateTime LastSeenAlive;
            public UserObject user;
        }
        private static bool _CheckSessionExists(string SessionString)
        {
            return _Sessions.ContainsKey(SessionString);
        }

        private static string _GetSessionString(UserObject LogonUser, string UA)
        {
            return Crypto.SHA256Encrypt(
                Crypto.RandomString(10, true) +
                LogonUser.WeChatID +
                new Random().NextDouble().ToString() +
                LogonUser.UserGroup.ToString() +
                DateTime.Now.TimeOfDay.TotalMilliseconds.ToString() +
                LogonUser.Password + UA +
                LogonUser.UserGroup.ToString()
                );
        }

        private static void _RefreshSessionTime(string SessionString)
        {
            SessionInfo SI = _Sessions[SessionString];
            SI.LastSeenAlive = DateTime.Now;
            _Sessions[SessionString] = SI;
        }

        private static bool _AddSession(string SessionString, SessionInfo sessionInfo)
        {
            _Sessions.Add(SessionString, sessionInfo);
            return true;
        }

        public static bool OnSessionReceived(string SessionString, string UserAgent, out UserObject user)
        {
            user = null;
            if (SessionString == null || UserAgent == null) return false;
            lock (_Sessions)
            {
                if (_CheckSessionExists(SessionString) && _Sessions[SessionString].UserAgent == UserAgent)
                {
                    _RefreshSessionTime(SessionString);
                    user = _Sessions[SessionString].user;
                    return true;
                }
                else return false;
            }
        }

        public static string RenewSession(string SessionString, string UserAgent, UserObject sessionInfo)
        {
            lock (_Sessions)
            {
                if (_CheckSessionExists(SessionString))
                {
                    _Sessions.Remove(SessionString);
                }
                string _Str = _GetSessionString(sessionInfo, UserAgent);
                _AddSession(_Str, new SessionInfo()
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

        public static string OnWeChatCodeRcvd_Login(string Code, string UserAgent, out object LogonUser)
        {
            ReNewWCCodes();
            LogonUser = null;
            Dictionary<string, string> JSON = HTTPOperations.HTTPGet("https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token=" + WeChat.AccessToken + "&code=" + Code);
            if (!JSON.ContainsKey("UserId")) return null;
            string WeiXinID = JSON["UserId"];
            Dictionary<string, string> dict = new Dictionary<string, string>();
            BmobQuery UserNameQuery = new BmobQuery();
            UserNameQuery.WhereContainedIn("WeChatID", WeiXinID);
            try
            {
                var UsrNameResult = _Bmob.FindTaskAsync<UserObject>(WBConsts.TABLE_N_Gen_UserTable, UserNameQuery);
                UsrNameResult.Wait();
                if (UsrNameResult.Result.results.Count == 1)
                {
                    LogonUser = UsrNameResult.Result.results[0];
                    string SessionString = _GetSessionString((UserObject)LogonUser, UserAgent);
                    lock (_Sessions)
                    {
                        _AddSession(SessionString, new SessionInfo()
                        {
                            LastSeenAlive = DateTime.Now,
                            USER_objectId = ((UserObject)LogonUser).objectId,
                            UserAgent = UserAgent,
                            user = (UserObject)LogonUser,
                            SessionString = SessionString
                        });
                    }
                    return SessionString;
                }
                else return "0";
            }
            catch (Exception) { return null; }
        }


        public static bool InitialiseWeChatCodes()
        {
            Dictionary<string, string> JSON;
            JSON = HTTPOperations.HTTPGet(WeChat.AccessToken_Url);
            WeChat.AccessToken = JSON["access_token"];
            WeChat.AvailableTime_Token = DateTime.Now.AddMinutes(int.Parse(JSON["expires_in"]));


            JSON = HTTPOperations.HTTPGet("https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token=" + WeChat.AccessToken);
            WeChat.AccessTicket = JSON["ticket"];
            WeChat.AvailableTime_Ticket = DateTime.Now.AddMinutes(int.Parse(JSON["expires_in"]));

            return true;
        }
        public static bool ReNewWCCodes()
        {
            if (WeChat.AvailableTime_Ticket.Subtract(DateTime.Now).TotalSeconds <= 0)
            {
                InitialiseWeChatCodes();
                return false;
            }
            if (WeChat.AvailableTime_Token.Subtract(DateTime.Now).TotalSeconds <= 0)
            {
                InitialiseWeChatCodes();
                return false;
            }
            return true;
        }
    }
}
