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
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVCPresentation.Controllers
{
    public class SheltersController : Controller
    {
        private MasterManager _masterManager = MasterManager.GetMasterManager();
        private List<Shelter> _shelters;
        //private ApplicationUserManager applicationUserManager;

        // GET: Events
        public ActionResult Index()
        {
            ViewBag.Tab = "Shelters";
            return View();
        }

        public SheltersController()
        {
            ViewBag.Tab = "Shelters";
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
        public ActionResult ShelterNetwork()
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

        // GET: Shelters
        public ActionResult SelectShelter()
        {
            ViewBag.Tab = "Shelters";
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
            ViewBag.Tab = "Shelters";
            var dbContext = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));
            var user = userManager.FindById(User.Identity.GetUserId());

            try
            {
                //var user = _masterManager.UsersManager.RetrieveUserByUsersId(100003);

                _masterManager.UsersManager.EditUserShelterId((int)user.UsersId, id, user.ShelterId);

                // update asp users shelterid
                user.ShelterId = id;
                dbContext.SaveChanges();

                return RedirectToAction("Index", "UserProfile");
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "There was a problem saving your data";
                return View("Error");
            }
        }
    }
}