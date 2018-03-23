using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBServicePlatform.StaticClasses;

namespace WBServicePlatform.WebManagement.Controllers
{
    public abstract class MyController : Controller
    {
        public abstract IActionResult Index();
        protected IActionResult _LoginFailed(string ReDirectTo)
        {
            Response.Cookies.Delete("Session");
            Response.Cookies.Append("LoginRedirect", ReDirectTo, new CookieOptions() { Expires = DateTime.Now.AddMinutes(2) });
            return RedirectToAction("LoginFailed", AccountController.ControllerName);
        }
        protected IActionResult _ErrorRedirect(MyError error, string errmsg = null)
        {
            return Redirect("/Home/Error?err=" + (int)error + (errmsg == null ? "" : "&errmsg=" + errmsg));
        }
    }
}
