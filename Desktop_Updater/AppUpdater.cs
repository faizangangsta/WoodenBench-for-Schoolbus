using System;
using System.Web;
using System.IO;
using System.Net;
using System.Xml;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Net.Http;

namespace Desktop_Updater
{
	/// <summary>
	/// updater 的摘要说明。
	/// </summary>
	public class AppUpdater : IDisposable
	{
		#region 成员与字段属性
		private bool disposed = false;
		private IntPtr Handle;
		private Component component = new Component();
		public static string UpdaterUrl;
		#endregion

		/// <summary>
		/// AppUpdater构造函数
		/// </summary>
		public AppUpdater()
		{
			Handle = Handle;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		private void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					component.Dispose();
				}
			}
			disposed = true;
		}

		~AppUpdater()
		{
			Dispose(false);
		}


		/// <summary>
		/// 检查更新文件
		/// </summary>
		/// <param name="serverXmlFile"></param>
		/// <param name="localXmlFile"></param>
		/// <param name="updateFileList"></param>
		/// <returns></returns>
		public static int CheckForUpdate(string serverXmlFile, string localXmlFile, out Hashtable updateFileList)
		{
			updateFileList = new Hashtable();
			if (!File.Exists(localXmlFile) || !File.Exists(serverXmlFile)) return -1;


			XmlFiles serverXmlFiles = new XmlFiles(serverXmlFile);
			XmlFiles localXmlFiles = new XmlFiles(localXmlFile);

			XmlNodeList NewFilesNodeList = serverXmlFiles.GetNodeList("AutoUpdater/Files");
			XmlNodeList OldFilesNodeList = localXmlFiles.GetNodeList("AutoUpdater/Files");

			int k = 0;
			for (int i = 0; i < NewFilesNodeList.Count; i++)
			{
				string[] FileListArray = new string[3];

				string newFileName = NewFilesNodeList.Item(i).Attributes["Name"].Value.Trim();
				string newFileVer = NewFilesNodeList.Item(i).Attributes["Ver"].Value.Trim();

				ArrayList OldFilesArray = new ArrayList();
				for (int j = 0; j < OldFilesNodeList.Count; j++)
				{
					string oldFileName = OldFilesNodeList.Item(j).Attributes["Name"].Value.Trim();
					string oldFileVer = OldFilesNodeList.Item(j).Attributes["Ver"].Value.Trim();

					OldFilesArray.Add(oldFileName);
					OldFilesArray.Add(oldFileVer);
				}
				int PostionOfFile = OldFilesArray.IndexOf(newFileName);
				if (PostionOfFile == -1)
				{
					FileListArray[0] = newFileName;
					FileListArray[1] = newFileVer;
					updateFileList.Add(k, FileListArray);
					k++;
				}
				else if (PostionOfFile > -1 && newFileVer.CompareTo(OldFilesArray[PostionOfFile + 1].ToString()) > 0)
				{
					FileListArray[0] = newFileName;
					FileListArray[1] = newFileVer;
					updateFileList.Add(k, FileListArray);
					k++;
				}
			}
			return k;
		}

		/// <summary>
		/// 检查更新文件
		/// </summary>
		/// <param name="serverXmlFile"></param>
		/// <param name="localXmlFile"></param>
		/// <param name="updateFileList"></param>
		/// <returns></returns>
		public static int CheckForUpdate()
		{
			string localXmlFile = Application.StartupPath + "\\UpdateList.xml";
			if (!File.Exists(localXmlFile)) return -1;

			XmlFiles updaterXmlFiles = new XmlFiles(localXmlFile);

			string tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\" + "_" + updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value + "_" + "y" + "_" + "x" + "_" + "m" + "_" + "\\";
			UpdaterUrl = updaterXmlFiles.GetNodeValue("//Url") + "/UpdateList.xml";
			DownAutoUpdateFile(tempUpdatePath);

			string serverXmlFile = tempUpdatePath + "\\UpdateList.xml";
			if (!File.Exists(serverXmlFile))
			{
				return -1;
			}

			XmlFiles serverXmlFiles = new XmlFiles(serverXmlFile);
			XmlFiles localXmlFiles = new XmlFiles(localXmlFile);

			XmlNodeList newNodeList = serverXmlFiles.GetNodeList("AutoUpdater/Files");
			XmlNodeList oldNodeList = localXmlFiles.GetNodeList("AutoUpdater/Files");

			int k = 0;
			for (int i = 0; i < newNodeList.Count; i++)
			{
				string[] fileList = new string[3];

				string newFileName = newNodeList.Item(i).Attributes["Name"].Value.Trim();
				string newVer = newNodeList.Item(i).Attributes["Ver"].Value.Trim();

				ArrayList oldFileAl = new ArrayList();
				for (int j = 0; j < oldNodeList.Count; j++)
				{
					string oldFileName = oldNodeList.Item(j).Attributes["Name"].Value.Trim();
					string oldVer = oldNodeList.Item(j).Attributes["Ver"].Value.Trim();

					oldFileAl.Add(oldFileName);
					oldFileAl.Add(oldVer);

				}
				int pos = oldFileAl.IndexOf(newFileName);
				if (pos == -1)
				{
					fileList[0] = newFileName;
					fileList[1] = newVer;
					k++;
				}
				else if (pos > -1 && newVer.CompareTo(oldFileAl[pos + 1].ToString()) > 0)
				{
					fileList[0] = newFileName;
					fileList[1] = newVer;
					k++;
				}

			}
			return k;
		}

		/// <summary>
		/// 下载文件
		/// </summary>
		/// <returns>
		/// 啥也不返回
		/// </returns>
		public static void DownAutoUpdateFile(string downpath)
		{
			if (!System.IO.Directory.Exists(downpath)) System.IO.Directory.CreateDirectory(downpath);
			string serverXmlFile = downpath + @"/UpdateList.xml";

			try
			{
				//WebRequest req = WebRequest.Create(UpdaterUrl);
				//Microsoft.VisualBasic.Devices.Network NetWk = new Microsoft.VisualBasic.Devices.Network();
				//NNtWk.DownloadFile(UpdaterUrl, serverXmlFile, "", "", true, 10000, true, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
				//iWebResponse res = req.GetResponse();
				//if (res.ContentLength > 0)
				//{
				//	try
				//	{
				WebClient wClient = new WebClient();
				wClient.DownloadFile(UpdaterUrl, serverXmlFile);
				//	}
				//	catch (Exception EX)
				//	{
				//		throw;
				//		return;
				//	}

				//}
			}
			catch
			{
				return;
			}
		}
	}
}