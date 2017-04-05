using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Threading;
/*------------------------------------------------------------
 * 
 * 
 *  by Liu Hua-shan,2007-07-13
 * 
 *  sh_liuhuashan@163.com
 * 
 * 
 * ------------------------------------------------------------*/

namespace AULWriter
{
	public partial class frmAULWriter : Form
	{
		public frmAULWriter() { InitializeComponent(); }
		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
			this.Dispose();
		}
		private void btnSearDes_Click(object sender, EventArgs e)
		{
			this.sfdDest.ShowDialog(this);
		}

		private void sfdSrcPath_FileOk(object sender, CancelEventArgs e)
		{
			this.txtDest.Text = this.sfdDest.FileName.Substring(0, this.sfdDest.FileName.LastIndexOf(@"\")) + @"\AutoUpdaterList.xml";
		}
		private void btnSearExpt_Click(object sender, EventArgs e)
		{
			this.ofdExpt.ShowDialog(this);
		}
		private void ofdExpt_FileOk(object sender, CancelEventArgs e)
		{
			foreach (string _filePath in this.ofdExpt.FileNames)
			{
				this.txtExpt.Text += @_filePath.ToString() + "\n\r;";
			}
		}
		private void btnSrc_Click(object sender, EventArgs e)
		{
			this.ofdSrc.ShowDialog(this);
		}
		private void ofdDest_FileOk(object sender, CancelEventArgs e)
		{
			this.txtSrc.Text = this.ofdSrc.FileName;
		}
		private void btnProduce_Click(object sender, EventArgs e)
		{
			if (!File.Exists(this.txtSrc.Text))
			{
				MessageBox.Show(this, "请选择主入口程序!", "AutoUpdater", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.btnSrc_Click(sender, e);
			}
			if (this.txtUrl.Text.Trim().Length == 0)
			{
				MessageBox.Show(this, "请输入自动更新网址!", "AutoUpdater", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.txtUrl.Focus();
				return;
			}
			if (this.txtDest.Text.Trim() == string.Empty)
			{
				MessageBox.Show(this, "请选择AutoUpdaterList保存位置!", "AutoUpdater", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.btnSearDes_Click(sender, e);
			}
			WriterAUList();
		}


		void WriterAUList()
		{
			string strEntryPoint = this.txtSrc.Text.Trim().Substring(this.txtSrc.Text.Trim().LastIndexOf(@"\") + 1, this.txtSrc.Text.Trim().Length - this.txtSrc.Text.Trim().LastIndexOf(@"\") - 1);
			string strFilePath = this.txtDest.Text.Trim();
			FileStream fs = new FileStream(strFilePath, FileMode.Create);
			StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
			sw.Write("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
			sw.Write("\r\n<AutoUpdater>\r\n");
			sw.Write("\t<Description>");
			sw.Write(strEntryPoint.Substring(0, strEntryPoint.LastIndexOf(".")) + " autoUpdate");
			sw.Write("</Description>\r\n");
			sw.Write("\t<Updater>\r\n");
			sw.Write("\t\t<Url>");
			sw.Write(this.txtUrl.Text.Trim());
			sw.Write("</Url>\r\n");
			sw.Write("\t\t<LastUpdateTime>");
			sw.Write(DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd"));
			sw.Write("</LastUpdateTime>\r\n");
			sw.Write("\t</Updater>\r\n");
			sw.Write("\t<Application applicationId = \"" + strEntryPoint.Substring(0, strEntryPoint.LastIndexOf(".")) + "\">\r\n");
			sw.Write("\t\t<EntryPoint>");
			sw.Write(strEntryPoint);
			sw.Write("</EntryPoint>\r\n");
			sw.Write("\t\t<Location>");
			sw.Write(".");
			sw.Write("</Location>\r\n");
			FileVersionInfo _lcObjFVI = FileVersionInfo.GetVersionInfo(this.txtSrc.Text);
			sw.Write("\t\t<Version>");
			sw.Write(string.Format("{0}.{1}.{2}.{3}", _lcObjFVI.FileMajorPart, _lcObjFVI.FileMinorPart, _lcObjFVI.FileBuildPart, _lcObjFVI.FilePrivatePart));
			sw.Write("</Version>\r\n");
			sw.Write("\t</Application>\r\n");
			sw.Write("\t<Files>\r\n");
			StringCollection strColl = GetAllFiles(this.txtSrc.Text.Substring(0, this.txtSrc.Text.LastIndexOf(@"\")));
			for (int i = 0; i < strColl.Count; i++)
			{
				if (!CheckExist(strColl[i].Trim()))
				{
					FileVersionInfo m_lcObjFVI = FileVersionInfo.GetVersionInfo(strColl[i].ToString());
					string rootDir = this.txtSrc.Text.Substring(0, this.txtSrc.Text.LastIndexOf(@"\")) + @"\";
					sw.Write("\t\t<File Ver=\""
						+ string.Format("{0}.{1}.{2}.{3}", _lcObjFVI.FileMajorPart, _lcObjFVI.FileMinorPart, _lcObjFVI.FileBuildPart, _lcObjFVI.FilePrivatePart)
						+ "\" Name= \"" + @strColl[i].Replace(@rootDir, "")
						+ "\" />\r\n");
				}
			}
			sw.Write("\t</Files>\r\n");
			sw.Write("</AutoUpdater>");
			sw.Close();
			fs.Close();
			MessageBox.Show(this, "自动更新文件生成成功:" + this.txtDest.Text.Trim(), "AutoUpdater", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		private StringCollection GetAllFiles(string rootdir)
		{
			StringCollection result = new StringCollection();
			GetAllFiles(rootdir, result);
			return result;
		}
		private void GetAllFiles(string parentDir, StringCollection result)
		{
			string[] dir = Directory.GetDirectories(parentDir);
			for (int i = 0; i < dir.Length; i++)
				GetAllFiles(dir[i], result);
			string[] file = Directory.GetFiles(parentDir);
			for (int i = 0; i < file.Length; i++)
				result.Add(file[i]);
		}
		private bool CheckExist(string filePath)
		{
			bool isExist = false;
			foreach (string strCheck in this.txtExpt.Text.Split(';'))
			{
				if (filePath.Trim() == strCheck.Trim())
				{
					isExist = true;
					break;
				}
			}
			return isExist;
		}
		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}
	}
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmAULWriter());
		}
	}
}