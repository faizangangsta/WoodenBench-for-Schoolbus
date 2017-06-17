using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Desktop_Updater
{
    /// <summary>
    /// Form1 ��ժҪ˵����
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
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;


		public MainWindow() { InitializeComponent(); }

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null) { components.Dispose(); }
			}
			base.Dispose(disposing);
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
            this.label1.Text = "����Ϊ�����ļ��б�";
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
            this.chFileName.Text = "�����";
            this.chFileName.Width = 175;
            // 
            // chVersion
            // 
            this.chVersion.Text = "�汾��";
            this.chVersion.Width = 163;
            // 
            // chProgress
            // 
            this.chProgress.Text = "����";
            this.chProgress.Width = 85;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(371, 356);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 24);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "��һ��(&N)>";
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(457, 356);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "�ر�(&C)";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Location = new System.Drawing.Point(285, 356);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(80, 24);
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "���(&F)";
            this.btnFinish.Click += new System.EventHandler(this.BtnFinish_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(12, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 10;
            this.button1.Text = "ˢ��(&R)";
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
            this.Text = "������";
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
				//�ӱ��ض�ȡ���������ļ���Ϣ
				updaterXmlFiles = new XmlFiles(localXmlFile);
			}
			catch
			{
				MessageBox.Show("�����ļ�����!", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
				return;
			}
			//��ȡ��������ַ
			updateUrlOnline = updaterXmlFiles.GetNodeValue("//Url");

			AppUpdater.UpdaterUrl = updateUrlOnline + "/UpdateList.xml";
		
			//�����������,���ظ��������ļ�
			try
			{
				tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\" +
                    "_" + updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value + "_y_x_m_\\";
				AppUpdater.DownAutoUpdateFile(tempUpdatePath);
			}
			catch(Exception ExpTion)
			{
				MessageBox.Show(ExpTion.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Close();
				return;
			}
			//��ȡ�����ļ��б�
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

					//lbState.Text = "�������ظ����ļ�,���Ժ�...";
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
						MessageBox.Show("�����ļ�����ʧ��!" + Environment.NewLine + ex.Message.ToString(), "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				MessageBox.Show("û�п��õĸ���!", "�Զ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
		}
		//����Ŀ¼
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

		//�����ļ�;
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
		//�����ɸ��Ƹ����ļ���Ӧ�ó���Ŀ¼
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
