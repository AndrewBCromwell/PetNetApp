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
    /// <summary>
    /// William Rients
    /// Created: 2023/04/16
    /// 
    /// Management class
    /// </summary>
    public class ManagementController : Controller
    {
        private MasterManager masterManager = MasterManager.GetMasterManager();
        private ApplicationUserManager applicationUserManager;
        private List<TicketVM> ticketVMs;

        /// <summary>
        /// William Rients
        /// Created: 2023/04/16
        /// 
        /// Retrieves a list of tickets
        /// </summary>
        /// <returns></returns>
        // GET: Management
        [Authorize(Roles = "Admin, Administration")]
        public ActionResult Index()
        {
            try
            {
                ticketVMs = masterManager.TicketManager.RetrieveAllTickets();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + "<br /><br />" + ex.InnerException.Message;

                return View("Error");
            }
            return View(ticketVMs);
        }

        // GET: Management/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// William Rients
        /// Created: 2023/04/16
        /// 
        /// Get method for create ticket page,
        /// checks if there is a status message to be 
        /// displayed
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: Management/Create       
        public ActionResult Create()
        {
            if (TempData["status"] != null)
            {
                ViewBag.result = TempData["status"].ToString();
                TempData.Remove("status");
            }
            return View();
        }

        /// <summary>
        /// William Rients
        /// Created: 2023/04/16
        /// 
        /// Post method for creating a ticket, gets
        /// the current user logged in and checks if model state
        /// is valid, and that the user is indeed logged in
        /// 
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        // POST: Management/Create
        [HttpPost]
        public ActionResult Create(Ticket ticket)
        {
            applicationUserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = applicationUserManager.FindById(User.Identity.GetUserId());
            if (user != null && ModelState.IsValid)
            {
                try
                {
                    masterManager.TicketManager.CreateNewTicket((int)user.UsersId, ticket.TicketStatusId, ticket.TicketTitle, ticket.TicketContext);
                    TempData["status"] = "Ticket Created!";
                    return RedirectToAction("Create");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;

                    return View("Error");
                }
            }
            else
            {
                TempData["status"] = "Please login before creating a ticket.";
                return RedirectToAction("Create");
            }
        }

        // GET: Management/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Management/Edit/5
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

        // GET: Management/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Management/Delete/5
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
