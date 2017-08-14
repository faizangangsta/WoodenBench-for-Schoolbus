using cn.bmob.io;
using cn.bmob.json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WoodenBench.DelegateClasses;
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
            _BmobWin.Update(Consts.TABLE_N_Gen_UsrTable, NowUser.objectId, Change, (resp, exception) =>
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
            CurrentUser.SetEveryThingNull(); ;
            GC.Collect();
            onUserActivity(UserActivityEnum.UserLogOff, CurrentUser, ProcStatusEnum.Completed);
        }

        protected static void _UserChangeHeadImage(Image newImage, string UserName)
        {
            Bitmap p = new Bitmap(newImage);
            MemoryStream ms = new MemoryStream();
            p.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] ImageBytes = ms.GetBuffer();
            ms.Close();

            var ffuture = _BmobWin.FileUploadTaskAsync(new BmobLocalFile(ImageBytes, UserName + DateTime.Now + ".png"));
        }

        protected static void _Login(string xUserName, string xPassword, bool OnlyVerify, string RealN = "")
        {
            string HashedPs = CryptoGraphy.SHA256Encrypt(xPassword);

            BmobQuery UserNameQuery = new BmobQuery();
            UserNameQuery.WhereContainedIn("Username", xUserName);
            try
            {

                System.Threading.Tasks.Task<cn.bmob.response.QueryCallbackData<AllUserObject>> UsrNameResult;
                UsrNameResult = GlobalFunc._BmobWin.FindTaskAsync<AllUserObject>(Consts.TABLE_N_Gen_UsrTable, UserNameQuery);
                UsrNameResult.Wait();
                JToken JsonUsrResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(UsrNameResult.Result))["results"].First;

                string StrObjectID = JsonUsrResult["objectId"].ToString();
                //UserName doesn't need 
                string Password = JsonUsrResult["Password"].ToString();
                string RealName = JsonUsrResult["RealName"].ToString();                
                string RealPassword = JsonUsrResult["RealPasswrord"].ToString();
                int UserGroup = Convert.ToInt32(JsonUsrResult["UsrGroup"].ToString());
                bool WebNotiSeen = Convert.ToBoolean(JsonUsrResult["WebNotiSeen"].ToString());
                string WeChatID = JsonUsrResult["WeChatID"].ToString();
                string HeadImageURL = JsonUsrResult[""].ToString();

                AllUserObject FoundUser = new AllUserObject()
                {
                    objectId = StrObjectID,
                    UserName = xUserName,
                    Password = Password,
                    RealName = RealName,
                    UserGroup = (UserGroupEnum)UserGroup,
                    WebNotiSeen = WebNotiSeen,
                    WeChatID = WeChatID,
                    RealPassword = RealPassword,
                    //UserImage = new BmobFile()
                    //{
                    //    url = HeadImageURL,
                    //    filename = "p",
                    //}
                };

                if (FoundUser.Password == HashedPs)
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
    public class UserActivityEventArgs : EventArgs
    {
        public UserActivityEventArgs() { }
        public ProcStatusEnum ProcessStatus { get; set; }
        public UserActivityEnum Activity { get; set; }
        public AllUserObject AfterChange { get; set; }
        public string Describe { get; set; }
    }
}
