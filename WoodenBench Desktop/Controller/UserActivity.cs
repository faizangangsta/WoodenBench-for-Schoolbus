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
using WoodenBench_Desktop.TableObjects;

namespace WoodenBench_Desktop.staClass
{
    public class UserActivity
    {
        public static UserTableObj NowUser;
        public static bool ChangePassWord(UserTableObj NowUser, string OriPasswrd, string NewPasswrd)
        {
            UserTableObj Obj = new UserTableObj(Consts.TABLE_NAME_General_AllUser)
            {
                objectId = NowUser.UserID,
                CUserGroup = (int)NowUser.UserGroup,
                Password = NewPasswrd,
                UserName = NowUser.UserName
            };
            var Result = BmobObject.Bmob.UpdateTaskAsync(Obj);
            JObject JsonNowUsrResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(Result.Result));
            return true;
        }
        public static void LogOut()
        {
            NowUser = null;
            UsrLoginForm.Default.Show();
            MainWindow.Default.Close();
            ChangeUserData.Default.Close();
        }
        public static bool Login(string UserName, string Password)
        {
            string StrObjectID;
            int UserGroup;

            BmobQuery UserNameQuery = new BmobQuery();
            UserNameQuery.WhereContainedIn("Username", UserName);

            
            BmobObject.Bmob.Find<UserTableObj>(Consts.TABLE_NAME_General_AllUser, UserNameQuery, (resp, exception) =>
            {
                if (exception != null)
                {
                    //("查询失败, 失败原因为： " + exception.Message);
                    return;
                }

                //对返回结果进行处理
                List<UserTableObj> list = resp.results;
                foreach (var game in list)
                {
                    MessageBox.Show(game.ToString());
                    //print("获取的对象为： " + game.ToString());
                }
            });



            var UsrNameResult = staClass.BmobObject.Bmob.FindTaskAsync<UserTableObj>(Consts.TABLE_NAME_General_AllUser, UserNameQuery);
            JObject JsonUserNameResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(UsrNameResult.Result));
            JToken StuJObj = JsonUserNameResult["results"].First;
            StrObjectID = StuJObj["objectId"].ToString();
            Password = StuJObj["Password"].ToString();

            UserGroup = Convert.ToInt32(StuJObj["UsrGroup"].ToString());
            UserTableObj NowUser = new UserTableObj()
            {
                Password = Password,
                UserID = StrObjectID,
                UserName = UserName,
                UserGroup = (UserGroupEnum)UserGroup,
                LoginTime = DateTime.Now.TimeOfDay.ToString()
            };
            staClass.UserActivity.NowUser = NowUser;
            return true;
        }
    }
}