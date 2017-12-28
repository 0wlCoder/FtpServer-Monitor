using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorInstaller
{
    class Config
    {
        public static string InstallFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Monitor\");


        public static string cRegVal;
        public static string monitorPath = InstallFolder + "Monitor";


        public static string ftpServerUrl1 = "files.000webhost.com";
        public static string ftpUsername1 = "monitorftp3";
        public static string ftpPassword1 = "monitor123";

    }
}
