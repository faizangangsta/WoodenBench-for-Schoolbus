
function GetMgmtBus(UserID, UserName, Pswd, CallBackFunction)
{
    "use strict";
    var SALT = getCookie("SecretKey");
    $.ajax({
        url: location.protocol + "//" + location.host + "/api/bus/GetBuses?" +
        "UserID=" + UserID +
        "&UserName=" + UserName +
        "&PsWd=" + Pswd +
        "&SALT=" + SALT,
        type: 'GET',
        success: function (data2)
        {
            if (data2.ErrCode === "0")
            {
                CallBackFunction(data2);
            } else
            {
                CallBackFunction(false);
            }
        },
        error: function (err)
        {
            CallBackFunction(false);
        }
    });
}

function GetStudents(BusID, TeacherID, CallBackFunction)
{
    "use strict";
    var SALT = randomString(32);
    var STAMP = CryptoJS.SHA256(BusID + ";;" + SALT + TeacherID + ";;" + SALT).toString();
    $.ajax({
        url: location.protocol + "//" + location.host + "/api/bus/GetStudents?" +
        "BusID=" + BusID +
        "&TeacherID=" + TeacherID +
        "&STAMP=" + STAMP +
        "&SALT=" + SALT,
        type: 'GET',
        success: function (data2)
        {
            if (data2.ErrCode === "0")
            {
                CallBackFunction(data2);
            } else
            {
                CallBackFunction(false);
            }
        },
        error: function (err)
        {
            CallBackFunction(false);
        }
    });
}


function QueryStudents(BusID, Column, Content, CallBackFunction)
{
    "use strict";
    var SALT = randomString(32);
    var STAMP = CryptoJS.SHA256(BusID + ";;" + SALT + Column + ";" + Content + ";;" + SALT).toString();
    $.ajax({
        url: location.protocol + "//" + location.host + "api/bus/QueryStudents?" +
        "BusID=" + BusID +
        "&Column=" + Column +
        "&Content=" + Content +
        "&STAMP=" + STAMP +
        "&SALT=" + SALT,
        type: 'GET',
        success: function (data2)
        {
            if (data2.ErrCode === "0")
            {
                CallBackFunction(data2);
            } else
            {
                CallBackFunction(false);
            }
        },
        error: function ()
        {
            CallBackFunction(false);
        }
    });
}

function UserNewReport(TeacherID, BusID, Type, Content, CallBackFunction)
{
    "use strict";
    $.ajax({
        url: location.protocol + "//" + location.host + "api/gen/NewReport?" +
        "BusID=" + BusID +
        "&TeacherID=" + TeacherID +
        "&ReportType=" + Type +
        "&Content=" + Content,
        type: 'GET',
        success: function (data2)
        {
            if (data2.ErrCode === "0")
            {
                CallBackFunction(data2);
            } else
            {
                CallBackFunction(false);
            }
        },
        error: function (err)
        {
            CallBackFunction(false);
        }
    });
}

function SignStudent(busID, Mode, value, TeacherID, StudentID, SignCallBack)
{
    "use strict";
    var SALT = randomString(32);
    var SignString = Mode + ";" + value + ";" + SALT + ";" + TeacherID + ";" + StudentID;
    SignString = base64Encode(utf16to8En(SignString));
    var SignVerifier = CryptoJS.SHA256(value + SALT + ";" + Mode + busID + TeacherID).toString();
    $.ajax({
        url: location.protocol + "//" + location.host + "api/bus/SignStudents?" +
        "BusID=" + busID +
        "&SignData=" +
        SignVerifier +
        "&Data=" + SignString,
        type: 'GET',
        success: function (data2)
        {
            if (data2.ErrCode === "0")
            {
                SignCallBack(data2);
            } else
            {
                SignCallBack(false);
            }
        },
        error: function (err)
        {
            SignCallBack(false);
        }
    });

}
