using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPresentation.Controllers
{
    public class SheltersController : Controller
    {
        // GET: Shelters
        public ActionResult Index()
        {
            return View();
        }
    }
}