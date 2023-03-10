using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Notifications()
        {
            return View();
            
        }

        public ActionResult UserProfile()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }
    }
}