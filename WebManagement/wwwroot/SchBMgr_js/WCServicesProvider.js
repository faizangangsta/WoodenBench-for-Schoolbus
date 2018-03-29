function InitWeixin(ForceRemote)
{
    "use strict";
    var aTokenStr, aTicket, aExpire;
    if (getCookie("aTicket") === null || getCookie("TicketHash") === null || getCookie("aToken") === null)
    {
        setCookie("aTicket", "nothing", 60);
        setCookie("TicketHash", "nothing", 60);
        setCookie("aToken", "nothing", 60);
        ForceRemote = true;
    }

    if (ForceRemote || hex_md5(getCookie("aTicket") + ";" + hex_sha1(getCookie("aToken"))) !== getCookie("TicketHash"))
    {
        console.log("Load WeChat Token From Remote Server..");
        // var CorpId = "wx68bec13e85ca6465";
        // var CorpSecret = "DatZ0P349SEAS-yDiqpHbb_3VR-kAnKtSaZj39KuWmhJqiiIjmW83LDpIvE49-Gt";
        $.ajax({
            url: location.protocol + "//" + location.host + "/api/wx/getAccessToken?" +
                "CorpID=" + CorpId +
                "&CorpSecret=" + CorpSecret,
            type: 'GET',
            success: function (data)
            {
                if (data.ErrCode !== "0")
                {
                    aTokenStr = data.access_token;
                    aTokenStr = base64decode(utf8to16De(aTokenStr));
                    aTokenStr = aTokenStr.substr(0, aTokenStr.length - 5);
                    $.ajax({
                        url: location.protocol + "//" + location.host + "/api/wx/getTicket?" +
                            "AccessToken=" + aTokenStr,
                        type: 'GET',
                        success: function (data2)
                        {
                            if (data2.ErrCode !== "0")
                            {
                                aTicket = data2.ticket;
                                aTicket = base64decode(utf8to16De(aTicket));
                                aTicket = aTicket.substr(0, aTicket.length - 5);
                                aExpire = data2.expires_in * 0.75;
                                setCookie("aToken", aTokenStr, aExpire - 400);
                                setCookie("aTicket", aTicket, aExpire);
                                setCookie("TicketHash", hex_md5(aTicket + ";" + hex_sha1(aTokenStr)), aExpire - 400);
                                InitJSSDK(aTicket);
                            }
                        },
                        error: function () { }
                    });
                }
            },
            error: function (err) { }
        });
    } else
    {
        console.log("Load WeChat Token From Local Storage..");
        aTicket = getCookie("aTicket");
        InitJSSDK(aTicket);
    }
}

function randomString(len)
{
    "use strict";
    len = len || 16;
    var $chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890';
    var maxPos = $chars.length;
    var pwd = "";
    for (var i = 0; i < len; i++)
    {
        pwd += $chars.charAt(Math.floor(Math.random() * maxPos));
    }
    return pwd;
}

function InitJSSDK(ATicket)
{
    "use strict";
    var appID = "wx68bec13e85ca6465";
    var nonceStr = randomString(32);
    var TimeStamp = new Date().getTime();
    var urlStr = location.href;
    var strSHA1 = "jsapi_ticket=" + ATicket + "&noncestr=" + nonceStr + "&timestamp=" + TimeStamp + "&url=" + urlStr;
    var signature = hex_sha1(strSHA1);
    wx.config({
        debug: false,
        appId: appID,
        timestamp: TimeStamp,
        nonceStr: nonceStr,
        signature: signature,
        jsApiList: [
            'checkJsApi', 'onMenuShareTimeline', 'onMenuShareAppMessage', 'onMenuShareQQ',
            'onMenuShareWeibo', 'onMenuShareQZone', 'hideMenuItems', 'showMenuItems',
            'hideAllNonBaseMenuItem', 'showAllNonBaseMenuItem', 'translateVoice', 'startRecord',
            'stopRecord', 'onVoiceRecordEnd', 'playVoice', 'onVoicePlayEnd',
            'pauseVoice', 'stopVoice', 'uploadVoice', 'downloadVoice',
            'chooseImage', 'previewImage', 'uploadImage', 'downloadImage',
            'getNetworkType', 'openLocation', 'getLocation', 'hideOptionMenu',
            'showOptionMenu', 'closeWindow', 'scanQRCode', 'chooseWXPay',
            'openProductSpecificView', 'addCard', 'chooseCard', 'openCard'
        ]
    });
}

