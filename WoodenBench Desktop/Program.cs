using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WoodenBench_Desktop
{

	static class Program
	{		
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
            staClass.BmobObject.InitBmobObject();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new UsrLoginForm());
		}
	}
}
