using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    class FtpFileCheck
    {


        public bool FileChecker(string Server_Fn)
        {
            var request = (FtpWebRequest)WebRequest.Create("ftp://files.000webhost.com/" + Server_Fn);
            request.Credentials = new NetworkCredential(Config.ftpUsername1, Config.ftpPassword1);
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    return false;
            }
            return false;
        }


    }
}
