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

        /// <summary>
        /// Hoang Chu
        /// Created: 2023/02/17
        /// 
        /// Select Animal Adoptable Profile
        /// </summary>
        /// <param name="animalId"></param>
        /// <returns></returns>
        AnimalVM SelectAnimalAdoptableProfile(int animalId);

        /// <summary>
        /// William Rients
        /// Created: 2023/02/10
        /// 
        /// Selects a specific animalVM model by animal Id
        /// for the medical profile
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="animalId">int for the animal</param>
        /// <exception cref="Exception">No animal is retrived with that Id</exception>
        /// <returns>AnimalVM object</returns>	
        AnimalVM SelectAnimalMedicalProfileByAnimalId(int AnimalId);
    }
}
