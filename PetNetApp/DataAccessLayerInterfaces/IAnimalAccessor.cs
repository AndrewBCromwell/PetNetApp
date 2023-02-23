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
        int InsertAnimal(AnimalVM animal);

        AnimalVM SelectAnimalByAnimalId(int animalId, int shelterId);
        List<Animal> SelectAllAnimals(String animalName);

        // For populating edit animal profile combo boxes 
        Dictionary<string, List<string>> SelectAllAnimalBreeds();
        List<string> SelectAllAnimalGenders();
        List<string> SelectAllAnimalTypes();
        List<string> SelectAllAnimalStatuses();

        int UpdateAnimal(AnimalVM oldAnimal, AnimalVM newAnimal);
        List<Animal> SelectAllAnimals(int shelterId);
        List<Animal> SelectAllAnimalsNotInKennel();
        AnimalVM SelectAnimalMedicalProfileByAnimalId(int AnimalId);
    }
}
