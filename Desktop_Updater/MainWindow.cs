using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Desktop_Updater
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class MainWindow : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ColumnHeader chFileName;
		private System.Windows.Forms.ColumnHeader chVersion;
		private System.Windows.Forms.ColumnHeader chProgress;
		private System.Windows.Forms.ListView lvUpdateList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnFinish;
		private Button button1;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;


		public MainWindow() { InitializeComponent(); }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.lvUpdateList = new System.Windows.Forms.ListView();
            this.chFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "以下为更新文件列表";
            // 
            // lvUpdateList
            // 
            this.lvUpdateList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUpdateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileName,
            this.chVersion,
            this.chProgress});
            this.lvUpdateList.Location = new System.Drawing.Point(12, 28);
            this.lvUpdateList.Name = "lvUpdateList";
            this.lvUpdateList.Size = new System.Drawing.Size(525, 322);
            this.lvUpdateList.TabIndex = 6;
            this.lvUpdateList.UseCompatibleStateImageBehavior = false;
            this.lvUpdateList.View = System.Windows.Forms.View.Details;
            this.lvUpdateList.SelectedIndexChanged += new System.EventHandler(this.LvUpdateList_SelectedIndexChanged);
            // 
            // chFileName
            // 
            this.chFileName.Text = "组件名";
            this.chFileName.Width = 175;
            // 
            // chVersion
            // 
            this.chVersion.Text = "版本号";
            this.chVersion.Width = 163;
            // 
            // chProgress
            // 
            this.chProgress.Text = "进度";
            this.chProgress.Width = 85;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(371, 356);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 24);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "下一步(&N)>";
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(457, 356);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "关闭(&C)";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Location = new System.Drawing.Point(285, 356);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(80, 24);
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "完成(&F)";
            this.btnFinish.Click += new System.EventHandler(this.BtnFinish_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(12, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 10;
            this.button1.Text = "刷新(&R)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(549, 392);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lvUpdateList);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFinish);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检查更新";
            this.Load += new System.EventHandler(this.FrmUpdate_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private string updateUrlOnline = string.Empty;
		private string tempUpdatePath = string.Empty;
		XmlFiles updaterXmlFiles = null;
		private int availableUpdate = 0;
		//bool isRun = false;
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
				Close();
				return;
			}
			//获取服务器地址
			updateUrlOnline = updaterXmlFiles.GetNodeValue("//Url");

			AppUpdater.UpdaterUrl = updateUrlOnline + "/UpdateList.xml";
		
			//与服务器连接,下载更新配置文件
			try
			{
				tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\" +
                    "_" + updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value + "_y_x_m_\\";
				AppUpdater.DownAutoUpdateFile(tempUpdatePath);
			}
			catch(Exception ExpTion)
			{
				MessageBox.Show(ExpTion.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Close();
				return;
			}
			//获取更新文件列表
			Hashtable htUpdateFile = new Hashtable();

			serverXmlFile = tempUpdatePath + "\\UpdateList.xml";
			if (!File.Exists(serverXmlFile)) return;

			availableUpdate = AppUpdater.CheckForUpdate(serverXmlFile, localXmlFile, out htUpdateFile);
			if (availableUpdate > 0)
			{
				for (int i = 0; i < htUpdateFile.Count; i++)
				{
					string[] fileArray = (string[])htUpdateFile[i];
					lvUpdateList.Items.Add(new ListViewItem(fileArray));
				}
			}
		}

		private void BtnCancel_Click(object sender, EventArgs e) => Close();

		private void BtnNext_Click(object sender, EventArgs e)
		{
			if (availableUpdate > 0)
			{

				Cursor = Cursors.WaitCursor;
				mainAppExe = updaterXmlFiles.GetNodeValue("//EntryPoint");
				Process[] allProcess = Process.GetProcesses();
				foreach (Process p in allProcess)
				{
					if (p.ProcessName.ToLower() + ".exe" == mainAppExe.ToLower())
					{
						for (int i = 0; i < p.Threads.Count; i++) p.Threads[i].Dispose();
						p.Kill();
					}
				}
				//WebClient wcClient = new WebClient();
				for (int i = 0; i < lvUpdateList.Items.Count; i++)
				{
					string UpdateFileName = lvUpdateList.Items[i].Text.Trim();
					string UpdateFileUrl = updateUrlOnline + "/" + lvUpdateList.Items[i].Text.Trim();
					//long fileLength = 0;

					//WebRequest webReq = WebRequest.Create(UpdateFileUrl);
					//WebResponse webRes = webReq.GetResponse();
					//fileLength = webRes.ContentLength;

					//lbState.Text = "正在下载更新文件,请稍后...";
					//pbDownFile.Value = 0;
					//pbDownFile.Maximum = (int)fileLength;
					try
					{
						//Stream srm = webRes.GetResponseStream();
						//StreamReader srmReader = new StreamReader(srm);
						//byte[] bufferbyte = new byte[fileLength];
						//int allByte = bufferbyte.Length;
						//int startByte = 0;
						//while (fileLength > 0)
						//{
						//	Application.DoEvents();
						//	int downByte = srm.Read(bufferbyte, startByte, allByte);
						//	if (downByte == 0) { break; };
						//	startByte += downByte;
						//	allByte -= downByte;
						//	pbDownFile.Value += downByte;

						//	float part = (float)startByte / 1024;
						//	float total = (float)bufferbyte.Length / 1024;
						//	int percent = (int)((part / total) * 100);

						//	this.lvUpdateList.Items[i].SubItems[2].Text = percent + "%";
						//}

						string tempPath = tempUpdatePath + UpdateFileName;
						//CreateDirtory(tempPath);
						//FileStream fs = new FileStream(tempPath, FileMode.OpenOrCreate, FileAccess.Write);
						//fs.Write(bufferbyte, 0, bufferbyte.Length);
						//srm.Close();
						//srmReader.Close();
						//fs.Close();
						WebClient Clint = new WebClient();
						new Microsoft.VisualBasic.Devices.Computer().Network.DownloadFile(UpdateFileUrl, tempPath, "", "", true, 100000, true, Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);
					}
					catch (WebException ex)
					{
						MessageBox.Show("更新文件下载失败!" + Environment.NewLine + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				btnNext.Visible = false;
				btnCancel.Visible = false;
				btnFinish.Location = btnCancel.Location;
				btnFinish.Visible = true;
				this.Cursor = Cursors.Default;
			}
			else
			{
				MessageBox.Show("没有可用的更新!", "自动更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
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
		private void BtnFinish_Click(object sender, EventArgs e)
		{
			try
			{
				CopyFile(tempUpdatePath, Directory.GetCurrentDirectory());
				Directory.Delete(tempUpdatePath, true);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}
			Process.Start(mainAppExe);
		}

		private void LvUpdateList_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Application.Restart();
		}
	}
}
