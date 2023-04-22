using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects;
using LogicLayer;

namespace MVCPresentation.Controllers
{
    public class DonationsController : Controller
    {
        private MasterManager masterManager = MasterManager.GetMasterManager();
        private List<DonationVM> donationVMs;
        private DonationVM donationVM;

        // GET: Donations
        public ActionResult Index()
        {
            ViewBag.Tab = "Donate";
            try
            {
                donationVMs = masterManager.DonationManager.RetrieveAllDonations();
            }
            catch (Exception)
            {
                ViewBag.Message = "Could not retrieve donations";
                View("Error");
            }
            return View(donationVMs);
        }

        // GET: Donations/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Tab = "Donate";
            if (id != null)
            {
                try
                {
                    donationVM = masterManager.DonationManager.RetrieveDonationByDonationId(id.Value);
                }
                catch (Exception)
                {
                    ViewBag.Message = "Could not retrieve donation";
                    View("Error");
                }

                if (donationVM == null)
                {
                    ViewBag.Message = "No donation found";
                    return View("Error");
                } 
                else
                {
                    try
                    {
                        donationVM.InKindList = masterManager.DonationManager.RetrieveInKindsByDonationId(donationVM.DonationId);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = ex.Message;
                        return View("Error");
                    }
                }

                return View(donationVM);
            }
            else
            {
                ViewBag.Message = "No donation with that ID";
                return View("Error");
            }
        }

        // GET: Donations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donations/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Donations/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Donations/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Donations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Donations/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
