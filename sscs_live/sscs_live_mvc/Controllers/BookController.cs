using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSCS_LIVE.Domain.Entities;
using SSCS_LIVE.Domain.Context;
using SSCS_LIVE_MVC.ApiAccess;
using System.Xml.Linq;

namespace SSCS_LIVE_MVC.Controllers
{
    public class BookController : Controller
    {
        private StoreContext db = new StoreContext();

        //
        // GET: /Book/

        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        //
        // GET: /Book/Details/5

        public ActionResult Details(string id = null)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // Allow the user to add a book by providing only the ISBN
        [HttpGet]
        public ViewResult OneClickAdd()
        {
            return View(new Book());
        }

        [HttpPost]
        public ActionResult OneClickAdd(Book book)
        {
            IEnumerable<XElement> found = CampusBookAccess.bookLookUp(book.ISBN).Descendants("page");

            foreach (var onlineB in found)// fetch the info of the book
            {               
                //b.ISBN = onlineB.Element("isbn10").Value;
                book.Title = onlineB.Element("title").Value;
                book.Picture = onlineB.Element("image").Value;
                book.AuthorFirstN = onlineB.Element("author").Value;
            }
            if (ModelState.IsValid && book.Price != 0.00)
            {
                string time = System.DateTime.UtcNow.ToString();
                book.BookId = System.DateTime.UtcNow.ToString().Replace(" ", "0").Replace(":", "0").Replace("AM", "1").
                    Replace("PM ", "0").Replace("/", "2");
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        //
        // GET: /Book/Create

        public ActionResult Create()
        {
            return View();
        }

        

        //
        //
        // POST: /Book/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.BookId = System.DateTime.UtcNow.ToString().Replace(" ", "0").Replace(":", "0").Replace("AM", "1").
                    Replace("PM ", "0").Replace("/", "2");
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        //
        // GET: /Book/Edit/5

        public ActionResult Edit(string id = null)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        //
        // GET: /Book/Delete/5

        public ActionResult Delete(string id = null)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Book/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}