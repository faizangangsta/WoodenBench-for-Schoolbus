using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


using Newtonsoft.Json.Linq;
using WBServicePlatform.Databases;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WinClient.DelegateClasses;
using WBServicePlatform.WinClient.StaticClasses;
using WBServicePlatform.WinClient.Views;

using static WBServicePlatform.WinClient.StaticClasses.GlobalFunc;

namespace WBServicePlatform.WinClient.Users
{
    public partial class UserActivity
    {

        //public static event UserActivityHandler onUserActivityEvent;

        //public static void ChangePassWord(UserObject NowUser, string OriPasswrd, string NewPasswrd)
        //{
        //    new Thread(new ThreadStart(delegate { _ChangePsW(NowUser, OriPasswrd, NewPasswrd); }))
        //    { Name = "User Change Password", IsBackground = false }.Start();
        //}
        //
        //public static void Login(string xUserName, string xPassword, bool OnlyVerify, string RealN = "")
        //{
        //    new Thread(new ThreadStart(delegate { _Login(xUserName, xPassword, OnlyVerify, RealN); }))
        //    { Name = "User Login", IsBackground = false }.Start();
        //
        //}

        public static bool ChangePassWord(UserObject NowUser, string OriPasswrd, string NewPasswrd)
        {
            UserObject Change = new UserObject();
            Change.Password = Crypto.SHA256Encrypt(NewPasswrd);
            Change.objectId = NowUser.objectId;
            if (Databases.Database.UpdateData(Change) == 0)
            {
                LogWritter.DebugMessage("Change Password Success!");
                return true;
            }
            else
            {
                LogWritter.DebugMessage("Change Password Failed!");
                return false;
            }
        }

        public static bool LogOut()
        {
            CurrentUser.SetEveryThingNull();
            GC.Collect();
            return true;
        }

        public static bool Login(string xUserName, string xPassword, out UserObject user)
        {
            xUserName = xUserName.ToLower();
            string HashedPs = Crypto.SHA256Encrypt(xPassword);
            DatabaseQuery UserNameQuery = new DatabaseQuery();
            UserNameQuery.WhereContainedIn("Username", xUserName);
            UserNameQuery.WhereContainedIn("Password", HashedPs);
            if (Database.QueryData(UserNameQuery, out List<UserObject> list) > 0)
            {
                user = list[0];
                return true;
            }
            else
            {
                LogWritter.ErrorMessage("User Login Error: No User Found.");
                user = null;
                return false;
            }

        }
        //private static void onUserActivity(OperationStatus Status, UserActivityE Act, string Detail = "")
        //{
        //    UserActivityEventArgs e = new UserActivityEventArgs()
        //    {
        //        Activity = Act,
        //        ProcessStatus = Status,
        //        ErrDescription = Detail
        //    };
        //    if (onUserActivityEvent != null) onUserActivityEvent(e);
        //    e = null;
        //    GC.Collect();
        //}
    }

    //public class UserActivityEventArgs : InternalEventArgs
    //{
    //    public UserActivityEventArgs() { }
    //    public UserActivityE Activity { get; set; }
    //}
}
