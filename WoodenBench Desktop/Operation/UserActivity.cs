using cn.bmob.api;
using cn.bmob.json;
using cn.bmob.tools;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using WoodenBench_Desktop.Controls;
using WoodenBench_Desktop.Controls.Users;

namespace WoodenBench_Desktop.Operation
{
    public class UserActivity
    {
        static bool Init = false;
        static BmobWindows Bmob;
        private static void InitBmob()
        {
            if (!Init)
            {
                Bmob = new BmobWindows();
                Bmob.initialize("b770100ff0051b0c313c1a0e975711e6", "281fb4c79c3a3391ae6764fa56d1468d");
                Init = true;
                BmobDebug.Register(Message => { Debug.WriteLine(Message); });
            }
        }
        public static bool ChangePassWord(UserTableElements NowUser, string OriginPasswrd, string NewPasswrd)
        {
            InitBmob();
            UserTableElements Obj = new UserTableElements(Consts.TABLE_NAME_General_AllUser)
            {
                objectId = NowUser.UserID,
                CUserGroup = (int)NowUser.UserGroup,
                Password = NewPasswrd,
                UserName = NowUser.UserName
            };
            var Result = Bmob.UpdateTaskAsync(Obj);
            JObject JsonNowUsrResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(Result.Result));
            return true;
        }
        public static void LogOut()
        {
            InitBmob();
            Views.MainWindow.NowUser = null;
            Views.UsrLoginForm.Default.Show();
            Views.MainWindow.Default.Close();
            Views.ChangeUserData.Default.Close();
            //Clean User Data

        }
    }
}