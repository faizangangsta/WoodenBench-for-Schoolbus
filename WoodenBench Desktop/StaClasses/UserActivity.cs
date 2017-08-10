﻿using cn.bmob.io;
using cn.bmob.json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WoodenBench.TableObject;
using WoodenBench.Views;
using static WoodenBench.StaClasses.GlobalFunc;
using static WoodenBench.TableObject.AllUserObject;

namespace WoodenBench.StaClasses
{
    public class UserActivity
    {

        public static bool ChangePassWord(AllUserObject NowUser, string OriPasswrd, string NewPasswrd)
        {
            AllUserObject Change = new AllUserObject();
            Change.Password = NewPasswrd;
            _BmobWin.Update(TABLE_N_Gen_UsrTable, NowUser.objectId, Change, (resp, exception) =>
            {
                if (exception != null)
                {
                    MessageBox.Show("修改失败, 失败原因为： " + exception.Message);
                    DebugMessage(exception.Message);
                    return;
                }
                else
                {
                    MessageBox.Show($"为重载用户配置，当前用户 {CurrentUser.RealName} 将被注销，请重新登陆");
                }
            });
            return true;
        }

        public static void LogOut()
        {
            UsrLoginWindow.Default.Show();
            MainWindow.Default.Close();
            ChangeUserDataWindow.Default.Close();
            CurrentUser = null;
            GC.Collect();
        }

        public static bool Login(string xUserName, string xPassword, bool OnlyVerify, string RealN = "")
        {
            string StrObjectID;
            string Password;
            string RealName;
            int UserGroup;
            bool WebNotiSeen;
            string WeChatID;

            BmobQuery UserNameQuery = new BmobQuery();
            UserNameQuery.WhereContainedIn("Username", xUserName);
            try
            {
                System.Threading.Tasks.Task<cn.bmob.response.QueryCallbackData<AllUserObject>> UsrNameResult;
                UsrNameResult = GlobalFunc._BmobWin.FindTaskAsync<AllUserObject>(GlobalFunc.TABLE_N_Gen_UsrTable, UserNameQuery);
                UsrNameResult.Wait();
                JToken JsonUsrResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(UsrNameResult.Result))["results"].First;

                StrObjectID = JsonUsrResult["objectId"].ToString();
                //UserName doesn't need 
                Password = JsonUsrResult["Password"].ToString();
                RealName = JsonUsrResult["RealName"].ToString();
                UserGroup = Convert.ToInt32(JsonUsrResult["UsrGroup"].ToString());
                WebNotiSeen = Convert.ToBoolean(JsonUsrResult["WebNotiSeen"].ToString());
                WeChatID = JsonUsrResult["WeChatID"].ToString();

                AllUserObject FoundUser = new AllUserObject()
                {
                    objectId = StrObjectID,
                    UserName = xUserName,
                    Password = Password,
                    RealName = RealName,
                    UserGroup = (UserGroupEnum)UserGroup,
                    WebNotiSeen = WebNotiSeen,
                    WeChatID = WeChatID
                };

                if (FoundUser.Password == xPassword)
                {
                    if (OnlyVerify) return FoundUser.RealName == RealN;
                    else
                    {
                        CurrentUser = FoundUser;
                        return true;
                    }
                }
                return false;
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