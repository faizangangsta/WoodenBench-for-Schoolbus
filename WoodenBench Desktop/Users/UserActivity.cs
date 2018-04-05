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

        public static void ChangePassWord(UserObject NowUser, string OriPasswrd, string NewPasswrd)
        {
            new Thread(new ThreadStart(delegate { _ChangePsW(NowUser, OriPasswrd, NewPasswrd); }))
            { Name = "User Change Password", IsBackground = false }.Start();
        }

        public static void Login(string xUserName, string xPassword, bool OnlyVerify, string RealN = "")
        {
            new Thread(new ThreadStart(delegate { _Login(xUserName, xPassword, OnlyVerify, RealN); }))
            { Name = "User Login", IsBackground = false }.Start();

        }
        
        #region Private Operaitons
        private static void _ChangePsW(UserObject NowUser, string OriPasswrd, string NewPasswrd)
        {
            UserObject Change = new UserObject();
            Change.Password = Crypto.SHA256Encrypt(NewPasswrd);
            _BmobWin.Update(WBConsts.TABLE_N_Gen_UserTable, NowUser.objectId, Change, (resp, exception) =>
            {
                if (exception != null)
                    onUserActivity(OperationStatus.Failed, UserActivityE.ChangePassword, Detail: exception.Message);
                else
                    onUserActivity(OperationStatus.Completed, UserActivityE.ChangePassword, null);
            });
        }

        private static void _LogOut()
        {
            //CurrentUser.SetEveryThingNull(); ;
            GC.Collect();
            onUserActivity(OperationStatus.Completed, UserActivityE.Logout);
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
                Task<QueryCallbackData<UserObject>> UsrNameResult;
                UsrNameResult = GlobalFunc._BmobWin.FindTaskAsync<UserObject>(WBConsts.TABLE_N_Gen_UserTable, UserNameQuery);
                UsrNameResult.Wait();
                if (UsrNameResult.Result.results.Count <= 0) onUserActivity(OperationStatus.Failed, UserActivityE.Login, Detail: "Username Wrong");

                UserObject FoundUser = UsrNameResult.Result.results[0];
                if (FoundUser.Password == HashedPs)
                {
                    if (OnlyVerify)
                    {
                        if (FoundUser.RealName == RealN) onUserActivity(OperationStatus.Completed, UserActivityE.Compare, null);
                        else onUserActivity(OperationStatus.Failed, UserActivityE.Compare, Detail: "Realname Wrong");
                    }
                    else
                    {
                        CurrentUser = FoundUser;
                        onUserActivity(OperationStatus.Completed, UserActivityE.Login);
                    }
                }
                else onUserActivity(OperationStatus.Failed, UserActivityE.Login, Detail: "Password Wrong");
            }
            catch (Exception e)
            {
                onUserActivity(OperationStatus.Failed, UserActivityE.Login, Detail: e.Message);
            }
        }
        private static void onUserActivity(OperationStatus Status, UserActivityE Act, string Detail = "")
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
        public UserActivityE Activity { get; set; }
    }
}
