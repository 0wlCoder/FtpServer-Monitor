using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    class FtpDownload
    {

        public void DownloadManager(string Server_Fn )
        {


            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential(Config.ftpUsername1, Config.ftpPassword1);

                byte[] fileData = request.DownloadData("ftp://files.000webhost.com/" + Server_Fn) ;

                using (FileStream file = File.Create(Config.InstallFolder + Server_Fn))
                {
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                }

            }

        }
    }

}