using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WoodenBench.TableObject;

namespace WoodenBench.Users
{
    public class UserActivity : _UserActivity
    {
        private static Thread TLogOffUser = new Thread(TUserLogOff)
        {
            Name = "User Logoff",
            IsBackground = false
        };
        private static Thread TChangeUser = new Thread(new ParameterizedThreadStart(TUserChange))
        {
            Name = "User Change Password",
            IsBackground = false
        };
        private static Thread TLoginUser = new Thread(new ParameterizedThreadStart(TUserLogin))
        {
            Name = "User Login",
            IsBackground = false
        };
        private static void TUserLogOff()
        {
            _UserActivity._LogOut();
        }
        private static void TUserChange(object Obj)
        {
            List<object> p = (List<object>)Obj;
            _ChangePassWord((AllUserObject)p[0], p[1].ToString(), p[2].ToString());
        }
        private static void TUserLogin(object Obj)
        {
            List<object> p = (List<object>)Obj;
            _Login(p[0].ToString(), p[1].ToString(), (bool)p[2], p[3].ToString());
        }


        public static void LogOut()
        {
            if (!TLogOffUser.IsAlive) { TLogOffUser.Start(); }
        }

        public static void ChangePassWord(AllUserObject NowUser, string OriPasswrd, string NewPasswrd)
        {
            if (!TChangeUser.IsAlive)
            {
                List<object> Para = new List<object> { NowUser, OriPasswrd, NewPasswrd };
                TChangeUser.Start(Para);
            }
        }

        public static void Login(string xUserName, string xPassword, bool OnlyVerify, string RealN = "")
        {
            if (!TLoginUser.IsAlive)
            {
                List<object> Para = new List<object> { xUserName, xPassword, OnlyVerify, RealN };
                TLoginUser.Start(Para);
            }
        }
    }
}
