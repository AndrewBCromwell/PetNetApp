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

        public AnimalsController(MasterManager manager)     
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
        public ActionResult AdoptionApplication(int animalId)
        {
            try
            {
                ViewBag.HomeTypes = _manager.AdoptionApplicationManager.RetrieveAllHomeTypes();
                ViewBag.HomeOwnershipTypes = _manager.AdoptionApplicationManager.RetrieveAllHomeOwnershipTypes();
                ViewBag.AnimalId = animalId.ToString();
                ViewBag.AnimalName = _manager.AnimalManager.RetriveAnimalAdoptableProfile((int)animalId).AnimalName;

            }
            catch (Exception up)
            {
                ViewBag.Message = up.InnerException.Message;
                return View("Error");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AdoptionApplication(AdoptionApplicationVM _application)
        {
            if(!ModelState.IsValid)
            {
                return View(_application);
            }
            else
            {
                try
                {
                    Applicant applicant = new Applicant()
                    {
                        ApplicantGivenName = _application.AdoptionApplicant.ApplicantGivenName,
                        ApplicantFamilyName = _application.AdoptionApplicant.ApplicantFamilyName,
                        ApplicantAddress = _application.AdoptionApplicant.ApplicantAddress,
                        ApplicantAddress2 = _application.AdoptionApplicant.ApplicantAddress2 == null ? "" : _application.AdoptionApplicant.ApplicantAddress2,
                        ApplicantZipCode = _application.AdoptionApplicant.ApplicantZipCode,
                        ApplicantPhoneNumber = _application.AdoptionApplicant.ApplicantPhoneNumber,
                        ApplicantEmail = _application.AdoptionApplicant.ApplicantEmail,
                        HomeTypeId = _application.AdoptionApplicant.HomeTypeId,
                        HomeOwnershipId = _application.AdoptionApplicant.HomeOwnershipId,
                        NumberOfChildren = _application.AdoptionApplicant.NumberOfChildren,
                        NumberOfPets = _application.AdoptionApplicant.NumberOfPets
                    };
                    if(_manager.User != null)
                    {
                        applicant.UserId = _manager.User.UsersId;
                    }

                    AdoptionApplicationVM application = new AdoptionApplicationVM()
                    {
                        AdoptionApplicant = applicant,
                        AdoptionApplicationDate = DateTime.Now,
                        AnimalId = _application.AnimalId
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

        
        public ActionResult Adoptable()
        {
            List<AnimalVM> adoptableAnimals = new List<AnimalVM>();
            try
            {
                adoptableAnimals = _manager.AnimalManager.RetrieveAllAdoptableAnimals();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("Error");
            }
            return View(adoptableAnimals);
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