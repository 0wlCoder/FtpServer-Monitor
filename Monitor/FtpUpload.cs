using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    class FtpUpload
    {
       

        public void Upload(string Server_Fn)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                client.Credentials = new System.Net.NetworkCredential(Config.ftpUsername,Config.ftpPassword);
                client.UploadFile("ftp://files.000webhost.com/" + new FileInfo(Config.InstallFolder + Server_Fn).Name, "STOR" , Config.InstallFolder + Server_Fn);
            }
        }


    }

}

