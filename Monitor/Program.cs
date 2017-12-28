using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    class Program
    {


        static void Main(string[] args)
        {

            string[] Logname = new string[1000];  
            FtpDownload  Obj_Download = new FtpDownload();
            FtpDelete    Obj_Delete = new FtpDelete();
            FtpFileCheck Obj_Checker = new FtpFileCheck();
            FtpUpload    Obj_Upload = new FtpUpload();

            if (!Directory.Exists(Config.InstallFolder))
            {
                Directory.CreateDirectory(Config.InstallFolder);
            }

            if (!File.Exists(Config.InstallFolder + Config.Tracker))
            {

                using (WebClient request = new WebClient())
                {
                    request.Credentials = new NetworkCredential(Config.ftpUsername1, Config.ftpPassword1);

                    byte[] fileData = request.DownloadData("ftp://files.000webhost.com/" + Config.Tracker);

                    using (FileStream file = File.Create(Config.InstallFolder + Config.Tracker))
                    {
                        file.Write(fileData, 0, fileData.Length);
                        file.Close();
                    }

                }

                Logname = File.ReadAllLines(Config.InstallFolder + Config.Tracker);

                foreach (string lg in Logname)
                {

                    if (Obj_Checker.FileChecker(lg) == true)
                    {
                        Obj_Download.DownloadManager(lg);
                        Obj_Delete.DeleteManager(lg);
                        Obj_Upload.Upload(lg);
                        File.Delete(Config.InstallFolder + lg);

                    }
                    else
                    {
                        continue;
                    }

                }

            }
            else
            {
                using (WebClient request = new WebClient())
                {
                    request.Credentials = new NetworkCredential(Config.ftpUsername1, Config.ftpPassword1);

                    byte[] fileData = request.DownloadData("ftp://files.000webhost.com/" + Config.Tracker);

                    using (FileStream file = File.Create(Config.InstallFolder + Config.Tracker))
                    {
                        file.Write(fileData, 0, fileData.Length);
                        file.Close();
                    }

                }

                Logname = File.ReadAllLines(Config.InstallFolder + Config.Tracker);

                foreach (string lg in Logname)
                {

                    if (Obj_Checker.FileChecker(lg) == true)
                    {
                        Obj_Download.DownloadManager(lg);
                        Obj_Upload.Upload(lg);
                        Obj_Delete.DeleteManager(lg);
                        File.Delete(Config.InstallFolder + lg);
                    }
                    else
                    {


                        continue;


                    }

                }
            }


        }

    }
}
