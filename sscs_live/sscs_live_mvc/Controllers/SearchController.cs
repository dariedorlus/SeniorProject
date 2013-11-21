using SSCS_LIVE.Domain.DataInterface;
using SSCS_LIVE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSCS_LIVE_MVC.ApiAccess;
using System.Xml.Linq;

namespace SSCS_LIVE_MVC.Controllers
{
    public class SearchController : Controller
    {
        private BookInterface dbBooks;
        //private string isbn;
         
        //
        // GET: /Search/

        public SearchController(BookInterface books)
        {
            this.dbBooks = books;
        }

        [HttpGet]
        public ViewResult GetISBN()
        {
            return View(new Book());
        }

        [HttpPost]
        public ActionResult Search(Book book)
        {
            //string isbn = "";
            List<Book> bookList = new List<Book>();
            
            /*
             * Searching the books of the database  
             * 
             * */
           foreach( Book b in dbBooks.Books)
             if (b.ISBN == book.ISBN)
                bookList.Add(b);
           

            /*
             * Searching online books
             * 
             * */
           IEnumerable<XElement> found = CampusBookAccess.bookLookUp(book.ISBN).Descendants("page");

           foreach (var onlineB in found)
           {
               //Book b = new Book();
               //b.ISBN = onlineB.Element("isbn10").Value;
               //b.Title = onlineB.Element("Title").Value;
               bookList.Add(new Book
               {
                   ISBN = onlineB.Element("isbn10").Value,
                   Title = onlineB.Element("title").Value,
                   Picture = onlineB.Element("image").Value
               });


           }
             return View(bookList);
        }
        
        private bool searchBook(string isbn)
        {
            var seek = from bks in dbBooks.Books
                       where bks.ISBN.Equals(isbn)
                       select isbn;
            foreach (string s in seek)
            {
 
            }



            return false;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
