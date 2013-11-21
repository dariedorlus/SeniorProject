using SSCS_LIVE.Domain.DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSCS_LIVE_MVC.Binder
{
    public class CartBinder : IModelBinder, CartIdInterface
    {
        private const string sessionKey = "Cart";
        

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // get the Cart from the session
            ShoppingCart cart = (ShoppingCart)controllerContext.HttpContext.Session[sessionKey];
            // create the Cart if there wasn't one in the session data
            if (cart == null)
            {
                cart = new ShoppingCart(CartId++);
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }
            // return the cart
            return cart;

        }

        public int CartId
        {
            get;
            set;
        }
    }
}
