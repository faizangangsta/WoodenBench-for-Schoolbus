using Microsoft.AspNetCore.Mvc;

using System;
using WBPlatform.StaticClasses;

namespace WBPlatform.WebManagement.Controllers
{
    public class APIController : BaseController
    {
        private class JsonResultEntity
        {
            public JsonResultEntity(int errCode, string errMessage)
            {
                ErrCode = errCode;
                ErrMessage = errMessage ?? throw new ArgumentNullException(nameof(errMessage));
            }

            public int  ErrCode { get; }
            public string ErrMessage { get; }
        }

        public JsonResult SessionError => Json(new JsonResultEntity(1, XConfig.Messages["SessionError"]));
        public JsonResult DataBaseError => Json(new JsonResultEntity(995, XConfig.Messages["DataBaseError"]));
        public JsonResult UserGroupError => Json(new JsonResultEntity(996, XConfig.Messages["UserPermissionDenied"]));
        public JsonResult RequestIllegal => Json(new JsonResultEntity(999, XConfig.Messages["RequestIllegal"]));
         
        public JsonResult SpecialisedInfo(string Message) => Json(new JsonResultEntity(0, Message));
        public JsonResult SpecialisedError(string Message) => Json(new JsonResultEntity(998, Message));

        public JsonResult InternalError => Json(new JsonResultEntity(-1, XConfig.Messages["UnknownInternalException"]));
    }
}
