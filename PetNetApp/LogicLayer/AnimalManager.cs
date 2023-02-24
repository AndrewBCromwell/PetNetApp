using DataAccessLayer;
using DataAccessLayerInterfaces;
using DataObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class AnimalManager : IAnimalManager
    {
        private IAnimalAccessor _animalAccessor = null;

        public AnimalManager()
        {
            _animalAccessor = new DataAccessLayer.AnimalAccessor();
        }

        public AnimalManager(IAnimalAccessor animalAccessor)
        {
            _animalAccessor = animalAccessor;
        }

        /// <summary>
        /// John
        /// Created: N/A
        /// 
        /// Adds animal profile record to the database
        /// </summary>
        ///
        /// <remarks>
        /// Andrew Schneider
        /// Updated: 2023/02/18
        /// Added shelter Id
        /// </remarks>
        /// <param name="animal">The animal VM object to be added</param>
        /// <exception cref="ApplicationException">Add Fails</exception>
        /// <returns>Boolean representing success or failure</returns>
        public bool AddAnimal(AnimalVM animal)
        {
            int result = 0;
            try
            {
                result = _animalAccessor.InsertAnimal(animal);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Animal record failed to be added", ex);
            }
            return result == 1;
        }

        public List<Animal> RetrieveAllAnimals(String animalName)
        {
            List<Animal> animals = null;
            try
            {
                animals = _animalAccessor.SelectAllAnimals(animalName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error retrieving animal data.", ex);
        }
            return animals;
        }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/02/02
        /// 
        /// Retrieves an animal VM by animal Id and shelter Id
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example:  Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="animalId">The animal Id of the animal VM to be returned</param>
        /// <param name="shelterId">The shelter Id of the animal VM to be returned</param>
        /// <exception cref="ApplicationException">Retrieval Fails</exception>
        /// <returns>AnimalVM</returns>
        public AnimalVM RetrieveAnimalByAnimalId(int animalId, int shelterId)
        {
            /*
                var fakeAnimal = new AnimalVM();
                fakeAnimal.AnimalName = "Test name 2";
                return fakeAnimal;
            */
            AnimalVM animalVM = new AnimalVM();
            try
            {
                animalVM = _animalAccessor.SelectAnimalByAnimalId(animalId, shelterId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Animal record not found.", ex);
            }
            return animalVM;
            }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/02/08
        /// 
        /// Retrieves all animal breeds and their associated animal types to
        /// populate add/edit animal profile combo boxes
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example:  Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param>No parameters</param>
        /// <exception cref="ApplicationException">Retrieval Fails</exception>
        /// <returns>A dictionary of two strings, the breed and the type</returns>
        public Dictionary<string, List<string>> RetrieveAllAnimalBreeds()
        {
            //var breeds = new List<string>();
            //breeds.Add("Test breed 1");
            //breeds.Add("Test breed 2");
            //return breeds;

            try
            {
                return _animalAccessor.SelectAllAnimalBreeds();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error retrieving breeds.", ex);
            }
        }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/02/08
        /// 
        /// Retrieves all animal genders to populate add/edit animal profile combo boxes
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example:  Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param>No parameters</param>
        /// <exception cref="ApplicationException">Retrieval Fails</exception>
        /// <returns>A  list of all animal genders</returns>
        public List<string> RetrieveAllAnimalGenders()
        {
            //var genders = new List<string>();
            //genders.Add("Test gender 1");
            //genders.Add("Test gender 2");
            //return genders;

            try
            {
                return _animalAccessor.SelectAllAnimalGenders();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error retrieving genders.", ex);
            }
        }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/02/08
        /// 
        /// Retrieves all animal statuses to populate add/edit animal profile combo boxes
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example:  Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param>No parameters</param>
        /// <exception cref="ApplicationException">Retrieval Fails</exception>
        /// <returns>A  list of all animal statuses</returns>
        public List<string> RetrieveAllAnimalStatuses()
        {
            //var statuses = new List<string>();
            //statuses.Add("Test status 1");
            //statuses.Add("Test status 2");
            //return statuses;

            try
            {
                return _animalAccessor.SelectAllAnimalStatuses();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error retrieving statuses.", ex);
            }
        }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/02/08
        /// 
        /// Retrieves all animal types to populate add/edit animal profile combo boxes
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example:  Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param>No parameters</param>
        /// <exception cref="ApplicationException">Retrieval Fails</exception>
        /// <returns>A  list of all animal types</returns>
        public List<string> RetrieveAllAnimalTypes()
        {
            //var types = new List<string>();
            //types.Add("Test type 1");
            //types.Add("Test type 2");
            //return types;

            try
            {
                return _animalAccessor.SelectAllAnimalTypes();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error retrieving animal types.", ex);
            }
        }

        /// <summary>
        /// Andrew Schneider
        /// Created: 2023/02/09
        /// 
        /// Edits an animal profile record using an "old" animal VM
        /// object and a "new" edited animal VM object
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example:  Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="oldAnimal">AnimalVM object holding old data</param>
        /// <param name="newAnimal">AnimalVM object holding new edited data</param>
        /// <exception cref="ApplicationException">Update Fails</exception>
        /// <returns>Boolean representing success or failure</returns>
        public bool EditAnimal(AnimalVM oldAnimal, AnimalVM newAnimal)
        {
            try
            {
                return 1 == _animalAccessor.UpdateAnimal(oldAnimal, newAnimal);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while updating record.", ex);
            }
        }

        public List<Animal> RetrieveAllAnimals(int shelterId)
        {
            List<Animal> animals;

            try
            {
                animals = _animalAccessor.SelectAllAnimals(shelterId);
            }
            catch (Exception up)
            {
                throw new ApplicationException("Data not found.", up);
            }
            return animals;
        }

        /// <summary>
        /// William Rients
        /// Created: 2023/02/10
        /// 
        /// Selects a specific animalVM model by animal Id
        /// for the medical profile
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="animalId">int for the animal</param>
        /// <exception cref="Exception">No animal is retrived with that Id</exception>
        /// <returns>AnimalVM object</returns>	
        public AnimalVM RetrieveAnimalMedicalProfileByAnimalId(int AnimalId)
        {
            try
            {
                return _animalAccessor.SelectAnimalMedicalProfileByAnimalId(AnimalId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Animal medical profile not found", ex);
            }
        }
        public AnimalVM RetriveAnimalAdoptableProfile(int animalId)
        {
            AnimalVM animalVM;

            try
            {
                animalVM = _animalAccessor.SelectAnimalAdoptableProfile(animalId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

            return animalVM;
        }
    }
}