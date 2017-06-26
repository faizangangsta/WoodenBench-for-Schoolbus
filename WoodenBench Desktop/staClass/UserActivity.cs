using cn.bmob.io;
using cn.bmob.json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WoodenBench.TableObjects;
using WoodenBench.View;
using static WoodenBench.staClass.GlobalFunc;

namespace WoodenBench.staClass
{
    public class UserActivity
    {
        public enum UserGroupEnum
        {
            管理组用户,
            小学部_班主任,
            初中部_班主任,
            普通高中部_班主任,
            中加高中部_班主任,
            留学生部_班主任,
            剑桥高中部_班主任,
            校车管理老师,
            家长
        }
        public static bool ChangePassWord(AllUsersTable NowUser, string OriPasswrd, string NewPasswrd)
        {
            AllUsersTable Obj = new AllUsersTable()
            {
                objectId = NowUser.objectId,
                UserGroup = (int)NowUser.UserGroup,
                Password = NewPasswrd,
                UserName = NowUser.UserName
            };
            var Result = GlobalFunc.Bmob.UpdateTaskAsync(Obj);
            JObject JsonNowUsrResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(Result.Result));
            return true;
        }
        public static void LogOut()
        {
            CurrentUser = null;
            UsrLoginForm.Default.Show();
            MainWindow.Default.Close();
            ChangeUserData.Default.Close();
        }
        public static bool Login(string xUserName, string xPassword)
        {
            string StrObjectID;
            int UserGroup;
            string Password;
            bool WebNotiSeen;
            string WeChatID;
            string RealName;

            bool BRtn = false;
            BmobQuery UserNameQuery = new BmobQuery();
            UserNameQuery.WhereContainedIn("Username", xUserName);
            try
            {
                System.Threading.Tasks.Task<cn.bmob.response.QueryCallbackData<AllUsersTable>> UsrNameResult;
                UsrNameResult = GlobalFunc.Bmob.FindTaskAsync<AllUsersTable>(GlobalFunc.TABLE_N_Gen_AllUsr, UserNameQuery);
                UsrNameResult.Wait();
                JToken JsonUserNameResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(UsrNameResult.Result))["results"].First;

                WebNotiSeen = Convert.ToBoolean(JsonUserNameResult["WebNotiSeen"].ToString());
                StrObjectID = JsonUserNameResult["objectId"].ToString();
                Password = JsonUserNameResult["Password"].ToString();
                UserGroup = Convert.ToInt32(JsonUserNameResult["UsrGroup"].ToString());
                WeChatID = JsonUserNameResult["WeChatID"].ToString();
                RealName = JsonUserNameResult["RealName"].ToString();

                AllUsersTable FoundUser = new AllUsersTable()
                {
                    objectId = StrObjectID,
                    Password = Password,
                    UserName = xUserName,
                    UserGroup = UserGroup,
                    LastLoginTime = DateTime.Now,
                    WeChatID = WeChatID,
                };

                if (FoundUser.Password == xPassword)
                {
                    CurrentUser = FoundUser;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                DebugMessage(e);
                DebugMessage(e.InnerException);
                return false;
            }
        }
    }
}
