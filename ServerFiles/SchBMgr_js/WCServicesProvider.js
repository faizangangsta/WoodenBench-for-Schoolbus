function InitWeixin(ForceRemote) {
    "use strict";
    var aTokenStr, aTicket, aExpire;
    if (getCookie("aTicket") === null || getCookie("TicketHash") === null || getCookie("aToken") === null) {
        setCookie("aTicket", "nothing", 60);
        setCookie("TicketHash", "nothing", 60);
        setCookie("aToken", "nothing", 60);
        ForceRemote = true;
    }

    if (ForceRemote || hex_md5(getCookie("aTicket") + ";" + hex_sha1(getCookie("aToken"))) !== getCookie("TicketHash")) {
        console.log("Load WeChat Token From Remote Server..");
        var CorpId = "wx68bec13e85ca6465";
        var CorpSecret = "DatZ0P349SEAS-yDiqpHbb_3VR-kAnKtSaZj39KuWmhJqiiIjmW83LDpIvE49-Gt";
        $.ajax({
            url: "https://api.lhy0403.top/api/wc_getAccessToken?CorpID=" + CorpId + "&CorpSecret=" + CorpSecret,
            type: 'GET',
            dataType: 'JSONP',
            success: function (data) {
                if (data.ErrCode !== "0") {
                    aTokenStr = data.access_token;
                    aTokenStr = base64decode(utf8to16De(aTokenStr));
                    aTokenStr = aTokenStr.substr(0, aTokenStr.length - 5);
                    $.ajax({
                        url: "https://api.lhy0403.top/api/wc_getTicket?AccessToken=" + aTokenStr,
                        type: 'GET',
                        dataType: 'JSONP',
                        success: function (data2) {
                            if (data2.ErrCode !== "0") {
                                aTicket = data2.ticket;
                                aTicket = base64decode(utf8to16De(aTicket));
                                aTicket = aTicket.substr(0, aTicket.length - 5);
                                aExpire = data2.expires_in * 0.75;
                                setCookie("aToken", aTokenStr, aExpire - 400);
                                setCookie("aTicket", aTicket, aExpire);
                                setCookie("TicketHash", hex_md5(aTicket + ";" + hex_sha1(aTokenStr)), aExpire - 400);
                                InitJSSDK(aTicket);
                            } else {}
                        },
                        error: function () {}
                    });
                } else {}
            },
            error: function (err) {}
        });
    } else {
        console.log("Load WeChat Token From Local Storage..");
        aTicket = getCookie("aTicket");
        InitJSSDK(aTicket);
    }
}

function randomString(len) {
    "use strict";
    len = len || 16;
    var $chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890';
    var maxPos = $chars.length;
    var pwd = "";
    for (var i = 0; i < len; i++) {
        pwd += $chars.charAt(Math.floor(Math.random() * maxPos));
    }
    return pwd;
}

