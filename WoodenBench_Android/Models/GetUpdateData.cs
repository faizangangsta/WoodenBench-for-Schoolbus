using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using cn.bmob.io;

namespace WoodenBench_Android.Model
{
    class GeneralDataTable : BmobTable
    {
        private string PriTable;

        public string DataName { get; set; }
        public string DataContent { get; set; }
        //构造函数
        public GeneralDataTable() { }

        //构造函数
        public GeneralDataTable(String TableName) { PriTable = TableName; }

        public override string table
        {
            get
            {
                if (PriTable != null) { return PriTable; }
                return base.table;
            }
        }

        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            DataName = input.getString("Name");
            DataContent = input.getString("DataContent");
        }        
    }
}