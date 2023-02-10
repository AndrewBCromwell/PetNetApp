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

        // For populating edit animal profile combo boxes 
        List<string> RetrieveAllAnimalBreeds();
        List<string> RetrieveAllAnimalGenders();
        List<string> RetrieveAllAnimalTypes();
        List<string> RetrieveAllAnimalStatuses();

        bool EditAnimal(AnimalVM oldAnimal, AnimalVM newAnimal);
    }
}
