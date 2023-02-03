using DataAccessLayerInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerFakes
{
    public class AnimalAccessorFakes : IAnimalAccessor
    {
        List<Animal> animals = new List<Animal>();

        public AnimalAccessorFakes()
        {
            animals.Add(new AnimalVM
            {
                AnimalName = "Rufus",
                AnimalGender = "Male",
                AnimalTypeId = "Dog",
                AnimalBreedId = "Lab",
                Personality = "Friendly",
                Description = "this is a sample description",
                BroughtIn = new DateTime(),
                MicrochipNumber = "S/N-3234529",
                Aggressive = false
            });

        }

        public List<Animal> SelectAllAnimals(String animalName)
        {
            return animals.Where(a => a.AnimalName == animalName).ToList();
        }
    }
}
