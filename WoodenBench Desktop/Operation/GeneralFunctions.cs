using cn.bmob.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WoodenBench_Desktop
{
	public static class GeneralFunctions
	{
		public static void FinishedCallback<T>(T data, TextBox text)
		{
			text.Text = JsonAdapter.JSON.ToDebugJsonString(data);
		}
		public static void FinishedCallback<T>(T data, Label text)
		{
			text.Text = JsonAdapter.JSON.ToDebugJsonString(data);
		}
	}
}
