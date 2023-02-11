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
            AnimalVM animalVM = null;
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

        public bool EditAnimal(AnimalVM oldAnimal, AnimalVM newAnimal)
        {
            throw new NotImplementedException();
        }

        public List<Animal> RetrieveAllAnimals()
        {
            List<Animal> animals;

            try
            {
                animals = _animalAccessor.SelectAllAnimals();
            }
            catch (Exception up)
            {
                throw new ApplicationException("Data not found.", up);
            }
            return animals;
        }

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
    }
}