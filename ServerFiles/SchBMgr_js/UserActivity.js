function GetMgmtBus(UserID, UserName, Pswd, CallBackFunction) {
    "use strict";
    var SALT = getCookie("SecretKey");
    $.ajax({
        url: "https://api.lhy0403.top/api/bus_GetMgmtBus?" +
            "UserID=" + UserID +
            "&UserName=" + UserName +
            "&PsWd=" + Pswd +
            "&SALT=" + SALT,
        type: 'GET',
        dataType: 'JSONP',
        success: function (data2) {
            if (data2.ErrCode === "0") {
                CallBackFunction(data2);
            } else {
                CallBackFunction(false);
            }
        },
        error: function (err) {
            CallBackFunction(false);
        }
    });
}

function GetStudents(BusID, TeacherID, CallBackFunction) {
    "use strict";
    var SALT = randomString(32);
    var STAMP = CryptoJS.SHA256(BusID + ";;" + SALT + TeacherID + ";;" + SALT).toString();
    $.ajax({
        url: "https://api.lhy0403.top/api/bus_GetStudents?" +
            "BusID=" + BusID +
            "&TeacherID=" + TeacherID +
            "&STAMP=" + STAMP +
            "&SALT=" + SALT,
        type: 'GET',
        dataType: 'JSONP',
        success: function (data2) {
            if (data2.ErrCode === "0") {
                CallBackFunction(data2);
            } else {
                CallBackFunction(false);
            }
        },
        error: function (err) {
            CallBackFunction(false);
        }
    });
}


function QueryStudents(BusID, Column, Content, CallBackFunction) {
    "use strict";
    var SALT = randomString(32);
    var STAMP = CryptoJS.SHA256(BusID + ";;" + SALT + Column + ";" + Content + ";;" + SALT).toString();
    $.ajax({
        url: "https://api.lhy0403.top/api/bus_QueryStudents?" +
            "BusID=" + BusID +
            "&Column=" + Column +
            "&Content=" + Content +
            "&STAMP=" + STAMP +
            "&SALT=" + SALT,
        type: 'GET',
        dataType: 'JSONP',
        success: function (data2) {
            if (data2.ErrCode === "0") {
                CallBackFunction(data2);
            } else {
                CallBackFunction(false);
            }
        },
        error: function (err) {
            CallBackFunction(false);
        }
    });
}

function UserNewReport(TeacherID, BusID, Type, Content, CallBackFunction) {
    "use strict";
    $.ajax({
        url: "https://api.lhy0403.top/api/gen_NewReport?BusID=" + BusID + "&TeacherID=" + TeacherID + "&ReportType=" + Type + "&Content=" + Content,
        type: 'GET',
        dataType: 'JSONP',
        success: function (data2) {
            if (data2.ErrCode === "0") {
                CallBackFunction(data2);
            } else {
                CallBackFunction(false);
            }
        },
        error: function (err) {
            CallBackFunction(false);
        }
    });
}

function SignUser() {

}
