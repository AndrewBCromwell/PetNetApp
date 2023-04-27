using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;


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

        // GET: Hours of Operation
        public ActionResult HoursOfOperation(int ? shelterId)
        {
            List<HoursOfOperation> hoursOfOperation = new List<HoursOfOperation>();
            try
            {
                hoursOfOperation = masterManager.ShelterManager.RetrieveHoursOfOperationByShelterID((int)shelterId);
                if (hoursOfOperation == null)
                {
                    throw new Exception("The hours of operation for this shelter could not be loaded.");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
            return View(hoursOfOperation);
        }

        // GET: Edit Hours of Operation
        public ActionResult EditHoursOfOperation(int? shelterId)
        {
            return View();
        }

        // POST: Edit Hours of Operation

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult EditHoursOfOperation(int ? shelterId, string dayOfWeek, string openHour, string closeHour)
        {
            List<HoursOfOperation> hoursOfOperation = new List<HoursOfOperation>();
            DateTime openHourDateTime;
            DateTime closeHourDateTime;
            TimeSpan convertedOpenHour;
            TimeSpan convertedCloseHour;
            int dayOfWeekInt = 0;
            if (ModelState.IsValid)
            {

                try
                {
                    HoursOfOperation hours = new HoursOfOperation();
                    try
                    {
                        openHourDateTime = DateTime.Parse(openHour);
                        closeHourDateTime = DateTime.Parse(closeHour);
                    }
                    catch (Exception)
                    {
                        ViewBag.Message = "An error has occured trying to set the hours. Please try formatting the hours as (HH:MM AM) or (HH:MM PM).";
                        return View("Error");
                    }
                    
                    convertedOpenHour = openHourDateTime.TimeOfDay;
                    convertedCloseHour = closeHourDateTime.TimeOfDay;
                    hours.OpenHour = convertedOpenHour;
                    hours.CloseHour = convertedCloseHour;
                    switch (dayOfWeek)
                    {
                        case "Sunday":
                            dayOfWeekInt = 1;
                            break;
                        case "Monday":
                            dayOfWeekInt = 2;
                            break;
                        case "Tuesday":
                            dayOfWeekInt = 3;
                            break;
                        case "Wednesday":
                            dayOfWeekInt = 4;
                            break;
                        case "Thursday":
                            dayOfWeekInt = 5;
                            break;
                        case "Friday":
                            dayOfWeekInt = 6;
                            break;
                        case "Saturday":
                            dayOfWeekInt = 7;
                            break;
                    }
                    bool result = masterManager.ShelterManager.EditHoursOfOperationByShelterID((int)shelterId, dayOfWeekInt, hours);                    
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "An error has occured:" + ex.Message;
                    return View("Error");
                }
            }
            return RedirectToAction("HoursOfOperation", new { shelterId = shelterId });
        }
    }
}