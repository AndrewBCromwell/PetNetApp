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
        bool AddAnimal(AnimalVM animal);
        List<Animal> RetrieveAllAnimals(String animalName);
        AnimalVM RetrieveAnimalByAnimalId(int animalId, int shelterId);

        // For populating edit animal profile combo boxes 
        Dictionary<string, List<string>> RetrieveAllAnimalBreeds();
        List<string> RetrieveAllAnimalGenders();
        List<string> RetrieveAllAnimalTypes();
        List<string> RetrieveAllAnimalStatuses();

        bool EditAnimal(AnimalVM oldAnimal, AnimalVM newAnimal);
        List<Animal> RetrieveAllAnimals(int shelterId);
        AnimalVM RetrieveAnimalMedicalProfileByAnimalId(int AnimalId);

        AnimalVM RetriveAnimalAdoptableProfile(int animalId);

        List<AnimalVM> RetriveAdoptedAnimalByUserId(int userId);
        FosterPlacementRecord RetriveFosterPlacementRecordNotes(int animalId);
    }
}
