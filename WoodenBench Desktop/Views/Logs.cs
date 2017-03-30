using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WoodenBench_Desktop.Views
{
	public partial class Logs : Form
	{

		private static Logs defaultInstance;
		static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e)
		{ defaultInstance = null; }
		public static Logs Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new Logs();
					defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
				}
				return defaultInstance;
			}
		}
		public Logs()
		{
			InitializeComponent();
		}

		private void OutputText_TextChanged(object sender, EventArgs e)
		{
			OutputText.ScrollToCaret();
		}

		private void Logs_Load(object sender, EventArgs e)
		{
			Hide();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Hide();
		}
	}
}
