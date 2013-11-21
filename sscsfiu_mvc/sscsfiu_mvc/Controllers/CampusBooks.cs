using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using SSCSFIU_MVC.Models;
using System.Diagnostics;

namespace SSCSFIU_MVC.Controllers
{
    public class CampusBooks
    {
        private string url;
       // private Enumerable linq;
        


        public CampusBooks(string url)
        {
            this.url = url;
            
        }

        private void getInfo(string ur)
        {
 
        }

        static void Main(string[] args)
        {
            string sURL;
            sURL = "http://api2.campusbooks.com/12/rest/bookInfo?key=ss2ky20Ev4PGm9dZHE&isbn=0132916525[&image_height = 8][&image_width = 8]";

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);

            WebProxy myProxy = new WebProxy("myproxy", 80);
            myProxy.BypassProxyOnLocal = true;

           // wrGETURL.Proxy = WebProxy.GetDefaultProxy();

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                    Trace.WriteLine(sLine);
            }
            Console.ReadLine();
        }


    }
}