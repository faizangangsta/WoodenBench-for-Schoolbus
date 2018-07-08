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
                LogWritter.ErrorMessage("ChangePassword Request Failed, Reason: Original Password Incorrect....");
                return false;
            }
            else
            {
                NowUser.Password = Cryptography.SHA256Encrypt(NewPasswrd);
                if (DatabaseOperation.UpdateData(NowUser, new DBQuery()
                    .WhereEqualTo("objectId", CurrentUser.objectId)
                    .WhereEqualTo("Password", Cryptography.SHA256Encrypt(OriPasswrd))
                    .WhereEqualTo("Username", CurrentUser.UserName)) == DBQueryStatus.ONE_RESULT)
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
            string HashedPs = Cryptography.SHA256Encrypt(xPassword);
            DBQuery UserNameQuery = new DBQuery();
            UserNameQuery.WhereEqualTo("Username", xUserName);
            UserNameQuery.WhereEqualTo("Password", HashedPs);
            switch (DatabaseOperation.QuerySingleData(UserNameQuery, out user))
            {
                case DBQueryStatus.INTERNAL_ERROR:
                    LogWritter.ErrorMessage("Internal DataBase Error");
                    break;
                case DBQueryStatus.NO_RESULTS:
                    LogWritter.ErrorMessage("No User Found");
                    break;
                case DBQueryStatus.ONE_RESULT:
                    LogWritter.ErrorMessage("User Found");
                    return true;
                case DBQueryStatus.MORE_RESULTS:
                    LogWritter.ErrorMessage("WTF Exception....");
                    break;
                default:
                    break;
            }
            return false;

        }
    }
}
