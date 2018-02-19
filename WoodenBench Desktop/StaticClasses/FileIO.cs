using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using WoodenBench.DelegateClasses;

namespace WoodenBench.StaticClasses
{
    public class FileIO
    {
        public static event FileIOCompletedEventHandler onFileIOCompleted;

        private static void _HttpDownload(string RemoteURL, string LocalAddress, DownloadType type)
        {
            string tempPath = Path.GetDirectoryName(LocalAddress);
            Directory.CreateDirectory(tempPath);  //创建临时文件目录
            string tempFile = tempPath + @"\" + Path.GetFileName(LocalAddress) + ".temp"; //临时文件
            if (File.Exists(tempFile)) File.Delete(tempFile);
            if (File.Exists(LocalAddress)) File.Delete(LocalAddress);
            FileStream fs = new FileStream(tempFile, FileMode.CreateNew, FileAccess.ReadWrite);
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(RemoteURL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();

                byte[] arrivedBytes = new byte[1024];
                int size = responseStream.Read(arrivedBytes, 0, (int)arrivedBytes.Length);
                int Length = size;
                while (size > 0)
                {
                    fs.Write(arrivedBytes, 0, size);
                    size = responseStream.Read(arrivedBytes, 0, (int)arrivedBytes.Length);
                }
                fs.Close();
                responseStream.Close();
                File.Move(tempFile, LocalAddress);
                IOCompleted(ProcStatE.Completed, LocalAddress, 0, type, RemoteURL, null);
                return;
            }
            catch (Exception ex)
            {
                fs.Close();
                IOCompleted(ProcStatE.FailedWithErr, LocalAddress, 0, type, RemoteURL, ex, null);
                return;
            }
        }

        private static void IOCompleted(ProcStatE Status, string LocalPath, int len, DownloadType type, string RmtURL = "", Exception exp = null, object Rtnobj = null)
        {
            FileIOEventArgs e = new FileIOEventArgs()
            {
                RemoteURL = RmtURL,
                LocalFilePath = LocalPath,
                ProcessStatus = Status,
                Exception = exp,
                ReturnObject = Rtnobj,
                FileLength = len,
                DownloadType = type
            };
            if (onFileIOCompleted != null) { onFileIOCompleted(e); }
            e = null;
        }

        public static byte[] ReadFileBytes(string filePath)
        {
            if (!File.Exists(filePath)) { return new byte[0]; }
            FileStream fs = File.OpenRead(filePath);
            int filelength = 0;
            filelength = (int)fs.Length; //获得文件长度 
            byte[] p = new byte[filelength]; //建立一个字节[]
            fs.Read(p, 0, filelength);
            return p;
        }

        public static Image BytesToImage(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }

        public static void DownloadFile(string RemoteURL, string LocalPath, DownloadType type)
        {
            new Thread(new ThreadStart(delegate { _HttpDownload(RemoteURL, LocalPath, type); }))
            { Name = "Download file", IsBackground = false }.Start();

        }
    }

    public class FileIOEventArgs : InternalEventArgs
    {
        public FileIOEventArgs() { }
        public DownloadType DownloadType { get; set; }
        public string RemoteURL { get; set; }
        public int FileLength { get; set; }
        public string LocalFilePath { get; set; }
        public object ReturnObject { get; set; }
    }
}
