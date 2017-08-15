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
using System.Windows.Forms;
using WoodenBench.DelegateClasses;
using WoodenBench.StaClasses;
using WoodenBench.TableObject;
using WoodenBench.Views;
using static WoodenBench.StaClasses.GlobalFunc;

namespace WoodenBench.Users
{
    partial class UserActivity
    {
        private static void _ChangePsW(AllUserObject NowUser, string OriPasswrd, string NewPasswrd)
        {
            AllUserObject Change = new AllUserObject();
            Change.Password = NewPasswrd;
            _BmobWin.Update(Consts.TABLE_N_Gen_UsrTable, NowUser.objectId, Change, (resp, exception) =>
            {
                if (exception != null)
                {
                    onUserActivity(UsrActvtiE.UserChangePassword, null, ProcStatE.FailedWithErr, Detail: exception.Message);
                }
                else
                {
                    onUserActivity(UsrActvtiE.UserChangePassword, null, ProcStatE.Completed);
                }
            });
        }

        private static void _LogOut()
        {
            CurrentUser.SetEveryThingNull(); ;
            GC.Collect();
            onUserActivity(UsrActvtiE.UserLogOff, CurrentUser, ProcStatE.Completed);
        }

        private static void _UserChangeHeadImage(Image newImage, string UserName)
        {
            Bitmap p = new Bitmap(newImage);
            MemoryStream ms = new MemoryStream();
            p.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] ImageBytes = ms.GetBuffer();
            ms.Close();

            var ffuture = _BmobWin.FileUploadTaskAsync(new BmobLocalFile(ImageBytes, UserName + DateTime.Now + ".png"));
        }

        private static void _Login(string xUserName, string xPassword, bool OnlyVerify, string RealN = "")
        {
            string HashedPs = CryptoGraphy.SHA256Encrypt(xPassword);
            BmobQuery UserNameQuery = new BmobQuery();
            UserNameQuery.WhereContainedIn("Username", xUserName);
            try
            {
                System.Threading.Tasks.Task<QueryCallbackData<AllUserObject>> UsrNameResult;
                UsrNameResult = GlobalFunc._BmobWin.FindTaskAsync<AllUserObject>(Consts.TABLE_N_Gen_UsrTable, UserNameQuery);
                UsrNameResult.Wait();
                if (UsrNameResult.Result.results.Count <= 0)
                {
                    onUserActivity(UsrActvtiE.UsrLogin, CurrentUser, ProcStatE.Failed, Detail: "PsWd Wrong");
                }
                AllUserObject FoundUser = UsrNameResult.Result.results[0];
                if (FoundUser.Password == HashedPs)
                {
                    if (OnlyVerify)
                    {
                        if (FoundUser.RealName == RealN)
                        {
                            onUserActivity(UsrActvtiE.UserCompare, null, ProcStatE.Completed);
                        }
                        else
                        {
                            onUserActivity(UsrActvtiE.UserCompare, null, ProcStatE.Failed, Detail: "RealName Doesn't Match");
                        }
                    }
                    else
                    {
                        CurrentUser = FoundUser;
                        onUserActivity(UsrActvtiE.UsrLogin, CurrentUser, ProcStatE.Completed);
                    }
                }
                else onUserActivity(UsrActvtiE.UsrLogin, CurrentUser, ProcStatE.Failed, Detail: "PsWd Wrong");
            }
            catch (Exception e)
            {
                DebugMessage(e);
                DebugMessage(e.InnerException);
                onUserActivity(UsrActvtiE.UsrLogin, null, ProcStatE.FailedWithErr, Detail: e.Message);
            }
        }

        private static void _Create(string Username, string Realname, string Password, int UserGroup)
        {

        }

        private static void onUserActivity(UsrActvtiE Act, AllUserObject AChange, ProcStatE Status, string Detail = "")
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
