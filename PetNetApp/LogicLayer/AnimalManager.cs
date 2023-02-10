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

        public AnimalVM RetrieveAnimalByAnimalId(int animalId)
        {
            /*
                var fakeAnimal = new AnimalVM();
                fakeAnimal.AnimalName = "Test name 2";
                return fakeAnimal;
            */
            AnimalVM animalVM = new AnimalVM();
            try
            {
                animalVM = _animalAccessor.SelectAnimalByAnimalId(animalId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
            return animalVM;
        }

        public List<string> RetrieveAllAnimalBreeds()
        {
            //var breeds = new List<string>();
            //breeds.Add("Test breed 1");
            //breeds.Add("Test breed 2");
            //return breeds;

            try
            {
                return _animalAccessor.SelectAllAnimalBreeds();
            }
            catch (Exception)
            {
                throw;
            }
        }

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
            catch (Exception)
            {
                throw;
            }
        }

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
            catch (Exception)
            {
                throw;
            }
        }

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
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditAnimal(AnimalVM oldAnimal, AnimalVM newAnimal)
        {
            try
            {
                return 1 == _animalAccessor.UpdateAnimal(oldAnimal, newAnimal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
