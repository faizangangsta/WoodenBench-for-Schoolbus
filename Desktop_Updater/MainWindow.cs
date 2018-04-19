using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace WBServicePlatform.InstallFinaliser
{
    /// <summary>
    /// Form1 ��ժҪ˵����
    /// </summary>
    public class MainWindow : System.Windows.Forms.Form
	{
		private ColumnHeader chFileName;
		private ColumnHeader chVersion;
		private ColumnHeader chProgress;
		private ListView lvUpdateList;
		private System.Windows.Forms.Label label1;
		private Button btnNext;
		private Button btnCancel;
		private Button btnFinish;
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
            label1 = new Label();
            lvUpdateList = new ListView();
            chFileName = new ColumnHeader();
            chVersion = new ColumnHeader();
            chProgress = new ColumnHeader();
            btnNext = new Button();
            btnCancel = new Button();
            btnFinish = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(10, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(136, 16);
            label1.TabIndex = 9;
            label1.Text = "����Ϊ�����ļ��б�";
            // 
            // lvUpdateList
            // 
            lvUpdateList.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right);
            lvUpdateList.Columns.AddRange(new ColumnHeader[] {
            chFileName,
            chVersion,
            chProgress});
            lvUpdateList.Location = new System.Drawing.Point(12, 28);
            lvUpdateList.Name = "lvUpdateList";
            lvUpdateList.Size = new System.Drawing.Size(525, 322);
            lvUpdateList.TabIndex = 6;
            lvUpdateList.UseCompatibleStateImageBehavior = false;
            lvUpdateList.View = View.Details;
            lvUpdateList.SelectedIndexChanged += new System.EventHandler(LvUpdateList_SelectedIndexChanged);
            // 
            // chFileName
            // 
            chFileName.Text = "�����";
            chFileName.Width = 175;
            // 
            // chVersion
            // 
            chVersion.Text = "�汾��";
            chVersion.Width = 163;
            // 
            // chProgress
            // 
            chProgress.Text = "����";
            chProgress.Width = 85;
            // 
            // btnNext
            // 
            btnNext.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            btnNext.Location = new System.Drawing.Point(371, 356);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(80, 24);
            btnNext.TabIndex = 3;
            btnNext.Text = "��һ��(&N)>";
            btnNext.Click += new System.EventHandler(BtnNext_Click);
            // 
            // btnCancel
            // 
            btnCancel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            btnCancel.Location = new System.Drawing.Point(457, 356);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(80, 24);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "�ر�(&C)";
            btnCancel.Click += new System.EventHandler(BtnCancel_Click);
            // 
            // btnFinish
            // 
            btnFinish.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            btnFinish.Location = new System.Drawing.Point(285, 356);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new System.Drawing.Size(80, 24);
            btnFinish.TabIndex = 3;
            btnFinish.Text = "���(&F)";
            btnFinish.Click += new System.EventHandler(BtnFinish_Click);
            // 
            // button1
            // 
            button1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            button1.Location = new System.Drawing.Point(12, 356);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 24);
            button1.TabIndex = 10;
            button1.Text = "ˢ��(&R)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(button1_Click);
            // 
            // MainWindow
            // 
            AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            ClientSize = new System.Drawing.Size(549, 392);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(lvUpdateList);
            Controls.Add(btnNext);
            Controls.Add(btnFinish);
            Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainWindow";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "������";
            Load += new System.EventHandler(FrmUpdate_Load);
            ResumeLayout(false);

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
                    "_" + updaterXmlFiles.FindNode("//A" +
                    "pplication").Attributes["applicati" +
                    "onId"].Value + "_y_x_m_\\";
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
                Cursor = Cursors.Default;
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
