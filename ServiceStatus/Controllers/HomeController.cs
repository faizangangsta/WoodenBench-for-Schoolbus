using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WBPlatform.ServiceStatus.Models;

namespace WBPlatform.ServiceStatus
{
    public class HomeController : Controller
    {
        public static string ServerStatus { get; set; } = "{\"ReportTime\": \"Unknown\",  \"SessionsCount\": 0,  \"SessionThread\": false,  \"Tokens\": 0,  \"WeChatRCVDThreadStatus\": false,  \"WeChatSENTThreadStatus\": false,  \"WeChatRCVDListCount\": 0,  \"WeChatSENTListCount\": 0,  \"Database\": false,  \"CoreMessageSystemThread\": false,  \"CoreMessageSystemCount\": 0,  \"MessageBackupThread\": false,  \"MessageBackupCount\": 0,  \"StartupTime\": \"Unknown\",  \"ServerVer\": \"Unknown\",  \"CoreLibVer\": \"Unknown\",  \"NetCoreCLRVer\": \"Unknown\" }";
        public IActionResult Index()
        {
            Dictionary<string, object> status = JsonConvert.DeserializeObject<Dictionary<string, object>>(ServerStatus);
            ViewData["msg"] = ServerStatus;
            ViewData["parsedMsg"] = status;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
