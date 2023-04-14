using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCPresentation.Controllers
{
    public class SheltersController : Controller
    {
        private MasterManager masterManager = MasterManager.GetMasterManager();

        // GET: Shelters
        public ActionResult Index()
        {
            List<Shelter> shelters = new List<Shelter>();
            try
            {
                shelters = masterManager.ShelterManager.GetShelterList();
                if (shelters == null)
                {
                    throw new Exception("Shelter data could not be found.");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
            return View(shelters);
        }
    }
}