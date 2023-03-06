using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class SubMenuController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Animals()
        {
            return View();
        }

        public ActionResult Shelters()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult Community()
        {
            return View();
        }

        public ActionResult Management()
        {
            return View();
        }

        public ActionResult Fundraising()
        {
            return View();
        }
    }
}