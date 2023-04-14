using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer;
using DataObjects;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using MVCPresentation.Models;



namespace MVCPresentation.Controllers
{
    public class SheltersController : Controller
    {
        private MasterManager _masterManager = MasterManager.GetMasterManager();
        private List<Shelter> _shelters;
        private ApplicationUserManager applicationUserManager;



        public SheltersController()
        {
            try
            {
                _shelters = _masterManager.ShelterManager.GetShelterList();
            }
            catch (Exception)
            {
                // redirect to error page if need be
                throw;
            }
        }

        // GET: Shelters
        public ActionResult Index()
        {
            List<Shelter> shelters = new List<Shelter>();
            try
            {
                shelters = _masterManager.ShelterManager.GetShelterList();
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



        // GET: SelectedShelters
        public ActionResult SelectedShelter(int id)
        {
            applicationUserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = applicationUserManager.FindById(User.Identity.GetUserId());

            try
            {
                //var user = _masterManager.UsersManager.RetrieveUserByUsersId(100003);

                _masterManager.UsersManager.EditUserShelterId((int)user.UsersId, id, user.ShelterId);

                // update asp users shelterid

                return RedirectToAction("Index", "Community");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}