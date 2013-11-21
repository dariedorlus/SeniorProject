using SSCS_LIVE.Domain.DataInterface;
using SSCS_LIVE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSCS_LIVE_MVC.Models;
using SSCS_LIVE.Domain.Context;
using SSCS_LIVE.Domain.DataLogic;
using SSCS_LIVE_MVC.Binder;


namespace SSCS_LIVE_MVC.Controllers
{
    public class CartController : Controller, CartIdInterface
    {
        private BookInterface dbBooks;
        private static int cartID = 0; //To make each shopping cart Unique


        //
        // GET: /Cart/

        public ViewResult CartHome(string rUrl)
        {
            return View(new CartModelView
                {
                    Cart = getCart(),
                    ReturnUrl = rUrl
                });
        }

        public CartController(BookInterface dbBooks)
        {
            this.dbBooks = dbBooks;
        }

        public RedirectToRouteResult AddToCart(string bookId, string returnUrl, ShoppingCart cart)
        {
            Book book = dbBooks.Books //retrieve books from db
           .FirstOrDefault(p => p.BookId == bookId);

            if (book != null)
            {
                getCart().addToCart(book);
            }

            return RedirectToAction("CartHome", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(string bookId, string returnUrl, ShoppingCart cart)
        {
            //Retreive the book from the db
            Book book = dbBooks.Books
           .FirstOrDefault(p => p.BookId == bookId);

            if (book != null)
            {
                getCart().removeBook(book); // removing book from cart
            }
            return RedirectToAction("CartHome", new { returnUrl });
        }

        private ShoppingCart getCart()
        {
            /**
             * 
             * Create a new Cart if there is none, otherwise return the current for the seesion
             * 
             * */

            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart == null)
            {
                cart = new ShoppingCart(cartID++);
                Session["Cart"] = cart;
            }
            return cart;
        }



        public int CartId
        {
            get
            {
                return cartID;
            }
            set
            {
                cartID = value;
            }
        }
    }
}
