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
            _animalAccessor = new AnimalAccessor();
        }

        public AnimalManager(IAnimalAccessor iam)
        {
            _animalAccessor = iam;
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
    }
}