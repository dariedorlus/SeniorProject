using SSCS_LIVE.Domain.DataLogic;
using SSCS_LIVE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSCS_LIVE_MVC.Models
{
    public class CartModelView
    {
        public ShoppingCart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}