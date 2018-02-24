using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WBServicePlatform.WebManagement.Controllers;

namespace WBServicePlatform.WebAPIServices.Controllers
{
    [Produces("application/json")]
    [Route("api/wx/getAccessToken")]
    public class wc_getAccessTokenController : Controller
    {

        public IEnumerable Get(string CorpID, string CorpSecret)
        {
            string options = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=" + CorpID + "&corpsecret=" + CorpSecret;

            Dictionary<string, string> JSON = HTTPJsonOperations.HTTPJsonGet(options); ;

            if (JSON != null && JSON.ContainsKey("access_token"))
            {
                byte[] bytes = Encoding.Default.GetBytes(JSON["access_token"] + JSON["errcode"] + JSON["expires_in"]);
                string str = Convert.ToBase64String(bytes);
                JSON["access_token"] = str;
            }
            else
            {
                JSON = new Dictionary<string, string>
                {
                    { "errcode", "40002" },
                    { "errmsg", "Wrong CorpID and CorpSecret Offered" }
                };
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            return JSON;
        }
    }

    [Produces("application/json")]
    [Route("api/wx/getTicket")]
    public class wc_getTicketController : Controller
    {
        public IEnumerable Get(string AccessToken)
        {
            string options = "https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token=" + AccessToken;

            Dictionary<string, string> JSON = HTTPJsonOperations.HTTPJsonGet(options);

            if (JSON != null && JSON.ContainsKey("ticket"))
            {
                byte[] bytes = Encoding.Default.GetBytes(JSON["ticket"] + JSON["errcode"] + JSON["expires_in"]);
                string str = Convert.ToBase64String(bytes);
                JSON["ticket"] = str;
            }
            else
            {
                JSON = new Dictionary<string, string>
                {
                    { "errcode", "40003" },
                    { "errmsg", "Wrong Token Value" }
                };
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            return JSON;
        }
    }

    [Produces("application/json")]
    [Route("api/wx/getUserInfo")]
    public class wc_UserInfoController : Controller
    {
        public IEnumerable Get(string AccessToken, string Code)
        {
            string options = "https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token=" + AccessToken + "&code=" + Code;
            Dictionary<string, string> JSON = HTTPJsonOperations.HTTPJsonGet(options);

            if (JSON != null && JSON.ContainsKey("UserId"))
            {
                byte[] bytes = Encoding.Default.GetBytes(JSON["user_ticket"] + JSON["errcode"]);
                string str = Convert.ToBase64String(bytes);
                JSON["user_ticket"] = str;
            }
            return JSON;
        }
    }


    [Produces("application/json")]
    [Route("api/wx/getUserDInfo")]
    public class wc_UserDetailInfoController : Controller
    {
        public IEnumerable Get(string AccessToken, string UserTicket)
        {
            string options = "https://qyapi.weixin.qq.com/cgi-bin/user/getuserdetail?access_token=" + AccessToken;
            string PostData = SimpleJson.SimpleJson.SerializeObject(new Dictionary<string, string>(1) { { "user_ticket", UserTicket } });
            return HTTPJsonOperations.HTTPJsonPost(options, PostData);
        }
    }
}
