using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

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
            sURL = "http://www.microsoft.com";

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
                    Console.WriteLine("{0}:{1}", i, sLine);
            }
            Console.ReadLine();
        }


    }
}