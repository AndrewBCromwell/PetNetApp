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
            try
            {
                donationVMs = masterManager.DonationManager.RetrieveAllDonations();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(donationVMs);
        }

        // GET: Donations/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                try
                {
                    donationVM = masterManager.DonationManager.RetrieveDonationByDonationId(id.Value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
                        Console.WriteLine(ex.Message);
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
