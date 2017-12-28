using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    class FtpDelete
    {
        private string host = null;
        private string user = null;
        private string pass = null;
        private FtpWebRequest ftpRequest = null;
        private FtpWebResponse ftpResponse = null;
        private Stream ftpStream = null;
        private int bufferSize = 2048;

        public void DeleteManager(string Server_Fn)
        {
            try
            {
                
                ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://files.000webhost.com/" + Server_Fn);
                ftpRequest.Credentials = new NetworkCredential(Config.ftpUsername1, Config.ftpPassword1);
             
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
               
                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }


    }
}
