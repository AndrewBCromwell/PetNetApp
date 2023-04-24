using DataObjects;
using LogicLayer;
using Microsoft.AspNet.Identity;
using MVCPresentation.Models;
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

        // Code by Alexis Oetken 
        public ActionResult AddBookmark(int? animalID, Users user)
        {
            var bookmarkManager = new LogicLayer.BookmarkManager();
            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.User = user; 

                    if (animalID == null)
                    {
                        ViewBag.Message = "Something went wrong! Please try again.";
                        return View("Error");
                    }

                    if (user == null)
                    {
                        ViewBag.Message = "Please sign in to use this feature.";
                        return View("Error");
                    }

                    else
                    {
                        bookmarkManager.AddBookmark((int)user.UsersId, (int)animalID);
                        return RedirectToAction("Index");
                    }

                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View("Error");
                }
            }
            return View();
        }

        //Code by Alexis Oetken 
        public ActionResult DeleteBookmark(int? animalID, Users user)
        {
            try
            {
                var bookmarkManager = new LogicLayer.BookmarkManager();

            ViewBag.User = user;

            bookmarkManager.DeleteBookmark((int)user.UsersId, (int)animalID);
            return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
            

        }

        // Code by Alexis Oetken 
        public ActionResult ViewAllBookmarks(int userID)
        {
            try
            {
                var bookmarkManager = new LogicLayer.BookmarkManager();

                List<DataObjects.Bookmark> bookmarkList = bookmarkManager.RetrieveAllBookmarks(userID);

                return View("BookmarksView", bookmarkList);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("Error");
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