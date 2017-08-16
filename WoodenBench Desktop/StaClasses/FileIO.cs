using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using WoodenBench.DelegateClasses;

namespace WoodenBench.StaClasses
{
    public class FileIO
    {
        public static event FileIOCompletedEventHandler onFileIOCompleted;
        private Thread BusyThread = new Thread(new ThreadStart(delegate { }));
        private void _HttpDownload(string url, string path)
        {
            string tempPath = Path.GetDirectoryName(path) + @"\temp";
            Directory.CreateDirectory(tempPath);  //创建临时文件目录
            string tempFile = tempPath + @"\" + Path.GetFileName(path) + ".temp"; //临时文件
            if (System.IO.File.Exists(tempFile)) System.IO.File.Delete(tempFile);
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite, 4096);

                byte[] arrivedBytes = new byte[1024];
                int size = responseStream.Read(arrivedBytes, 0, (int)arrivedBytes.Length);
                while (size > 0)
                {
                    fs.Write(arrivedBytes, 0, size);
                    size = responseStream.Read(arrivedBytes, 0, (int)arrivedBytes.Length);
                }
                fs.Close();
                responseStream.Close();
                File.Move(tempFile, path);
                IOCompleted(url, path, ProcStatE.Completed);
                return;
            }
            catch (Exception ex)
            {
                IOCompleted(url, path, ProcStatE.FailedWithErr, Detail: ex.Message);
                return;
            }
        }
        private static void IOCompleted(string RmtURL, string LocalPath, ProcStatE Status, string Detail = "")
        {
            fileIOCompletedEventArgs e = new fileIOCompletedEventArgs()
            {
                RemoteURL = RmtURL,
                LocalFilePath = LocalPath,
                ProcessStatus = Status,
                Description = Detail
            };
            if (onFileIOCompleted != null) { onFileIOCompleted(e); }
            e = null;
        }

        public void DownloadFile(string RemoteURL, string LocalPath)
        {
            if (!BusyThread.IsAlive || BusyThread == null)
            {
                BusyThread = new Thread(new ThreadStart(delegate { _HttpDownload(RemoteURL, LocalPath); }))
                { Name = "Download file", IsBackground = false };
                BusyThread.Start();
            }
        }

    }

    public class fileIOCompletedEventArgs : internalEventArgs
    {
        public fileIOCompletedEventArgs() { }
        public string RemoteURL { get; set; }
        public string LocalFilePath { get; set; }
    }
}
