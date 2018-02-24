using cn.bmob.io;
using cn.bmob.json;
using cn.bmob.response;
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
using System.Threading.Tasks;
using System.Windows.Forms;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WinClient.DelegateClasses;
using WBServicePlatform.WinClient.StaticClasses;
using WBServicePlatform.WinClient.Views;
using static WBServicePlatform.WinClient.StaticClasses.GlobalFunc;

namespace WBServicePlatform.WinClient.Users
{
    public partial class UserActivity
    {

        public static event UserActivityHandler onUserActivityEvent;

        public static void LogOut()
        {
            new Thread(new ThreadStart(delegate { _LogOut(); })) { Name = "User Logoff", IsBackground = false }.Start();
        }

        public static void ChangePassWord(AllUserObject NowUser, string OriPasswrd, string NewPasswrd)
        {
            new Thread(new ThreadStart(delegate { _ChangePsW(NowUser, OriPasswrd, NewPasswrd); }))
            { Name = "User Change Password", IsBackground = false }.Start();
        }

        public static void Login(string xUserName, string xPassword, bool OnlyVerify, string RealN = "")
        {
            new Thread(new ThreadStart(delegate { _Login(xUserName, xPassword, OnlyVerify, RealN); }))
            { Name = "User Login", IsBackground = false }.Start();

        }

        public static void CreateUser(string Username, string Realname, string Password, UserGroup UserGroup, string PhoneNumber)
        {
            new Thread(new ThreadStart(delegate { _Create(Username, Realname, Password, UserGroup, PhoneNumber); }))
            { Name = "User Creation", IsBackground = false }.Start();
        }

        #region Private Operaitons
        private static void _ChangePsW(AllUserObject NowUser, string OriPasswrd, string NewPasswrd)
        {
            AllUserObject Change = new AllUserObject();
            Change.Password = Crypto.SHA256Encrypt(NewPasswrd);
            _BmobWin.Update(Consts.TABLE_N_Gen_UserTable, NowUser.objectId, Change, (resp, exception) =>
            {
                if (exception != null)
                    onUserActivity(OperationStatus.Failed, UsrActvtiE.UserChangePassword, Detail: exception.Message);
                else
                    onUserActivity(OperationStatus.Completed, UsrActvtiE.UserChangePassword, null);
            });
        }

        private static void _LogOut()
        {
            //CurrentUser.SetEveryThingNull(); ;
            GC.Collect();
            onUserActivity(OperationStatus.Completed, UsrActvtiE.UserLogOff);
        }

        /*private static void _UserChangeHeadImage(Image newImage, string UserName)
        {
            Bitmap p = new Bitmap(newImage);
            MemoryStream ms = new MemoryStream();
            p.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] ImageBytes = ms.GetBuffer();
            ms.Close();

            var ffuture = _BmobWin.FileUploadTaskAsync(new BmobLocalFile(ImageBytes, UserName + "-" + DateTime.Now + "-HeadImage.png"));
            ffuture.Wait();
            if (ffuture.Status == TaskStatus.Faulted)
            {
                onUserActivity(ProcStatE.FailedWithErr, UsrActvtiE.UserUploadHImage, null);
            }
            else if (ffuture.Status == TaskStatus.RanToCompletion)
            {
                CurrentUser.HeadImgData = ffuture.Result;
                CurrentUser.UserImage = newImage;
                onUserActivity(ProcStatE.Completed, UsrActvtiE.UserUploadHImage);
            }
            else
            {
                onUserActivity(ProcStatE.Unknown, UsrActvtiE.UserUploadHImage, null);
            }
        }
        */

        private static void _Login(string xUserName, string xPassword, bool OnlyVerify, string RealN = "")
        {
            xUserName = xUserName.ToLower();
            string HashedPs = Crypto.SHA256Encrypt(xPassword);
            BmobQuery UserNameQuery = new BmobQuery();
            UserNameQuery.WhereContainedIn("Username", xUserName);
            try
            {
                Task<QueryCallbackData<AllUserObject>> UsrNameResult;
                UsrNameResult = GlobalFunc._BmobWin.FindTaskAsync<AllUserObject>(Consts.TABLE_N_Gen_UserTable, UserNameQuery);
                UsrNameResult.Wait();
                if (UsrNameResult.Result.results.Count <= 0) onUserActivity(OperationStatus.Failed, UsrActvtiE.UsrLogin, Detail: "Username Wrong");

                AllUserObject FoundUser = UsrNameResult.Result.results[0];
                if (FoundUser.Password == HashedPs)
                {
                    if (OnlyVerify)
                    {
                        if (FoundUser.RealName == RealN) onUserActivity(OperationStatus.Completed, UsrActvtiE.UserCompare, null);
                        else onUserActivity(OperationStatus.Failed, UsrActvtiE.UserCompare, Detail: "Realname Wrong");
                    }
                    else
                    {
                        CurrentUser = FoundUser;
                        onUserActivity(OperationStatus.Completed, UsrActvtiE.UsrLogin);
                    }
                }
                else onUserActivity(OperationStatus.Failed, UsrActvtiE.UsrLogin, Detail: "Password Wrong");
            }
            catch (Exception e)
            {
                onUserActivity(OperationStatus.Failed, UsrActvtiE.UsrLogin, Detail: e.Message);
            }
        }

        private static void _Create(string Username, string Realname, string Password, UserGroup UserGroup, string phoneNumber)
        {
            Username = Username.ToLower();
            Password = Crypto.SHA256Encrypt(Password);
            AllUserObject NewUserObj = new AllUserObject
            {
                UserName = Username,
                RealName = Realname,
                WebNotiSeen = false,
                WeChatID = "####",
                Password = Password,
                UserGroup = UserGroup,
                FirstLogin = true,
                HeadImagePath = "#",
                PhoneNumber = phoneNumber
            };
            Task<CreateCallbackData> task = _BmobWin.CreateTaskAsync(Consts.TABLE_N_Gen_UserTable, NewUserObj);
            try
            {
                task.Wait();
                if (task.Status == TaskStatus.RanToCompletion && task.Exception == null && task.IsCompleted)
                    onUserActivity(OperationStatus.Completed, UsrActvtiE.UserCreate, "Success " + task.Result.createdAt);
            }
            catch (Exception ex)
            {
                onUserActivity(OperationStatus.Failed, UsrActvtiE.UserCreate, ex.InnerException.Message);
            }
        }

        private static void onUserActivity(OperationStatus Status, UsrActvtiE Act, string Detail = "")
        {
            UserActivityEventArgs e = new UserActivityEventArgs()
            {
                Activity = Act,
                ProcessStatus = Status,
                ErrDescription = Detail
            };
            if (onUserActivityEvent != null) onUserActivityEvent(e);
            e = null;
            GC.Collect();
        }
        #endregion
    }

    public class UserActivityEventArgs : InternalEventArgs
    {
        public UserActivityEventArgs() { }
        public UsrActvtiE Activity { get; set; }
    }
}
