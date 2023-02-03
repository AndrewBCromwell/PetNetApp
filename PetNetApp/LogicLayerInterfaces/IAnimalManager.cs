using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IAnimalManager
    {
        AnimalVM RetrieveAnimalByAnimalId(int animalId);
        bool EditAnimal(Animal oldAnimal, Animal newAnimal);
    }
}
