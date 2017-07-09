function InitWeixin(ForceRemote)
{
    var aTicket, aExpire;
    if (getSecKey("aTicket") === null || getSecKey("A%TKH$asH%CHecK%&") === null || getSecKey("aToken") === null)
    {
        setSecKey("aTicket", "nothing", 60);
        setSecKey("A%TKH$asH%CHecK%&", "nothing", 60);
        setSecKey("aToken", "nothing", 60);
        ForceRemote = true;
    }
    var flag = hex_md5((base64decode(utf8to16De(getSecKey("aTicket")))) + ";" + hex_sha1(base64decode(utf8to16De(getSecKey("aTicket")))));
    var flag2 = base64decode(utf8to16De(getSecKey("A%TKH$asH%CHecK%&")));
    if (ForceRemote || flag !== flag2)
    {
        console.log("Load WeChat Token From Remote Server..");
        Bmob.Cloud.run('GetWeChatTicket', {}, {
            success: function (result)
            {
                var TokenStr, TicketStr;
                TokenStr = result.split(";6666;")[0];
                TicketStr = result.split(";6666;")[1];
                var expiresT = JSON.parse(TicketStr)["expires_in"];
                aTicket = JSON.parse(TicketStr)["ticket"];
                aExpire = expiresT * 0.75;
                setSecKey("aToken", JSON.parse(TokenStr)["access_token"], aExpire - 400);
                setSecKey("aTicket", aTicket, aExpire);
                setSecKey("A%TKH$asH%CHecK%&", hex_md5(aTicket + ";" + hex_sha1(aTicket)), aExpire - 400);
                InitJSSDK(aTicket);
            }
        });
    }
    else
    {
        console.log("Load WeChat Token From Local Storage..");
        aTicket = base64decode(utf8to16De(getSecKey("aTicket")));
        InitJSSDK(aTicket);
    }
}

function randomString(len)
{
    len = len || 16;
    var $chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890';
    var maxPos = $chars.length;
    var pwd = "";
    for (i = 0; i < len; i++) pwd += $chars.charAt(Math.floor(Math.random() * maxPos));
    return pwd;
}

function InitJSSDK(ATicket)
{
    var appID = "wx68bec13e85ca6465";
    var nonceStr = randomString(32);
    var TimeStamp = new Date().getTime()
    var urlStr = location.href;
    //var urlStr = "http://lhy0403.iego.net/index.html";
    var strSHA1 = "jsapi_ticket=" + ATicket + "&noncestr=" + nonceStr + "&timestamp=" + TimeStamp + "&url=" + urlStr;
    var signature = hex_sha1(strSHA1);
    wx.config({
        debug: true,
        appId: appID,
        timestamp: TimeStamp,
        nonceStr: nonceStr,
        signature: signature,
        jsApiList: [
            'checkJsApi',
            'onMenuShareTimeline',
            'onMenuShareAppMessage',
            'onMenuShareQQ',
            'onMenuShareWeibo',
            'onMenuShareQZone',
            'hideMenuItems',
            'showMenuItems',
            'hideAllNonBaseMenuItem',
            'showAllNonBaseMenuItem',
            'translateVoice',
            'startRecord',
            'stopRecord',
            'onVoiceRecordEnd',
            'playVoice',
            'onVoicePlayEnd',
            'pauseVoice',
            'stopVoice',
            'uploadVoice',
            'downloadVoice',
            'chooseImage',
            'previewImage',
            'uploadImage',
            'downloadImage',
            'getNetworkType',
            'openLocation',
            'getLocation',
            'hideOptionMenu',
            'showOptionMenu',
            'closeWindow',
            'scanQRCode',
            'chooseWXPay',
            'openProductSpecificView',
            'addCard',
            'chooseCard',
            'openCard'
        ]
    });
}

wx.error(function (res)
{
    if (res.errMsg.indexOf("invalid signature") > -1)
    {
        alert(res.errMsg.indexOf("invalid signature"));
        console.log("Signature Failed");
        InitWeixin(true);
    }
    else
    {
        alert(res.errMsg);
    }
    // config信息验证失败会执行error函数，如签名过期导致验证失败，具体错误信息可以打开config
    // 的debug模式查看，也可以在返回的res参数中查看，对于SPA可以在这里更新签名。
});

function JumpToWeChatLogin(State)
{
    var TimeStamp = new Date().getTime().toString() + ";" + State;
    setSecKey("WCLogin", TimeStamp, 300);
    var url = "https://open.weixin.qq.com/connect/oauth2/authorize?" +
        "appid=wx68bec13e85ca6465" +
        "&redirect_uri=http://lhy0403.imwork.net/schoolbusmgr/WeChatUserCodeReceiver.html" +
        "&response_type=code" +
        "&scope=snsapi_userinfo" +
        "&agentid=41" +
        "&state=" + TimeStamp +
        "#wechat_redirect";
    location.href = url;
}

function GetUserData(code, callback)
{
    var aToken = base64decode(utf8to16De(getSecKey("aToken")));
    Bmob.Cloud.run('GetUserInfo', {"token": aToken, "code": code}, {
        success: function (result)
        {
            var UTicket = JSON.parse(result)["user_ticket"];
            Bmob.Cloud.run('GetUserDetailInfo', {"token": aToken, "ticket": UTicket}, {
                success: function (result2)
                {
                    if (result2.indexOf("errmsg") === -1)
                    {
                        callback(result2);
                    }
                    else
                    {
                        $("#mainloginfailed").show();
                        $("#faileddetail").text("没能获取到你的信息，过会再试试吧");
                    }
                },
                error: function (error2)
                {
                    $("#mainloginfailed").show();
                    $("#faileddetail").text("没能获取到你的信息，过会再试试吧");
                }
            });
        },
        error: function (error)
        {
            $("#mainloginfailed").show();
            $("#faileddetail").text("没能获取到你的信息，过会再试试吧");
        }
    });
}
