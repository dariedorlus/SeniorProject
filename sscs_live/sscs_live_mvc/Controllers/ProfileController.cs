using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSCS_LIVE.Domain.Entities;
using SSCS_LIVE.Domain.Context;
using SSCS_LIVE.Domain.DataInterface;

namespace SSCS_LIVE_MVC.Controllers
{
    public class ProfileController : Controller
    {
        private UserInterface users;
        //
        // GET: /Profile/
        public ProfileController(UserInterface uInterface)
        {
            this.users = uInterface;
        }

        public ViewResult UserProfile()
        {
            
            return View(users.Users);
        }

    }
}
