using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/QueryUsers")]
    public class Admin_QueryUsers : WebAPIController
    {
        [HttpGet]
        public IEnumerable Get(string columnName, string operand, string value)
        {
            if (ValidateSession())
            {
                if (CurrentUser.UserGroup.IsAdmin)
                {
                    string _column = (string)PublicTools.DecodeObject(columnName ?? "");
                    string _operand = (string)PublicTools.DecodeObject(operand ?? "");
                    string _value = (string)PublicTools.DecodeObject(value ?? "");

                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    DBQuery query = new DBQuery();
                    if (_operand == "==")
                    {
                        query.WhereEqualTo(_column, _value);
                    }
                    else if (operand.ToLower() == "contains")
                    {
                        query.WhereRecordContainsValue(_column, _value);
                    }
                    else return RequestIllegal;

                    if (DataBaseOperation.QueryMultipleData(query, out List<UserObject> users) >= 0)
                    {
                        dict.Add("count", users.Count.ToString());
                        for (int i = 0; i < users.Count; i++)
                            dict.Add("num_" + i.ToString(), users[i].ToString());
                        dict.Add("ErrCode", "0");
                        dict.Add("ErrMessage", "null");
                        return dict;
                    }
                    else return DataBaseError;
                }
                else return UserGroupError;
            }
            else return SessionError;
        }
    }
}
