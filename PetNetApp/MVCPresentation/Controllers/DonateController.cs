using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer;
using DataObjects;

namespace MVCPresentation.Controllers
{
    public class DonateController : Controller
    {
        private MasterManager _masterManager = MasterManager.GetMasterManager();
        // GET: Donate
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Donations");
        }

        // GET: Donate
        public ActionResult Donate()
        {

            try
            {
                ViewBag.Shelters = _masterManager.ShelterManager.GetShelterList();
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }

        // POST: Donation/Create
        [HttpPost]
        public ActionResult Donate(Donation donation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Logic to add donation to the database
                    try
                    {
                        _masterManager.DonationManager.AddDonation(donation);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = ex.Message + "<br/><br/>" + ex.InnerException.Message;
                        return View("Error");
                    }

                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ViewBag.Message = ex.Message + "<br/><br/>" + ex.InnerException.Message;
                    return View("Error");
                }
            }
            else // model was not valid
            {
                try
                {
                    ViewBag.Shelters = _masterManager.ShelterManager.GetShelterList();
                }
                catch(Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return View("Error");
                }
            }
            return View();
        }


    }
}

