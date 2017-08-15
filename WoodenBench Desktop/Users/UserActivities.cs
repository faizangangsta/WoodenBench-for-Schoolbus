using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WoodenBench.DelegateClasses;
using WoodenBench.StaClasses;
using WoodenBench.TableObject;

namespace WoodenBench.Users
{
    public partial class UserActivity
    {

        public  static event onUserActivityHandler onUserActivityEvent;
        private static Thread BusyThread = new Thread(new ThreadStart(delegate { }));

        public static void LogOut()
        {
            if (!BusyThread.IsAlive || BusyThread == null)
            {
                BusyThread = new Thread(new ThreadStart(delegate { _LogOut(); }))
                { Name = "User Logoff", IsBackground = false };
                BusyThread.Start();
            }
        }

        public static void ChangePassWord(AllUserObject NowUser, string OriPasswrd, string NewPasswrd)
        {
            if (!BusyThread.IsAlive || BusyThread == null)
            {
                BusyThread = new Thread(new ThreadStart(delegate { _ChangePsW(NowUser, OriPasswrd, NewPasswrd); }))
                { Name = "User Change Password", IsBackground = false };
                BusyThread.Start();
            }
        }

        public static void Login(string xUserName, string xPassword, bool OnlyVerify, string RealN = "")
        {
            if (!BusyThread.IsAlive || BusyThread == null)
            {
                BusyThread = new Thread(new ThreadStart(delegate { _Login(xUserName, xPassword, OnlyVerify, RealN); }))
                { Name = "User Login", IsBackground = false };
                BusyThread.Start();
            }
        }

        public static void CreateUser(string Username, string Realname, string Password, int UserGroup)
        {
            if (!BusyThread.IsAlive || BusyThread == null)
            {
                BusyThread = new Thread(new ThreadStart(delegate { _Create(Username, Realname, Password, UserGroup); }))
                { Name = "User Login", IsBackground = false };
                BusyThread.Start();
            }
        }
    }
    public class UserActivityEventArgs : EventArgs
    {
        public UserActivityEventArgs() { }
        public ProcStatE ProcessStatus { get; set; }
        public UsrActvtiE Activity { get; set; }
        public AllUserObject AfterChange { get; set; }
        public string Describe { get; set; }
    }
}

