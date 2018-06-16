using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using SimpleJson;
using WBPlatform.ServiceStatus.Models;

namespace WBPlatform.ServiceStatus
{
    public class HomeController : Controller
    {
        public static string ServerStatus { get; set; } = "";
        public IActionResult Index()
        {
            Dictionary<string, object> status = SimpleJson.SimpleJson.DeserializeObject<Dictionary<string, object>>(ServerStatus);
            ViewData["msg"] = ServerStatus;
            return View();
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
