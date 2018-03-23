using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using WBServicePlatform.StaticClasses;

namespace WBServicePlatform.WebManagement.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel(HttpResponse Resp, MyError errType)
        {
            Responce = Resp;
            if (Resp.StatusCode == 404) errType = errType == 0 ? MyError.N10_Normal404Error : errType;
            else if (Resp.StatusCode.ToString().StartsWith("5")) errType = errType == 0 ? MyError.N11_Server5xxError : errType;

            switch (errType)
            {
                case MyError.N01_InternalError:
                    MainTitle = "内部错误";
                    MinorDescription = "程序内部问题";
                    break;
                case MyError.N99_UnknownError:
                    MainTitle = "未知错误";
                    MinorDescription = "我们也不知道是什么问题";
                    break;
                case MyError.N03_ItemsNotFoundError:
                    MainTitle = "找不到请求的内容";
                    MinorDescription = "后台处理程序找不到指定的项";
                    break;
                case MyError.N04_RequestIllegalError:
                    MainTitle = "请求非法";
                    MinorDescription = "请重试请求";
                    break;
                case MyError.N05_PermissionDeniedError:
                    MainTitle = "请求被驳回";
                    MinorDescription = "权限不足，无法完成此操作";
                    break;
                case MyError.N06_UserGroupError:
                    MainTitle = "用户组错误";
                    MinorDescription = "你的用户组限制了你的本次操作";
                    break;
                case MyError.N07_NoDirectAccessError:
                    MainTitle = "访问错误";
                    MinorDescription = "你不能直接访问本页面，请跟随指引操作";
                    break;
                case MyError.N08_WeChatLoginRequestError:
                    MainTitle = "微信登录请求错误";
                    MinorDescription = "在处理微信登录请求时出现问题";
                    break;
                case MyError.N09_WeChatLoginResponceError:
                    MainTitle = "微信登陆处理错误";
                    MinorDescription = "在尝试使用微信账户登陆时发生错误";
                    break;
                case MyError.N10_Normal404Error:
                    MainTitle = "404……";
                    MinorDescription = "您所查找的文件或资源不存在（认真脸）🌚。。。";
                    break;
                case MyError.N11_Server5xxError:
                    MainTitle = "问题中的问题……";
                    MinorDescription = "我们在显示上一个问题时出现错误😭。。。";
                    break;
                default:
                    MainTitle = "你不应该看见这一行文字";
                    MinorDescription = "这一行文字本应该在内部被重载";
                    break;
            }
        }
        public HttpResponse Responce;
        public string RequestId { get; set; }
        public string OtherInfo { get; set; }
        public string MainTitle { get; set; }
        public string MinorDescription { get; set; }
        public ErrorViewModel SetProperty(string ReqID, string Otherinfo)
        {
            OtherInfo = Otherinfo;
            RequestId = ReqID;
            return this;
        }
    }
}