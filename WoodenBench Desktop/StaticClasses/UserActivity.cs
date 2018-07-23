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
using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.DesktopClient.DelegateClasses;
using WBPlatform.DesktopClient.StaticClasses;
using WBPlatform.DesktopClient.Views;

using static WBPlatform.DesktopClient.StaticClasses.GlobalFunctions;

namespace WBPlatform.DesktopClient.Users
{
    public static class UserActivity
    {
        public static bool ChangePassWord(UserObject NowUser, string OriPasswrd, string NewPasswrd)
        {
            if (Cryptography.SHA256Encrypt(OriPasswrd) != CurrentUser.Password)
            {
                LW.E("ChangePassword Request Failed, Reason: Original Password Incorrect....");
                return false;
            }
            else
            {
                NowUser.Password = Cryptography.SHA256Encrypt(NewPasswrd);
                if (DataBaseOperation.UpdateData(NowUser, new DBQuery()
                    .WhereEqualTo("objectId", CurrentUser.ObjectId)
                    .WhereEqualTo("Password", Cryptography.SHA256Encrypt(OriPasswrd))
                    .WhereEqualTo("Username", CurrentUser.UserName)) == DBQueryStatus.ONE_RESULT)
                {
                    LW.D("Change Password Success!");
                    return true;
                }
                else
                {
                    LW.D("Change Password Failed!");
                    return false;
                }
            }
        }

        public static bool LogOut()
        {
            CurrentUser.GetNull();
            GC.Collect();
            return true;
        }

        public static bool Login(string xUserName, string xPassword, out UserObject user)
        {
            xUserName = xUserName.ToLower();
            string HashedPs = Cryptography.SHA256Encrypt(xPassword);
            DBQuery UserNameQuery = new DBQuery();
            UserNameQuery.WhereEqualTo("Username", xUserName);
            UserNameQuery.WhereEqualTo("Password", HashedPs);
            switch (DataBaseOperation.QuerySingleData(UserNameQuery, out user))
            {
                case DBQueryStatus.INTERNAL_ERROR:
                    LW.E("Internal DataBase Error");
                    break;
                case DBQueryStatus.NO_RESULTS:
                    LW.E("No User Found");
                    break;
                case DBQueryStatus.ONE_RESULT:
                    LW.E("User Found");
                    return true;
                case DBQueryStatus.MORE_RESULTS:
                    LW.E("WTF Exception....");
                    break;
                default:
                    break;
            }
            return false;

        }
    }
}
