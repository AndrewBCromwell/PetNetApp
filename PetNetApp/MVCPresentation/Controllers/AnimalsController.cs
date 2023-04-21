
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects;
using LogicLayerInterfaces;
using LogicLayer;
using MVCPresentation.Models;
using System.Drawing;

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


        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/04/19
        /// 
        /// Controller method for /Animals/Adoptable to view a list of adoptable animals
        /// </summary>
        /// 
        /// /// <remarks>
        /// Andrew Cromwell
        /// Updated 2023/04/20
        /// 
        /// Added the Viewbag.DisplayedAnimals and FilterOptions to allow for filtering by animal type
        /// </remarks>
        /// <returns>Adoptable View</returns>
        [HttpGet]
        public ActionResult Adoptable()
        {
            List<AdoptableAnimalModel> adoptableAnimalModels = new List<AdoptableAnimalModel>();
            List<AnimalVM> animalVMs = new List<AnimalVM>();
            try
            {
                animalVMs = _manager.AnimalManager.RetrieveAllAdoptableAnimals();
                ViewBag.DisplayedAnimals = "All Animals";
                List<string> filterOptions = new List<string>()
                {
                    "All",
                    "Cats",
                    "Dogs",
                    "Birds",
                    "Other"
                };
                ViewBag.FilterOptions = filterOptions;
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("Error");
            }

            foreach (var animal in animalVMs)
            {
                AdoptableAnimalModel adoptableAnimalModel = new AdoptableAnimalModel();
                adoptableAnimalModel.AnimalVM = animal;
                List<Images> imagesList = new List<Images>();
                try
                {
                    imagesList = _manager.ImagesManager.RetrieveAnimalImagesByAnimalId(animal.AnimalId);
                }
                catch
                {
                    adoptableAnimalModel.AnimalImageSource = "/Images/Animal/BrokenImage.png";
                }

                if(imagesList.Count == 0)
                {
                    adoptableAnimalModel.AnimalImageSource = "/Images/Animal/no_image.png";
                }
                else
                {
                    adoptableAnimalModel.AnimalImageSource = "/Images/Animal/" + imagesList[0].ImageId + ".png";
                }

                try
                {
                    adoptableAnimalModel.ShelterName = " | " + _manager.ShelterManager.
                        RetrieveShelterVMByShelterID(animal.AnimalShelterId).ShelterName;
                }
                catch
                {
                    adoptableAnimalModel.ShelterName = "";
                }
                adoptableAnimalModels.Add(adoptableAnimalModel);
            }
            return View(adoptableAnimalModels);
        }

        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/04/21
        /// 
        /// Displays the animals of the type selected by the user.
        /// </summary>
        /// <remarks>
        /// Zaid Rachman
        /// Updated: 2023/04/21
        /// Final QA
        /// </remarks>
        /// <returns></returns>
        [HttpPost, ActionName("Adoptable")]
        public ActionResult FilterAdoptable()
        {
            string filterFromForm = Convert.ToString(Request["FilterAnimal"].ToString());
            List<AdoptableAnimalModel> adoptableAnimalModels = new List<AdoptableAnimalModel>();
            List<AnimalVM> animalVMs = new List<AnimalVM>();
            try
            {
                switch (filterFromForm)
                {
                    case "All":
                        animalVMs = _manager.AnimalManager.RetrieveAllAdoptableAnimals();
                        ViewBag.DisplayedAnimals = "All Animals";
                        break;
                    case "Dogs":
                        animalVMs = _manager.AnimalManager.RetrieveAllAdoptableAnimals().Where(A => A.AnimalTypeId == "Dog").ToList();
                        ViewBag.DisplayedAnimals = "Dogs";
                        break;
                    case "Cats":
                        animalVMs = _manager.AnimalManager.RetrieveAllAdoptableAnimals().Where(A => A.AnimalTypeId == "Cat").ToList();
                        ViewBag.DisplayedAnimals = "Cats";
                        break;
                    case "Birds":
                        animalVMs = _manager.AnimalManager.RetrieveAllAdoptableAnimals().Where(A => A.AnimalTypeId == "Bird").ToList();
                        ViewBag.DisplayedAnimals = "Birds";
                        break;
                    case "Other":
                        animalVMs = _manager.AnimalManager.RetrieveAllAdoptableAnimals().Where(A => A.AnimalTypeId != "Dog" && A.AnimalTypeId != "Cat" &&
                            A.AnimalTypeId != "Bird").ToList();
                        ViewBag.DisplayedAnimals = "Other Animals";
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("Error");
            }
            List<string> filterOptions = new List<string>()
                {
                    "All",
                    "Cats",
                    "Dogs",
                    "Birds",
                    "Other"
                };
            ViewBag.FilterOptions = filterOptions;
            foreach (var animal in animalVMs)
            {
                AdoptableAnimalModel adoptableAnimalModel = new AdoptableAnimalModel();
                adoptableAnimalModel.AnimalVM = animal;
                List<Images> imagesList = new List<Images>();
                try
                {
                    imagesList = _manager.ImagesManager.RetrieveAnimalImagesByAnimalId(animal.AnimalId);
                }
                catch
                {
                    adoptableAnimalModel.AnimalImageSource = "/Images/Animal/BrokenImage.png";
                }

                if (imagesList.Count == 0)
                {
                    adoptableAnimalModel.AnimalImageSource = "/Images/Animal/no_image.png";
                }
                else
                {
                    adoptableAnimalModel.AnimalImageSource = "/Images/Animal/" + imagesList[0].ImageId + ".png";
                }

                try
                {
                    adoptableAnimalModel.ShelterName = " | " + _manager.ShelterManager.
                        RetrieveShelterVMByShelterID(animal.AnimalShelterId).ShelterName;
                }
                catch
                {
                    adoptableAnimalModel.ShelterName = "";
                }
                adoptableAnimalModels.Add(adoptableAnimalModel);
            }

            return View(adoptableAnimalModels);
        }

        public ActionResult Foster()
        {
            return View();
        }

        public ActionResult Surrender()
        {
            return View();
        }
                
        [HttpGet]
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