wx.error(function (res)
{
    "use strict";
    if (res.errMsg.indexOf("invalid signature") > -1)
    {
        alert(res.errMsg.indexOf("调用签名不正确"));
        console.log("Signature Failed");
        InitWeixin(true);
    } else
    {
        alert(res.errMsg);
    }
    // config信息验证失败会执行error函数，如签名过期导致验证失败，具体错误信息可以打开config
    // 的debug模式查看，也可以在返回的res参数中查看，对于SPA可以在这里更新签名。
});

function GetUserData(code, callback)
{
    var aToken = getCookie("aToken");
    $.ajax({
        url: location.protocol + "//" + location.host + "/api/wx/getUserInfo?AccessToken=" + aToken + "&Code=" + code,
        type: 'GET',
        success: function (data)
        {
            if (data.ErrCode !== "0")
            {
                var usr_TICKET = data.user_ticket;
                usr_TICKET = base64decode(utf8to16De(usr_TICKET));
                usr_TICKET = usr_TICKET.substr(0, usr_TICKET.length - 1);
                $.ajax({
                    url: location.protocol + "//" + location.host + "/api/wx/getUserDInfo?AccessToken=" + getCookie("aToken") + "&UserTicket=" + usr_TICKET,
                    type: 'GET',
                    success: function (data2)
                    {
                        if (data2.errcode === "0")
                        {
                            callback(data2);
                        } else
                        {
                            $("#mainloginfailed").show();
                            $("#faileddetail").text("没能获取到你的信息，过会再试试吧");
                        }
                    },
                    error: function (err)
                    {
                        $("#mainloginfailed").show();
                        $("#faileddetail").text("没能获取到你的信息，过会再试试吧" + err);
                    }
                });
            } else
            {
                $("#mainloginfailed").show();
                $("#faileddetail").text("没能获取到你的信息，过会再试试吧");
            }
        },
        error: function (err)
        {
            $("#mainloginfailed").show();
            $("#faileddetail").text("没能获取到你的信息，过会再试试吧" + err);
        }
    });
}

function WriteUserData(UserID, DatField, DataContent, Session, CallBackFunction)
{
    "use strict";
    var STAMP = CryptoJS.SHA256(UserID + DataContent + Session).toString() + "_v3_" + Session;
    $.ajax({
        url: location.protocol + "//" + location.host + "/api/users/Change?" +
            "UserID=" + UserID +
            "&Column=" + DatField +
            "&Content=" + DataContent +
            "&STAMP=" + STAMP,
        type: 'GET',
        success: function (data2)
        {
            CallBackFunction(data2);
        },
        error: function (err)
        {
            CallBackFunction(false);
        }
    });
}


function setCookie(name, value)
{
    var TimeMins = 40;
    var exp = new Date();
    exp.setTime(exp.getTime() + TimeMins * 60 * 1000);
    document.cookie = name + "=" + escape(value) + ";expires=" + exp.toUTCString() + ";path=/";
}

function getCookie(name)
{
    var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
    if (arr = document.cookie.match(reg)) return unescape(arr[2]);
    else return null;
}

function delCookie(name)
{
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(name);
    if (cval !== null) document.cookie = name + "=nothing;expires=" + exp.toUTCString() + ";path=/";
}

function GetURLOption(option)
{
    "use strict";
    var reg = new RegExp("(^|&)" + option + "=([^&]*)(&|$)");
    var r = location.href.substr(location.href.indexOf("?") + 1).match(reg);
    if (r === null)
        return "nullStr";
    return r[2];
}
