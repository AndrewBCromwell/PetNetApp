using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPresentation.Controllers
{
    public class UserProfileController : Controller
    {
        MasterManager _manager = MasterManager.GetMasterManager();
        // GET: UserProfile
        public ActionResult Index()
        {

            return View();
        }

        // GET: UserProfile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProfile/Create
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

        // GET: UserProfile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserProfile/Edit/5
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

        // GET: UserProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserProfile/Delete/5
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

        /// <summary>
        /// Molly Meister
        /// Created: 2023/04/23
        /// 
        /// Displays the adoption applications for the user.
        /// <paramref name="userId"/>
        /// </summary>
        //GET: UserProfile/MyApplications/6
        [ChildActionOnly]
        public ActionResult AdoptionApplicationsPartial(int userId)
        {
            try
            {
                List<AdoptionApplicationVM> applications = _manager.AdoptionApplicationManager.RetrieveAllAdoptionApplicationsByUsersId(userId);
                return PartialView(applications);
            }
            catch (Exception up)
            {
                ViewBag.Message = up.Message;
                return View("Error");
                //return View("Error");
            }
        }


    }
}
