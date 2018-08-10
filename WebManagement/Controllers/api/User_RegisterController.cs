using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/users/Register")]
    public class User_RegisterController : APIController
    {
        [HttpPost]
        public JsonResult POST()
        {
            FormCollection myform = (FormCollection)Request.Form;
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var item in myform)
            {
                dict.Add(item.Key, item.Value[0]);
            }
            if (!string.IsNullOrEmpty(dict["UserName"]))
            {
                if (dict.ContainsKey("Password"))
                {
                    if (ValidateSession())
                    {
                        string password = Cryptography.SHA256Encrypt(dict["Password"]);
                        if (CurrentUser.UserName == dict["UserName"])
                        {
                            CurrentUser.Password = password;
                            var temp = CurrentUser;
                            if (DataBaseOperation.UpdateData(ref temp) == DBQueryStatus.ONE_RESULT)
                            {
                                Response.Redirect("/Home");
                                return SpecialisedInfo("OK");
                            }
                            else return DataBaseError;
                        }
                        else return RequestIllegal;
                    }
                    else return SessionError;
                }
                else
                {
                    UserObject user = new UserObject()
                    {
                        UserName = dict["UserName"],
                        RealName = dict["RealName"],
                        Sex = dict["Sex"],
                        PhoneNumber = dict["PhoneNumber"]
                    };
                    if (DataBaseOperation.CreateData(ref user) == DBQueryStatus.ONE_RESULT)
                    {
                        MessagingSystem.AddMessageProcesses(new InternalMessage() { User = user, _Type = GlobalMessageTypes.User__Pending_Verify, DataObject = dict["table"] });
                        Response.Redirect("/Home");
                        return SpecialisedInfo("OK");
                    }
                    else
                    {
                        Response.Redirect("/Home/Error");
                        return InternalError;
                    }
                }
            }
            else return RequestIllegal;
        }

        [HttpGet]
        public JsonResult GET(string userId, string mode)
        {
            //Response.Redirect("/Error");
            if (ValidateSession())
            {
                if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(mode)) return RequestIllegal;
                if (userId != CurrentUser.ObjectId) return RequestIllegal;
                switch (mode)
                {
                    case "true":
                        //Create Password
                        if (!string.IsNullOrWhiteSpace(CurrentUser.Password))
                        {
                            return RequestIllegal;
                        }
                        else
                        {
                            string token = OnePassTicket.CreateTicket();
                            OnePassTicket.TryAdd(token, new TicketInfo(TicketUsage.AddPassword, Request.Headers["User-Agent"], CurrentUser.UserName, 600));
                            return SpecialisedInfo(token);
                        }
                    case "false":
                        //Register User....
                        if (string.IsNullOrEmpty(CurrentUser.Password))
                        {
                            return RequestIllegal;
                        }
                        else
                        {
                            string token = OnePassTicket.CreateTicket();
                            OnePassTicket.TryAdd(token, new TicketInfo(TicketUsage.UserRegister, Request.Headers["User-Agent"], CurrentUser.UserName, 600));
                            return SpecialisedInfo(token);
                        }
                    default: return RequestIllegal;
                }
            }
            else return SessionError;
        }
    }
}
