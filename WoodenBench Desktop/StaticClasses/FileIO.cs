using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

using WBPlatform.StaticClasses;
using WBPlatform.WinClient.DelegateClasses;

namespace WBPlatform.WinClient.StaticClasses
{
    public class FileIO
    {
        public static event FileIOCompletedEventHandler onFileIOCompleted;

        private static void _HttpDownload(string RemoteURL, string LocalFilePath)
        {
            string tempPath = Path.GetDirectoryName(LocalFilePath);
            Directory.CreateDirectory(tempPath);
            string tempFile = tempPath + @"\" + Path.GetFileName(LocalFilePath) + ".temp";
            if (File.Exists(tempFile)) File.Delete(tempFile);
            if (File.Exists(LocalFilePath)) File.Delete(LocalFilePath);
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
                File.Move(tempFile, LocalFilePath);
                IOCompleted(true, LocalFilePath, RemoteURL);
            }
            catch (Exception ex)
            {
                fs.Close();
                IOCompleted(false, LocalFilePath, RemoteURL);
            }
        }

        private static void IOCompleted(bool _Status, string _LocalPath, string _ErrDetail)
        {
            FileIOEventArgs e = new FileIOEventArgs()
            {
                LocalFilePath = _LocalPath,
                isSucceed = _Status,
                ErrDescription = _ErrDetail
            };
            if (onFileIOCompleted != null) { onFileIOCompleted(e); }
        }

        public static byte[] ReadFileBytes(string filePath)
        {
            if (!File.Exists(filePath)) { return new byte[0]; }
            FileStream fs = File.OpenRead(filePath);
            int filelength = 0;
            filelength = (int)fs.Length;
            byte[] p = new byte[filelength];
            fs.Read(p, 0, filelength);
            return p;
        }

        public static Image BytesToImage(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }

        public static void DownloadFile(string RemoteURL, string LocalPath)
        {
            new Thread(new ThreadStart(() => _HttpDownload(RemoteURL, LocalPath))).Start();
        }
    }

    public class FileIOEventArgs : InternalEventArgs
    {
        public FileIOEventArgs() { }
        public string LocalFilePath { get; set; }
    }
}
