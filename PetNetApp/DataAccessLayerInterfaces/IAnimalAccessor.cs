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
        AnimalVM SelectAnimalByAnimalId(int AnimalId);
        List<Animal> SelectAllAnimals(String animalName);
        List<Animal> SelectAllAnimals();
        List<Animal> SelectAllAnimalsNotInKennel();
        AnimalVM SelectAnimalMedicalProfileByAnimalId(int AnimalId);
    }
}
