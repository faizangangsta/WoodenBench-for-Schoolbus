using cn.bmob.io;
using cn.bmob.json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WoodenBench.DelegateClasses;
using WoodenBench.Events;
using WoodenBench.StaClasses;
using WoodenBench.TableObject;
using WoodenBench.Views;
using static WoodenBench.StaClasses.GlobalFunc;

namespace WoodenBench.Users
{
    public class _UserActivity
    {
        public static event onUserActivityHandler onUserActivityEvent;
        protected static void _ChangePassWord(AllUserObject NowUser, string OriPasswrd, string NewPasswrd)
        {
            AllUserObject Change = new AllUserObject();
            Change.Password = NewPasswrd;
            _BmobWin.Update(TABLE_N_Gen_UsrTable, NowUser.objectId, Change, (resp, exception) =>
            {
                if (exception != null)
                {
                    onUserActivity(UserActivityEnum.UserChangePassword, null, ProcStatusEnum.FailedWithErr, Detail: exception.Message);
                }
                else
                {
                    onUserActivity(UserActivityEnum.UserChangePassword, null, ProcStatusEnum.Completed);
                }
            });
        }

        protected static void _LogOut()
        {
            CurrentUser = null;
            GC.Collect();
            onUserActivity(UserActivityEnum.UserLogOff, CurrentUser, ProcStatusEnum.Completed);
        }

        protected static void _Login(string xUserName, string xPassword, bool OnlyVerify, string RealN = "")
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
                    if (OnlyVerify)
                    {
                        if (FoundUser.RealName == RealN)
                        {
                            onUserActivity(UserActivityEnum.UserCompare, null, ProcStatusEnum.Completed);
                        }
                        else
                        {
                            onUserActivity(UserActivityEnum.UserCompare, null, ProcStatusEnum.Failed, Detail: "RealName Doesn't Match");
                        }
                    }
                    else
                    {
                        CurrentUser = FoundUser;
                        onUserActivity(UserActivityEnum.UserLogin, CurrentUser, ProcStatusEnum.Completed);
                    }
                }
                else
                {
                    onUserActivity(UserActivityEnum.UserLogin, CurrentUser, ProcStatusEnum.Failed, Detail: "PsWd Wrong");
                }
            }
            catch (Exception e)
            {
                DebugMessage(e);
                DebugMessage(e.InnerException);
                onUserActivity(UserActivityEnum.UserLogin, null, ProcStatusEnum.FailedWithErr, Detail: e.Message);
            }
        }

        private static void onUserActivity(UserActivityEnum Act, AllUserObject AChange, ProcStatusEnum Status, string Detail = "")
        {
            UserActivityEventArgs e = new UserActivityEventArgs()
            {
                Activity = Act,
                AfterChange = AChange,
                ProcessStatus = Status,
                Describe = Detail
            };
            if (onUserActivityEvent != null) { onUserActivityEvent(e); }
            e = null;
        }
    }
}
