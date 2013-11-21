using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Web.Mvc;
using SSCSFIU_MVC.Models;

namespace SSCSFIU_MVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        string url = "http://api2.campusbooks.com/12/rest/prices?key=ss2ky20Ev4PGm9dZHE&isbn=0132916525";
         WebRequest wrGETURL;
            

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            ViewBag.Darie = "No problem";
           
            return View();
            
        }

        [HttpGet]
        public ViewResult RSVP()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RSVP(GuestInfo guest)
        {
            if (ModelState.IsValid)
            {
                wrGETURL = WebRequest.Create(this.url);
                WebProxy myProxy = new WebProxy("myproxy", 80);
                myProxy.BypassProxyOnLocal = true;

                // wrGETURL.Proxy = WebProxy.GetDefaultProxy();

                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                string sLine = "";
                string s = "";
                int i = 0;

                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                        // Console.WriteLine("{0}:{1}", i, sLine);
                        System.Diagnostics.Trace.WriteLine(sLine);
                }
                       Console.ReadLine();
                
                
                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
            
        }


    }
}
