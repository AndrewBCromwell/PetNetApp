using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects;
using LogicLayer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


namespace MVCPresentation.Controllers
{
    public class UserDonationsController : Controller
    {
        private MasterManager masterManager = MasterManager.GetMasterManager();
        private List<DonationVM> donationVMs;
        private DonationVM donationVM;
        private ApplicationUserManager userManager;
        

        // GET: UserDonations
        public ActionResult Index()
        {
            userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindById(User.Identity.GetUserId());
            try
            {
                donationVMs = masterManager.DonationManager.RetrieveDonationsByUserId(100001);
                ViewBag.User = masterManager.UsersManager.RetrieveUserByUsersId(100001);
            }
            catch (Exception)
            {
                ViewBag.Message = "Could not retrieve donations";
                View("Error");
            }
            return View(donationVMs);
        }

        // GET: UserDonations/Details/5
        public ActionResult Details(int? id)
        {
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

        //// GET: UserDonations/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: UserDonations/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

 
    }
}
