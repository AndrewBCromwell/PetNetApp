using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer;
using DataObjects;

namespace MVCPresentation.Controllers
{
    public class SheltersController : Controller
    {
        private ShelterManager _shelterManager = new ShelterManager();
        private UsersManager _userManager = new UsersManager();
        private List<Shelter> _shelters;





        public SheltersController()
        {
            try
            {
                _shelters = _shelterManager.GetShelterList();
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
            return View();
        }


        // GET: Shelters
        public ActionResult SelectShelter()
        {
            return View(_shelters);
        }

        // GET: SelectedShelters
        public ActionResult SelectedShelter(int id)
        {
            try
            {
                var user = _userManager.RetrieveUserByUsersId(100003);
                _userManager.EditUserShelterId(user.UsersId, id, (int)user.ShelterId);

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