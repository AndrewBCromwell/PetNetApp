using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IAnimalManager
    {
        List<Animal> RetrieveAllAnimals(String animalName);
        AnimalVM RetrieveAnimalByAnimalId(int animalId);
        bool EditAnimal(AnimalVM oldAnimal, AnimalVM newAnimal);
        List<Animal> RetrieveAllAnimals();
        AnimalVM RetrieveAnimalMedicalProfileByAnimalId(int AnimalId);
    }
}
