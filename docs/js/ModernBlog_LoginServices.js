function Maininit(CallBackAddress)
{
    CheckCookiesExist(CallBackAddress);
    if (getCookie("Option") !== base64Encode(utf16to8En("AllowToDoNext")))
    {
        ReDirectToLogin(CallBackAddress);
    }
    var b = base64decode(utf8to16De(base64decode(utf8to16De(getCookie("User_Sessions"))))).split(";");
    Bmob.User.logIn(b[0], base64decode(utf16to8En(getCookie("IEUserConfig"))),
        {
            success: function (object)
            {
                if (object.id !== b[2])
                {
                    alert("Login Timeout");
                    ReDirectToLogin(CallBackAddress);
                }
                else
                {
                    UsrName = object.get("RealName");
                    document.getElementById("NowUsrName").innerText = "注销 " + UsrName;
                    //Do Nothing
                }
            },
            error: function (error)
            {
                alert(error.message);
                ReDirectToLogin(CallBackAddress);
            }
        }
    );
}
function ReDirectToLogin(CallBackAddress)
{
    setCookie("CallBackAddress", CallBackAddress);
    location.href = "../jumpto.html?ToURL=ModernBlog/usrlogin.html";
}
function CheckCookiesExist(CallBackAddress)
{
    if (getCookie("Option") === null)
    {
        ReDirectToLogin(CallBackAddress);
    }
    if (getCookie("User_Sessions") === null)
    {
        ReDirectToLogin(CallBackAddress);
    }
    if (getCookie("IEUserConfig") === null)
    {
        ReDirectToLogin(CallBackAddress);
    }
}
function RemoveLoginData()
{
    delCookie("User_Sessions");
    delCookie("Option");
    delCookie("IEUserConfig");
}