function Maininit(CallBackAddress, CallbackFunc)
{
    //alert("You are visiting the TESTing Website, Please Goto http://lhy0403.iego.net to visit current release");
    console.error("You are visiting the TESTing Website, Please Goto http://lhy0403.iego.net to visit current release");
    if (!CheckCookiesExist) ReDirectToLogin(CallBackAddress);
    var Bs64Val = getCookie("SBUser_Sessions");
    var UsrConfig = base64decode(utf8to16De(base64decode(utf8to16De(Bs64Val))));
    var NStr = base64decode(utf8to16De(getSecKey("NonceString"))).split(";");
    var SHA1String = base64decode(utf8to16De(getSecKey("StoredSHA1")));
    
    var SHA1StringB = hex_sha1(UsrConfig + ";" + Bs64Val + ";" + NStr[1] + ";" + NStr[0])
    if (SHA1String !== SHA1StringB) ReDirectToLogin(CallBackAddress);
    else
    {
        var Rtn = base64decode(utf8to16De(base64decode(utf8to16De(Bs64Val)))) + ";" + getCookie("SBUser_Realname");
        var RSplit = Rtn.split(";");
        CallbackFunc(RSplit);
    }
}

function ReDirectToLogin(CallBackAddress, TargetOption)
{
    setCookie("SBCallBackAddress", CallBackAddress);
    if (TargetOption === undefined) TargetOption = "";
    location.href = "../jumpto.html?ToURL=schoolbusmgr/loginusr.html" + TargetOption;
}

function CheckCookiesExist()
{
    if (getCookie("SBUser_Sessions") === null) return false;
    if (getSecKey("NonceString") === null) return false;
    if (getSecKey("StoredSHA1") === null) return false;
}

function RemoveLoginData(CleanExit)
{
    delCookie("SBUser_Sessions");
    setSecKey("NonceString", "nothing", 2);
    setSecKey("StoredSHA1", "nothing", 2);
    setCookie("SBUser_Realname", "");
    if (CleanExit)
    {
        setSecKey("WCLogin", "nothing", 2);
        setSecKey("aToken", "nothing", 2);
        setSecKey("aTicket", "nothing", 2);
        setSecKey("A%TKH$asH%CHecK%&", "nothing", 2);
    }
}

function GetRAWValue(object, ContainRealName)
{
    var RAWVal =
        object.id + ";" + object.get("Username") + ";" + object.get("Password") + ";" +
        object.get("UsrGroup") + ";" + object.get("IsFstLgn") + ";" + object.get("WebNotiSeen") + ";" +
        object.get("WeChatID") + ";" + object.get("LastLoginTime");
    if (ContainRealName) return (RAWVal + ";" + object.get("RealName"));
    else return RAWVal;
}

function ProcLogin(object)
{
    StoreUserData(object);
    object.set("IsFstLgn", false);
    object.save(null, null, null);
    if (getCookie("SBCallBackAddress") !== null)
    {
        console.log(getCookie("SBCallBackAddress"));
        var RDireURL = "../jumpto.html?ToURL=schoolbusmgr/" + getCookie("SBCallBackAddress");
        
        if (location.href.indexOf("UnBonding=force") > -1)
        {
            TS = new Date().getTime().toString();
            setCookie("UBTimeStamp", TS);
            location.href = RDireURL + "true&Option=" + base64Encode(utf16to8En(TS));
        }
        else if (location.href.indexOf("ChangePassword=RemoteRtn") > -1)
        {
            TS = new Date().getTime().toString();
            setCookie("UBTimeStamp", TS);
            location.href = RDireURL + "Allowed&Option=" + base64Encode(utf16to8En(TS));
        }
        else location.href = RDireURL;
    }
    else
    {
        location.href = "../jumpto.html?ToURL=schoolbusmgr/index.html"
    }
}