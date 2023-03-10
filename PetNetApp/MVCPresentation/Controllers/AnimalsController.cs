using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPresentation.Controllers
{
    public class AnimalsController : Controller
    {
        // GET: Animals
        public ActionResult Adopt()
        {
            return View();
        }

        public ActionResult Foster()
        {
            return View();
        }

        public ActionResult Surrender()
        {
            return View();
        }
    }
}