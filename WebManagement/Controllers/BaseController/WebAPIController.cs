using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WBPlatform.WebManagement.Controllers
{
    public class WebAPIController : BaseController
    {
        public static Dictionary<string, string> SpecialisedInfo(string Message) => new Dictionary<string, string> { { "ErrCode", "0" }, { "ErrMessage", Message } };
        public static Dictionary<string, string> SessionError { get; } = new Dictionary<string, string> { { "ErrCode", "1" }, { "ErrMessage", "Session Invalid" } };
        public static Dictionary<string, string> DataBaseError { get; } = new Dictionary<string, string> { { "ErrCode", "995" }, { "ErrMessage", "Database Error" } };
        public static Dictionary<string, string> UserGroupError { get; } = new Dictionary<string, string> { { "ErrCode", "996" }, { "ErrMessage", "UserGroupError" } };
        public static Dictionary<string, string> InternalError { get; } = new Dictionary<string, string> { { "ErrCode", "997" }, { "ErrMessage", "Internal Error" } };
        public static Dictionary<string, string> SpecialisedError(string Message) => new Dictionary<string, string> { { "ErrCode", "998" }, { "ErrMessage", Message } };
        public static Dictionary<string, string> RequestIllegal { get; } = new Dictionary<string, string> { { "ErrCode", "999" }, { "ErrMessage", "Request Illegal" } };
    }
}
