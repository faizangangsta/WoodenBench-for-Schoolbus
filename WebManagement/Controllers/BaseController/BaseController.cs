using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;

using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    public class BaseController : Controller
    {
        public UserObject CurrentUser { get => CurrentIdentity.User; }
        public UserIdentity CurrentIdentity { get; private set; } = UserIdentity.Unknown;

        public TelemetryClient Telemetry { get; set; } = new TelemetryClient();

        public static readonly string UID_CookieName = "identifiedUID";
        public static int GetCount { get => SessionCollection.Count; }
        private static Dictionary<string, UserIdentity> SessionCollection { get; set; } = new Dictionary<string, UserIdentity>();

        //public static string RenewSession(string SessionString, string UserAgent, UserObject _user)
        //{
        //    string _Str = GetSessionString(_user, UserAgent);
        //    lock (SessionCollection)
        //    {
        //        if (SessionCollection.ContainsKey(SessionString))
        //        {
        //            SessionCollection.Remove(SessionString);
        //        }
        //        SessionCollection.Add(_Str, new UserIdentity(UserAgent, _user));
        //        return _Str;
        //    }
        //}

        private string GetNewSession()
            => Cryptography.SHA512Encrypt(
                Cryptography.RandomString(10, true) +
                CurrentUser.UserName +
                CurrentUser.UserGroup.ToString() +
                DateTime.Now.TimeOfDay.TotalMilliseconds.ToString() +
                Request.Headers["User-Agent"] +
                CurrentUser.UserGroup.ToString());

        public void UpdateUser(UserObject _user)
        {
            SessionCollection.Remove(Request.Cookies["Session"] ?? "");
            CurrentIdentity = new UserIdentity(Request.Headers["User-Agent"], _user);
            string NewSession = GetNewSession();
            Response.Cookies.Append("Session", NewSession, new CookieOptions() { Expires = DateTime.Now.AddHours(4) });
            SessionCollection.Add(NewSession, CurrentIdentity);
        }

        public bool ValidateSession()
        {
            string SessionString = Request.Cookies["Session"];
            string UA = Request.Headers["User-Agent"];

            if (string.IsNullOrWhiteSpace(SessionString) || string.IsNullOrWhiteSpace(UA)) return false;
            if (SessionCollection.ContainsKey(SessionString) && (UA == "JumpToken_FreeLogin" || SessionCollection[SessionString].UserAgent == UA))
            {
                lock (SessionCollection)
                {
                    SessionCollection[SessionString].SetLastActive();
                }
                CurrentIdentity = SessionCollection[SessionString];

                User.AddIdentity(CurrentIdentity.Identity);

                Telemetry.Context.User.Id = CurrentUser.GetIdentifiableCode();
                Telemetry.Context.Session.Id = Request.Cookies["Session"] ?? "Unknown";

                ViewData[UID_CookieName] = CurrentUser.GetIdentifiableCode();
                Response.Cookies.Append("ai_user", CurrentUser.GetIdentifiableCode());

                string _session = HttpContext.Connection.RemoteIpAddress.ToString() + ":" + HttpContext.Connection.RemotePort + "-" + CurrentUser.GetIdentifiableCode() + "-";
                Response.Cookies.Append("ai_session", _session + Request.Cookies["Session"].Substring(0, 5) ?? "Unknown");
                Response.Cookies.Append("ai_authUser", CurrentUser.RealName);

                return true;
            }
            else return false;
        }
    }
}
