using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects;
using LogicLayerInterfaces;
using LogicLayer;

namespace MVCPresentation.Controllers
{
    public class AnimalsController : Controller
    {
        MasterManager _manager = null;
        Animal _animal = null;

        public AnimalsController(MasterManager manager)     // need to pass in animal id once adoptable animal profile done
        {
            _manager = manager;
            //_animal = animal;
        }

        public AnimalsController()
        {
            _manager = MasterManager.GetMasterManager();
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Animals
        public ActionResult AdoptionApplication()
        {
            try
            {
                ViewBag.HomeTypes = _manager.AdoptionApplicationManager.RetrieveAllHomeTypes();
                ViewBag.HomeOwnershipTypes = _manager.AdoptionApplicationManager.RetrieveAllHomeOwnershipTypes();
            }
            catch (Exception up)
            {
                ViewBag.Message = up.InnerException.Message;
                return View("Error");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AdoptionApplication(Applicant _applicant)
        {
            if(!ModelState.IsValid)
            {
                return View(_applicant);
            }
            else
            {
                try
                {
                    ApplicantVM applicant = new ApplicantVM()
                    {
                        ApplicantGivenName = _applicant.ApplicantGivenName,
                        ApplicantFamilyName = _applicant.ApplicantFamilyName,
                        ApplicantAddress = _applicant.ApplicantAddress,
                        ApplicantAddress2 = _applicant.ApplicantAddress2 == null ? "" : _applicant.ApplicantAddress2,
                        ApplicantZipCode = _applicant.ApplicantZipCode,
                        ApplicantPhoneNumber = _applicant.ApplicantPhoneNumber,
                        ApplicantEmail = _applicant.ApplicantPhoneNumber,
                        HomeTypeId = _applicant.HomeTypeId,
                        HomeOwnershipId = _applicant.HomeOwnershipId,
                        NumberOfChildren = _applicant.NumberOfChildren,
                        NumberOfPets = _applicant.NumberOfPets
                    };
                    if(_manager.User != null)
                    {
                        applicant.UserId = _manager.User.UsersId;
                    }

                    AdoptionApplicationVM application = new AdoptionApplicationVM()
                    {
                        AdoptionApplicant = applicant,
                        AdoptionApplicationDate = DateTime.Now
                    };
                    
                    _manager.AdoptionApplicationManager.AddAdoptionApplication(application);

                }
                catch (Exception up)
                {
                    ViewBag.Message = up.InnerException.Message;
                    return View("Error");
                }
            }
            ViewBag.Message = "Your application has been submitted!";
            return View("Success");
            
        }

        public ActionResult Foster()
        {
            return View();
        }

        public ActionResult Surrender()
        {
            return View();
        }

        public ActionResult AdoptableAnimal(int? animalId)
        {
            AnimalVM animal = new AnimalVM();
            string animalNote = "";
            IEnumerable<Images> animalImages;
            try
            {
                if (animalId == null)
                {
                    ViewBag.Message = "AnimalId is null";
                    return View("Error");
                }
                else
                {
                    animal = _manager.AnimalManager.RetriveAnimalAdoptableProfile((int)animalId);
                    animalNote = _manager.AnimalUpdatesManager.RetrieveAnimalUpdatesByAnimal((int)animalId);
                    ViewBag.AnimalNote = animalNote;
                    animalImages = _manager.ImagesManager.RetrieveAnimalImagesByAnimalId((int)animalId);
                    ViewBag.AnimalImages = animalImages;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("Error");
            }
            return View(animal);
        }
    }
}