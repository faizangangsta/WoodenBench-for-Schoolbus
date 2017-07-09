function setSecKey(name, value, timeSec)
{
    var cName, cContent, cExp;
    var exp = new Date();
    exp.setTime(exp.getTime() + timeSec * 1000);
    cExp = exp.toUTCString();
    cName = base64Encode(utf16to8En(name));
    cContent = base64Encode(utf16to8En(value));
    document.cookie = cName + "=" + cContent + ";expires=" + cExp;
}

function getSecKey(name)
{
    var arr, reg = new RegExp("(^| )" + base64Encode(utf16to8En(name)) + "=([^;]*)(;|$)");
    if (arr = document.cookie.match(reg)) return unescape(arr[2]);
    else return null;
}

function GetURLOption(option)
{
    var reg = new RegExp("(^|&)" + option + "=([^&]*)(&|$)");
    var r = location.href.substr(location.href.indexOf("?") + 1).match(reg);
    if (r === null) return "nullStr";
    return r[2];
}
