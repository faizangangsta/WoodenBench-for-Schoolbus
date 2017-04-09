using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using WoodenBench_Desktop.Controls.Update;

namespace WoodenBench_Desktop.Views
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class FrmUpdate : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ColumnHeader chFileName;
		private System.Windows.Forms.ColumnHeader chVersion;
		private System.Windows.Forms.ColumnHeader chProgress;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListView lvUpdateList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lbState;
		private System.Windows.Forms.Button btnFinish;
		private ProgressBar pbDownFile;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;


		public FrmUpdate() { InitializeComponent(); }

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null) { components.Dispose(); }
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpdate));
			this.panel1 = new System.Windows.Forms.Panel();
			this.pbDownFile = new System.Windows.Forms.ProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lvUpdateList = new System.Windows.Forms.ListView();
			this.chFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lbState = new System.Windows.Forms.Label();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnFinish = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.pbDownFile);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.lvUpdateList);
			this.panel1.Controls.Add(this.lbState);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(280, 240);
			this.panel1.TabIndex = 2;
			// 
			// pbDownFile
			// 
			this.pbDownFile.Location = new System.Drawing.Point(5, 209);
			this.pbDownFile.Name = "pbDownFile";
			this.pbDownFile.Size = new System.Drawing.Size(272, 23);
			this.pbDownFile.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "以下为更新文件列表";
			// 
			// groupBox2
			// 
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox2.Location = new System.Drawing.Point(0, 238);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(280, 2);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "groupBox2";
			// 
			// lvUpdateList
			// 
			this.lvUpdateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileName,
            this.chVersion,
            this.chProgress});
			this.lvUpdateList.Location = new System.Drawing.Point(5, 53);
			this.lvUpdateList.Name = "lvUpdateList";
			this.lvUpdateList.Size = new System.Drawing.Size(272, 120);
			this.lvUpdateList.TabIndex = 6;
			this.lvUpdateList.UseCompatibleStateImageBehavior = false;
			this.lvUpdateList.View = System.Windows.Forms.View.Details;
			// 
			// chFileName
			// 
			this.chFileName.Text = "组件名";
			this.chFileName.Width = 123;
			// 
			// chVersion
			// 
			this.chVersion.Text = "版本号";
			this.chVersion.Width = 98;
			// 
			// chProgress
			// 
			this.chProgress.Text = "进度";
			this.chProgress.Width = 47;
			// 
			// lbState
			// 
			this.lbState.Location = new System.Drawing.Point(3, 190);
			this.lbState.Name = "lbState";
			this.lbState.Size = new System.Drawing.Size(240, 16);
			this.lbState.TabIndex = 4;
			this.lbState.Text = "点击“下一步”开始更新文件";
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(100, 258);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(80, 24);
			this.btnNext.TabIndex = 3;
			this.btnNext.Text = "下一步(&N)>";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(188, 258);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 24);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "取消(&C)";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnFinish
			// 
			this.btnFinish.Location = new System.Drawing.Point(12, 258);
			this.btnFinish.Name = "btnFinish";
			this.btnFinish.Size = new System.Drawing.Size(80, 24);
			this.btnFinish.TabIndex = 3;
			this.btnFinish.Text = "完成(&F)";
			this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
			// 
			// FrmUpdate
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(303, 303);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnFinish);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmUpdate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "检查更新";
			this.Load += new System.EventHandler(this.FrmUpdate_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private string updateUrl = string.Empty;
		private string tempUpdatePath = string.Empty;
		XmlFiles updaterXmlFiles = null;
		private int availableUpdate = 0;
		bool isRun = false;
		string mainAppExe = "";

		private void FrmUpdate_Load(object sender, System.EventArgs e)
		{
			btnFinish.Visible = false;

			string localXmlFile = Application.StartupPath + "\\UpdateList.xml";
			string serverXmlFile = string.Empty;
			try
			{
				//从本地读取更新配置文件信息
				updaterXmlFiles = new XmlFiles(localXmlFile);
			}
			catch
			{
				MessageBox.Show("配置文件出错!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
				return;
			}
			//获取服务器地址
			updateUrl = updaterXmlFiles.GetNodeValue("//Url");

			AppUpdater appUpdater = new AppUpdater();
			appUpdater.UpdaterUrl = updateUrl + "/UpdateList.xml";

			//与服务器连接,下载更新配置文件
			try
			{
				tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\" + "_" + updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value + "_" + "y" + "_" + "x" + "_" + "m" + "_" + "\\";
				appUpdater.DownAutoUpdateFile(tempUpdatePath);
			}
			catch
			{
				MessageBox.Show("与服务器连接失败,操作超时!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
				return;
			}
			//获取更新文件列表
			Hashtable htUpdateFile = new Hashtable();

			serverXmlFile = tempUpdatePath + "\\UpdateList.xml";
			if (!File.Exists(serverXmlFile))
			{
				return;
			}

			availableUpdate = appUpdater.CheckForUpdate(serverXmlFile, localXmlFile, out htUpdateFile);
			if (availableUpdate > 0)
			{
				for (int i = 0; i < htUpdateFile.Count; i++)
				{
					string[] fileArray = (string[])htUpdateFile[i];
					lvUpdateList.Items.Add(new ListViewItem(fileArray));
				}
			}
			//			else
			//				btnNext.Enabled = false;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			if (availableUpdate > 0)
			{
				DownUpdateFile();
			}
			else
			{
				MessageBox.Show("没有可用的更新!", "自动更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

		}
		private void DownUpdateFile()
		{
			this.Cursor = Cursors.WaitCursor;
			mainAppExe = updaterXmlFiles.GetNodeValue("//EntryPoint");
			Process[] allProcess = Process.GetProcesses();
			foreach (Process p in allProcess)
			{

				if (p.ProcessName.ToLower() + ".exe" == mainAppExe.ToLower())
				{
					for (int i = 0; i < p.Threads.Count; i++)
						p.Threads[i].Dispose();
					//p.Kill();
					isRun = true;
					//break;
				}
			}
			WebClient wcClient = new WebClient();
			for (int i = 0; i < this.lvUpdateList.Items.Count; i++)
			{
				string UpdateFile = lvUpdateList.Items[i].Text.Trim();
				string updateFileUrl = updateUrl + lvUpdateList.Items[i].Text.Trim();
				long fileLength = 0;

				WebRequest webReq = WebRequest.Create(updateFileUrl);
				WebResponse webRes = webReq.GetResponse();
				fileLength = webRes.ContentLength;

				lbState.Text = "正在下载更新文件,请稍后...";
				pbDownFile.Value = 0;
				pbDownFile.Maximum = (int)fileLength;

				try
				{
					Stream srm = webRes.GetResponseStream();
					StreamReader srmReader = new StreamReader(srm);
					byte[] bufferbyte = new byte[fileLength];
					int allByte = (int)bufferbyte.Length;
					int startByte = 0;
					while (fileLength > 0)
					{
						Application.DoEvents();
						int downByte = srm.Read(bufferbyte, startByte, allByte);
						if (downByte == 0) { break; };
						startByte += downByte;
						allByte -= downByte;
						pbDownFile.Value += downByte;

						float part = (float)startByte / 1024;
						float total = (float)bufferbyte.Length / 1024;
						int percent = (int)((part / total) * 100);

						this.lvUpdateList.Items[i].SubItems[2].Text = percent.ToString() + "%";
					}

					string tempPath = tempUpdatePath + UpdateFile;
					CreateDirtory(tempPath);
					FileStream fs = new FileStream(tempPath, FileMode.OpenOrCreate, FileAccess.Write);
					fs.Write(bufferbyte, 0, bufferbyte.Length);
					srm.Close();
					srmReader.Close();
					fs.Close();


				}
				catch (WebException ex)
				{
					MessageBox.Show("更新文件下载失败！" + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			InvalidateControl();
			this.Cursor = Cursors.Default;
		}
		//创建目录
		private void CreateDirtory(string path)
		{
			if (!File.Exists(path))
			{
				string[] dirArray = path.Split('\\');
				string temp = string.Empty;
				for (int i = 0; i < dirArray.Length - 1; i++)
				{
					temp += dirArray[i].Trim() + "\\";
					if (!Directory.Exists(temp))
						Directory.CreateDirectory(temp);
				}
			}
		}

		//复制文件;
		public void CopyFile(string sourcePath, string objPath)
		{
			//			char[] split = @"\".ToCharArray();
			if (!Directory.Exists(objPath))
			{
				Directory.CreateDirectory(objPath);
			}
			string[] files = Directory.GetFiles(sourcePath);
			for (int i = 0; i < files.Length; i++)
			{
				string[] childfile = files[i].Split('\\');
				File.Copy(files[i], objPath + @"\" + childfile[childfile.Length - 1], true);
			}
			string[] dirs = Directory.GetDirectories(sourcePath);
			for (int i = 0; i < dirs.Length; i++)
			{
				string[] childdir = dirs[i].Split('\\');
				CopyFile(dirs[i], objPath + @"\" + childdir[childdir.Length - 1]);
			}
		}
		//点击完成复制更新文件到应用程序目录
		private void btnFinish_Click(object sender, System.EventArgs e)
		{
			this.Close();
			this.Dispose();
			try
			{
				CopyFile(tempUpdatePath, Directory.GetCurrentDirectory());
				System.IO.Directory.Delete(tempUpdatePath, true);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}
			if (true == this.isRun) Process.Start(mainAppExe);
		}

		//重新绘制窗体部分控件属性
		private void InvalidateControl()
		{
			panel1.Visible = false;

			btnNext.Visible = false;
			btnCancel.Visible = false;
			btnFinish.Location = btnCancel.Location;
			btnFinish.Visible = true;
		}
		//判断主应用程序是否正在运行
		private bool IsMainAppRun()
		{
			string mainAppExe = updaterXmlFiles.GetNodeValue("//EntryPoint");
			bool isRun = false;
			Process[] allProcess = Process.GetProcesses();
			foreach (Process p in allProcess)
			{

				if (p.ProcessName.ToLower() + ".exe" == mainAppExe.ToLower())
				{
					isRun = true;
					//break;
				}
			}
			return isRun;
		}
	}
}
