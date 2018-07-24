using System;
using System.Diagnostics;
using System.Net;
using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;

namespace Debug_Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            LW.InitLog();
            LW.SetLogLevel(LogLevel.Dbg);
            DataBaseOperation.InitialiseClient(IPAddress.Parse("118.190.144.179"));

            LW.D(DataBaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("realname", "刘浩宇"), out UserObject me));
            LW.D(me);
            ClassObject co = new ClassObject()
            {
                CDepartment = "学部",
                CGrade = "1年级",
                CNumber = "5班",
                TeacherID = me.ObjectId
            };
            LW.D(DataBaseOperation.CreateData(ref co));
            me.ClassList.Add(co.ObjectId);
            LW.D(co);


            SchoolBusObject bo = new SchoolBusObject()
            {
                BusName = "校车方向1",
                TeacherID = me.ObjectId
            };
            LW.D(DataBaseOperation.CreateData(ref bo));

            LW.D(bo);

            for (int cn = 1; cn < 40; cn++)
            {
                StudentObject stu = new StudentObject()
                {
                    BusID = bo.ObjectId,
                    ClassID = co.ObjectId,
                    Sex = "M",
                    StudentName = "学生-" + cn.ToString("000"),
                    AHChecked = false,
                    CSChecked = false,
                    LSChecked = false
                };
                LW.D(DataBaseOperation.CreateData(ref stu));

                LW.D(stu);
                if (cn < 21)
                {
                    me.ChildList.Add(stu.ObjectId);
                }
            }

            me.HeadImagePath = "liuhaoyu.gif";
            LW.D(DataBaseOperation.UpdateData(me));
            LW.D(me);
        }
    }
}
