using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.IO;
using System.Net;

namespace SSCS_LIVE_MVC.ApiAccess
{
    public class CampusBookAccess
    {
        //set the permanent API for CampusBooks
        private static  string apiKey = "?key=ss2ky20Ev4PGm9dZHE&isbn=";
        private static  string apiBegin = "http://api2.campusbooks.com/12/rest/";
        private static string image_size = "&image_height=200&image_width=150";

        private static  Stream infoStream;
        private static WebRequest createUrl;
        private static WebProxy proxy;


        private static Stream setUrl(string userUrl)
        {
            createUrl = WebRequest.Create(userUrl);

            proxy = new WebProxy("myproxy", 80);
            proxy.BypassProxyOnLocal = true;
            
            
             return createUrl.GetResponse().GetResponseStream(); 
        }

        private static string buildUrl(string isbn, string apiCall)
        {
            return apiBegin + apiCall + apiKey + isbn +image_size; 
        }
       
        public static XDocument bookLookUp(string isbn)
        {
            string completeUrl = buildUrl(isbn, "bookinfo");

             infoStream = setUrl(completeUrl);
             // .Load(infoStream.ToString());
            return XDocument.Load(infoStream);
        }
    }
}