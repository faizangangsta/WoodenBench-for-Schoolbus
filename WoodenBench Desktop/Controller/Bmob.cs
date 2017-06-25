using cn.bmob.api;
using cn.bmob.json;
using cn.bmob.tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WoodenBench_Desktop.TableObjects;

namespace WoodenBench_Desktop.staClass
{
    public static class BmobObject
    {
        public static BmobWindows Bmob = new BmobWindows();
        public static void InitBmobObject()
        {
            Bmob.initialize("b770100ff0051b0c313c1a0e975711e6", "281fb4c79c3a3391ae6764fa56d1468d");
            BmobDebug.Register(Message => { Debug.WriteLine(Message); });
        }
    }
}
