using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces
{
    public interface IAnimalAccessor
    {
        AnimalVM SelectAnimalByAnimalId(int animalId);
        List<Animal> SelectAllAnimals(String animalName);

        // For populating edit animal profile combo boxes 
        List<string> SelectAllAnimalBreeds();
        List<string> SelectAllAnimalGenders();
        List<string> SelectAllAnimalTypes();
        List<string> SelectAllAnimalStatuses();

        int UpdateAnimal(AnimalVM oldAnimal, AnimalVM newAnimal);
        List<Animal> SelectAllAnimals();
        List<Animal> SelectAllAnimalsNotInKennel();
    }
}
