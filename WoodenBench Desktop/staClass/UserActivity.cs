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
            班主任,
            校车管理老师,
            家长
        }
        public static bool ChangePassWord(AllUsersTable NowUser, string OriPasswrd, string NewPasswrd)
        {
            AllUsersTable game = new AllUsersTable();
            game.Password = NewPasswrd;
            Bmob.Update(TABLE_N_Gen_UsrTable, NowUser.objectId, game, (resp, exception) =>
            {
                if (exception != null)
                {
                    MessageBox.Show("修改失败, 失败原因为： " + exception.Message);
                    return;
                }
            });
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
            string Password;
            string RealName;
            int UserGroup;
            bool WebNotiSeen;
            string WeChatID;

            bool BRtn = false;
            BmobQuery UserNameQuery = new BmobQuery();
            UserNameQuery.WhereContainedIn("Username", xUserName);
            try
            {
                System.Threading.Tasks.Task<cn.bmob.response.QueryCallbackData<AllUsersTable>> UsrNameResult;
                UsrNameResult = GlobalFunc.Bmob.FindTaskAsync<AllUsersTable>(GlobalFunc.TABLE_N_Gen_UsrTable, UserNameQuery);
                UsrNameResult.Wait();
                JToken JsonUsrResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(UsrNameResult.Result))["results"].First;

                WebNotiSeen = Convert.ToBoolean(JsonUsrResult["WebNotiSeen"].ToString());
                StrObjectID = JsonUsrResult["objectId"].ToString();
                Password = JsonUsrResult["Password"].ToString();
                UserGroup = Convert.ToInt32(JsonUsrResult["UsrGroup"].ToString());
                WeChatID = JsonUsrResult["WeChatID"].ToString();
                RealName = JsonUsrResult["RealName"].ToString();

                AllUsersTable FoundUser = new AllUsersTable()
                {
                    objectId = StrObjectID,
                    UserName = xUserName,
                    Password = Password,
                    RealName = RealName,
                    UserGroup = UserGroup,
                    WebNotiSeen = WebNotiSeen,
                    WeChatID = WeChatID
                };

                if (FoundUser.Password == xPassword)
                {
                    CurrentUser = FoundUser;
                    return true;
                }
                else return false;
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
