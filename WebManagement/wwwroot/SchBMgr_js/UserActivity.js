
function GetMgmtBus(UserID, Session, CallBackFunction)
{
    "use strict";
    $.ajax({
        url: location.protocol + "//" + location.host + "/api/bus/GetBuses?" +
            "UserID=" + UserID +
            "&Session=" + Session,
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

function GetStudents(BusID, TeacherID, CallBackFunction)
{
    "use strict";
    var Session = getCookie("Session");
    var STAMP = CryptoJS.SHA256(BusID + ";;" + Session + TeacherID + ";;" + Session).toString();
    $.ajax({
        url: location.protocol + "//" + location.host + "/api/bus/GetStudents?" +
            "BusID=" + BusID +
            "&TeacherID=" + TeacherID +
            "&Session=" + Session +
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
            }
            else
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
            }
            else
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


function SignStudent(TeacherID, BusID, StudentID, Mode, Value, SignCallBack)
//function SignStudent(busID, Mode, value, TeacherID, StudentID, Session, SignCallBack)
{
    "use strict";
    var SALT = getCookie("Session");
    $.ajax({
        url: location.protocol + "//" + location.host + "/api/bus/SignStudents?" +
            "BusID=" + BusID +
            "&SignData=" + CryptoJS.SHA256(Value + SALT + ";" + Mode + BusID + TeacherID).toString() +
            "&Data=" + base64Encode(utf16to8En(Mode + ";" + Value + ";" + SALT + ";" + TeacherID + ";" + StudentID)),
        type: 'GET',
        success: function (data2)
        {
            SignCallBack(data2);
        },
        error: function (err)
        {
            SignCallBack(false);
        }
    });
}

function GetClassStudents(ClassID, UserID, GetCallback)
{
    "use strict";
    $.ajax({
        url: location.protocol + "//" + location.host + "/api/class/getStudents?ClassID=" + ClassID + "&TeacherID=" + UserID,
        type: 'GET',
        success: function (data) { GetCallback(data); },
        error: function (err) { GetCallback(false); }
    });

}
function GetMyChild(UserID, GetCallback)
{
    "use strict";
    $.ajax({
        url: location.protocol + "//" + location.host + "/api/parent/getMyChild?parentId=" + UserID,
        type: 'GET',
        success: function (data) { GetCallback(data); },
        error: function (err) { GetCallback(false); }
    });

}