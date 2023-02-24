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
        List<Animal> SelectAllAnimals();
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
    }
}
