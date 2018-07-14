
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

wx.error(function (res) {
    "use strict";
    if (res.errMsg.indexOf("invalid signature") > -1) {
        alert(res.errMsg.indexOf("调用签名不正确"));
        console.log("Signature Failed");
        InitWeixin(true);
    } else {
        alert(res.errMsg);
    }
    //config信息验证失败会执行error函数，如签名过期导致验证失败，具体错误信息可以打开config
    //的debug模式查看，也可以在返回的res参数中查看，对于SPA可以在这里更新签名。
});


function setCookie(name, value) {
    var TimeMins = 40;
    var exp = new Date();
    exp.setTime(exp.getTime() + TimeMins * 60 * 1000);
    document.cookie = name + "=" + escape(value) + ";expires=" + exp.toUTCString() + ";path=/";
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
    if (cval !== null) document.cookie = name + "=nothing;expires=" + exp.toUTCString() + ";path=/";
}

function GetURLOption(option) {
    "use strict";
    var reg = new RegExp("(^|&)" + option + "=([^&]*)(&|$)");
    var r = location.href.substr(location.href.indexOf("?") + 1).match(reg);
    if (r === null)
        return "nullStr";
    return r[2];
}
