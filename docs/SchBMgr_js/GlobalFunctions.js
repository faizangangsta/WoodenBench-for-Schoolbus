function WriteNotification(CUser)
{

}

function BmobWriteUserData(ObjID, DatField, DataContent, CallBackFunction)
{
    var query = new Bmob.Query(Bmob.Object.extend("AllUsersTable"));
    query.get(ObjID, {
        success: function (object)
        {
            object.set(DatField, DataContent);
            object.save(null, {
                success: function (objectUpdate)
                {
                    StoreUserData(objectUpdate);
                    var a = GetRAWValue(objectUpdate, true);
                    CallBackFunction(a.split(";"));
                },
                error: function (model, error)
                {
                    CallBackFunction(false);
                }
            });
        },
        error: function (object, error)
        {
            CallBackFunction(false);
        }
    });
}

function StoreUserData(object)
{
    var RAWVal = GetRAWValue(object, false);
    var Bs64Ency = base64Encode(utf16to8En(base64Encode(utf16to8En(RAWVal))));
    var TS = new Date().getTime().toString();
    var nonceStr = randomString(64);
    var SHA1Str = hex_sha1(RAWVal + ";" + Bs64Ency + ";" + TS + ";" + nonceStr);
    setCookie("SBUser_Sessions", Bs64Ency);
    setCookie("SBUser_Realname", object.get("RealName"));
    setSecKey("NonceString", nonceStr + ";" + TS, 7200);
    setSecKey("StoredSHA1", SHA1Str, 7200);
}