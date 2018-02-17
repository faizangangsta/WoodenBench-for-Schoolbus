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
using WoodenBench.DelegateClasses;
using WoodenBench.StaticClasses;
using WoodenBench.TableObject;
using WoodenBench.Views;
using static WoodenBench.StaticClasses.GlobalFunc;

namespace WoodenBench.Users
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

        public static void CreateUser(string Username, string Realname, string Password, int UserGroup, bool isBusTeacher)
        {
            new Thread(new ThreadStart(delegate { _Create(Username, Realname, Password, UserGroup, isBusTeacher); }))
            { Name = "User Creation", IsBackground = false }.Start();
        }

        #region Private Operaitons
        private static void _ChangePsW(AllUserObject NowUser, string OriPasswrd, string NewPasswrd)
        {
            AllUserObject Change = new AllUserObject();
            Change.Password = Crypto.SHA256Encrypt(NewPasswrd);
            _BmobWin.Update(Consts.TABLE_N_Gen_UsrTable, NowUser.objectId, Change, (resp, exception) =>
            {
                if (exception != null)
                {
                    onUserActivity(ProcStatE.FailedWithErr, UsrActvtiE.UserChangePassword, Detail: exception.Message);
                }
                else
                {
                    onUserActivity(ProcStatE.Completed, UsrActvtiE.UserChangePassword, null);
                }
            });
        }

        private static void _LogOut()
        {
            CurrentUser.SetEveryThingNull(); ;
            GC.Collect();
            onUserActivity(ProcStatE.Completed, UsrActvtiE.UserLogOff);
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
                UsrNameResult = GlobalFunc._BmobWin.FindTaskAsync<AllUserObject>(Consts.TABLE_N_Gen_UsrTable, UserNameQuery);
                UsrNameResult.Wait();
                if (UsrNameResult.Result.results.Count <= 0) onUserActivity(ProcStatE.Failed, UsrActvtiE.UsrLogin, Detail: "Username Wrong");

                AllUserObject FoundUser = UsrNameResult.Result.results[0];
                if (FoundUser.Password == HashedPs)
                {
                    if (OnlyVerify)
                    {
                        if (FoundUser.RealName == RealN) onUserActivity(ProcStatE.Completed, UsrActvtiE.UserCompare, null);
                        else onUserActivity(ProcStatE.Failed, UsrActvtiE.UserCompare, Detail: "Realname Wrong");
                    }
                    else
                    {
                        CurrentUser = FoundUser;
                        onUserActivity(ProcStatE.Completed, UsrActvtiE.UsrLogin);
                    }
                }
                else onUserActivity(ProcStatE.Failed, UsrActvtiE.UsrLogin, Detail: "Password Wrong");
            }
            catch (Exception e)
            {
                LogWritter.ErrorMessage(e.Message);
                LogWritter.ErrorMessage(e.InnerException?.Message);
                onUserActivity(ProcStatE.FailedWithErr, UsrActvtiE.UsrLogin, Detail: e.Message, exception: e);
            }
        }

        private static void _Create(string Username, string Realname, string Password, int UserGroup, bool isBusTeacher)
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
                UserGroup = (UserGroupEnum)(UserGroup),
                isFstLogin = true,
                IsBusTeacher = isBusTeacher,
                HeadImgData = ""
            };
            Task<CreateCallbackData> task = _BmobWin.CreateTaskAsync(Consts.TABLE_N_Gen_UsrTable, NewUserObj);
            task.Wait();
            if (task.Status == TaskStatus.Faulted || task.IsFaulted)
            {
                if (task.Exception == null)
                {
                    onUserActivity(ProcStatE.Failed & ProcStatE.Unknown, UsrActvtiE.UserCreate, "Just Failed");
                }
                else if (task.Exception != null)
                {
                    onUserActivity(ProcStatE.FailedWithErr, UsrActvtiE.UserCreate, task.Exception.Message, task.Exception);
                }
            }
            else if (task.Status == TaskStatus.RanToCompletion && task.Exception == null && task.IsCompleted)
            {
                onUserActivity(ProcStatE.Completed, UsrActvtiE.UserCreate, "Success " + task.Result.createdAt);
            }
        }

        private static void onUserActivity(ProcStatE Status, UsrActvtiE Act, string Detail = "", Exception exception = null)
        {
            UserActivityEventArgs e = new UserActivityEventArgs()
            {
                Activity = Act,
                ProcessStatus = Status,
                Description = Detail,
                Exception = exception,

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
