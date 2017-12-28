using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    class Config
    {

        public static string InstallFolder =  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Monitor\");
        public static string Tracker = "Testing.txt";





        //Ftp server login to upload all files to.
        public static string ftpServerUrl = "files.000webhost.com";
        public static string ftpUsername = "monitorftp";
        public static string ftpPassword = "monitor123";


        //Ftp server login to download all files this ftp
        public static string ftpServerUrl1 = "files.000webhost.com";
        public static string ftpUsername1 = "monitorftp3";
        public static string ftpPassword1 = "monitor123";

    }
}