function InitJSSDK(ATicket) {
    "use strict";
    var appID = "wx68bec13e85ca6465";
    var nonceStr = randomString(32);
    var TimeStamp = new Date().getTime();
    var urlStr = location.href;
    //var urlStr = "http://lhy0403.iego.net/index.html";
    var strSHA1 = "jsapi_ticket=" + ATicket + "&noncestr=" + nonceStr + "&timestamp=" + TimeStamp + "&url=" + urlStr;
    var signature = hex_sha1(strSHA1);
    wx.config({
        debug: false,
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

wx.error(function (res) {
    "use strict";
    if (res.errMsg.indexOf("invalid signature") > -1) {
        alert(res.errMsg.indexOf("调用签名不正确"));
        console.log("Signature Failed");
        InitWeixin(true);
    } else {
        alert(res.errMsg);
    }
    // config信息验证失败会执行error函数，如签名过期导致验证失败，具体错误信息可以打开config
    // 的debug模式查看，也可以在返回的res参数中查看，对于SPA可以在这里更新签名。
});

function JumpToWeChatLogin(State) {
    "use strict";
    var TimeStamp = new Date().getTime().toString() + ";" + State;
    setCookie("WCLogin", TimeStamp, 300);
    var url = "https://open.weixin.qq.com/connect/oauth2/authorize?" +
        "appid=wx68bec13e85ca6465" +
        "&redirect_uri=https://schoolbus.lhy0403.top/WeChatUserCodeReceiver.html" +
        "&response_type=code" +
        "&scope=snsapi_userinfo" +
        "&agentid=41" +
        "&state=" + TimeStamp +
        "#wechat_redirect";
    location.href = url;
}

function GetUserData(code, callback) {
    "use strict";
    var aToken = getCookie("aToken");

    $.ajax({
        url: "https://api.lhy0403.top/api/wc_UserInfo?AccessToken=" + aToken + "&Code=" + code,
        type: 'GET',
        dataType: 'JSONP',
        success: function (data) {
            if (data.ErrCode !== "0") {
                var usr_TICKET = data.user_ticket;
                usr_TICKET = base64decode(utf8to16De(usr_TICKET));
                usr_TICKET = usr_TICKET.substr(0, usr_TICKET.length - 1);
                $.ajax({
                    url: "https://api.lhy0403.top/api/wc_UserDetailInfo?AccessToken=" + getCookie("aToken") + "&UserTicket=" + usr_TICKET,
                    type: 'GET',
                    dataType: 'JSONP',
                    success: function (data2) {
                        if (data2.errcode === "0") {
                            callback(data2);
                        } else {
                            $("#mainloginfailed").show();
                            $("#faileddetail").text("没能获取到你的信息，过会再试试吧");
                        }
                    },
                    error: function (err) {
                        $("#mainloginfailed").show();
                        $("#faileddetail").text("没能获取到你的信息，过会再试试吧" + err);
                    }
                });
            } else {
                $("#mainloginfailed").show();
                $("#faileddetail").text("没能获取到你的信息，过会再试试吧");
            }
        },
        error: function (err) {
            $("#mainloginfailed").show();
            $("#faileddetail").text("没能获取到你的信息，过会再试试吧" + err);
        }
    });
}

function WriteUserData(Username, DatField, DataContent, Password, CallBackFunction) {
    "use strict";
    var RandStr = getCookie("SecretKey");
    var STAMP = CryptoJS.SHA256(DataContent + Password + RandStr).toString();
    $.ajax({
        url: "https://api.lhy0403.top/api/usr_ChangeProperty?" +
            "Username=" + Username +
            "&Column=" + DatField +
            "&Content=" + DataContent +
            "&STAMP=" + STAMP +
            "&Ticket=" + RandStr,
        type: 'GET',
        dataType: 'JSONP',
        success: function (data2) {
            if (data2.ErrCode === "0") {
                StoreUserData(data2);
                CallBackFunction(getCookie("SBUser_Data").split(";"));
            } else {
                CallBackFunction(false);
            }
        },
        error: function (err) {
            CallBackFunction(false);
        }
    });
}

function StoreUserData(object) {
    "use strict";
    var RAWVal =
        object.userID + ";" + object.Username + ";" + object.Password + ";" +
        object.UserGroup + ";" + object.HeadImagePath + ";" + object.WebNotiSeen + ";" +
        object.WeChatID + ";" + object.IsBusTeacher;
    var TS = new Date().getTime().toString();
    var nonceStr = randomString(64);
    var SHA1Str = hex_sha1(RAWVal + ";" + TS + ";" + nonceStr);
    setCookie("SBUser_Data", RAWVal);
    setCookie("SBUser_Realname", object.RealName);
    setCookie("NonceString", nonceStr + ";" + TS, 7200);
    setCookie("StoredSHA1", SHA1Str, 7200);
}

function Maininit(CallBackAddress, CallbackFunc) {
    "use strict";
    if (!CheckCookiesExist()) {
        ReDirectToLogin(CallBackAddress);
    }
    var UsrConfig = getCookie("SBUser_Data");
    var NStr = getCookie("NonceString").split(";");
    if (getCookie("StoredSHA1") !== hex_sha1(UsrConfig + ";" + NStr[1] + ";" + NStr[0])) {
        ReDirectToLogin(CallBackAddress);
    } else {
        CallbackFunc((UsrConfig + ";" + getCookie("SBUser_Realname")).split(";"));
    }
}

function ReDirectToLogin(CallBackAddress, TargetOption) {
    "use strict";
    setCookie("SBCallBackAddress", CallBackAddress);
    if (TargetOption === undefined) {
        TargetOption = "";
    }
    location.href = "loginusr.html" + TargetOption;
}

function CheckCookiesExist() {
    "use strict";
    if (getCookie("SBUser_Data") === null) {
        return false;
    }
    if (getCookie("NonceString") === null) {
        return false;
    }
    if (getCookie("StoredSHA1") === null) {
        return false;
    }
    if (getCookie("SBUser_Realname") === null) {
        return false;
    }
    return true;
}

function RemoveLoginData(CleanExit) {
    "use strict";
    delCookie("SBUser_Sessions");
    delCookie("NonceString");
    delCookie("StoredSHA1");
    delCookie("SBUser_Realname");
    delCookie("SBUser_Data");
    if (CleanExit) {
        delCookie("WCLogin");
        delCookie("aToken");
        delCookie("TicketHash");
        delCookie("aTicket");
    }

}

function ProcLogin(object) {
    "use strict";
    if (object.FirstLogin.toLowerCase() === "true") WriteUserData(object.Username, "firstlogin", false, object.Password, P);
    else P(object);
}

function P(object2) {
    "use strict";
    StoreUserData(object2);
    if (getCookie("SBCallBackAddress") !== null) {
        var RDireURL = "" + getCookie("SBCallBackAddress");
        var TS = "";
        if (location.href.indexOf("UnBonding=force") > -1) {
            TS = new Date().getTime().toString();
            setCookie("UBTimeStamp", TS);
            location.href = RDireURL + "true&Option=" + base64Encode(utf16to8En(TS));
        } else if (location.href.indexOf("ChangePassword=RemoteRtn") > -1) {
            TS = new Date().getTime().toString();
            setCookie("UBTimeStamp", TS);
            location.href = RDireURL + "Allowed&Option=" + base64Encode(utf16to8En(TS));
        } else {
            location.href = RDireURL;
        }
    } else {
        location.href = "index.html";
    }
}

function setCookie(name, value) {
    "use strict";
    var TimeMins = 40;
    var exp = new Date();
    exp.setTime(exp.getTime() + TimeMins * 60 * 1000);
    document.cookie = name + "=" + escape(value) + ";expires=" + exp.toUTCString();
}

function getCookie(name) {
    var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
    if (arr = document.cookie.match(reg)) return unescape(arr[2]);
    else return null;
}

function delCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(name);
    if (cval !== null) document.cookie = name + "=" + cval + ";expires=" + exp.toUTCString();
}

function GetURLOption(option) {
    "use strict";
    var reg = new RegExp("(^|&)" + option + "=([^&]*)(&|$)");
    var r = location.href.substr(location.href.indexOf("?") + 1).match(reg);
    if (r === null) {
        return "nullStr";
    }
    return r[2];
}
