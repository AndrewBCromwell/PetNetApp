using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;
using LogicLayerInterfaces;

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
    }
}
