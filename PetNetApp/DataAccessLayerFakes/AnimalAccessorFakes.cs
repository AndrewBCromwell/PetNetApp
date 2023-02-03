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
        List<Animal> fakeAnimals = new List<Animal>();

        public AnimalAccessorFakes()
        {
            fakeAnimals.Add(new Animal
            {
                AnimalId = 100001,
                AnimalName = "Remy",
                Personality = "Gay",
                Description = "Brown and White",
                BroughtIn = DateTime.Today,
                MicrochipNumber = "111111111111111",
                Aggressive = false,
                AggressiveDescription = null,
                ChildFriendly = true,
                NeuterStatus = true,
                Notes = null,
                AnimalTypeId = "Dog",
                AnimalBreedId = "Lab",
                AnimalStatusId = "Available"
            });

            fakeAnimals.Add(new Animal
            {
                AnimalId = 100002,
                AnimalName = "Jack",
                Personality = "Nice",
                Description = "Black and White",
                BroughtIn = DateTime.Today,
                MicrochipNumber = "111111111111121",
                Aggressive = false,
                AggressiveDescription = null,
                ChildFriendly = true,
                NeuterStatus = true,
                Notes = null,
                AnimalTypeId = "Dog",
                AnimalBreedId = "Lab",
                AnimalStatusId = "Available"
            });

            fakeAnimals.Add(new Animal
            {
                AnimalId = 100002,
                AnimalName = "Kyle",
                Personality = "Mean",
                Description = "Brown and White",
                BroughtIn = DateTime.Today,
                MicrochipNumber = "111111111111115",
                Aggressive = false,
                AggressiveDescription = null,
                ChildFriendly = true,
                NeuterStatus = true,
                Notes = null,
                AnimalTypeId = "Dog",
                AnimalBreedId = "Lab",
                AnimalStatusId = "Available"
            });

            fakeAnimals.Add(new Animal
            {
                AnimalId = 100003,
                AnimalName = "Kate",
                Personality = "Gay",
                Description = "Brown and White",
                BroughtIn = DateTime.Today,
                MicrochipNumber = "111111111111811",
                Aggressive = false,
                AggressiveDescription = null,
                ChildFriendly = true,
                NeuterStatus = true,
                Notes = null,
                AnimalTypeId = "Dog",
                AnimalBreedId = "Lab",
                AnimalStatusId = "Available"
            });

            fakeAnimals.Add(new Animal
            {
                AnimalId = 100004,
                AnimalName = "Matt",
                Personality = "Gay",
                Description = "Brown and White",
                BroughtIn = DateTime.Today,
                MicrochipNumber = "111119111111111",
                Aggressive = false,
                AggressiveDescription = null,
                ChildFriendly = true,
                NeuterStatus = true,
                Notes = null,
                AnimalTypeId = "Dog",
                AnimalBreedId = "Lab",
                AnimalStatusId = "Available"
            });

            fakeAnimals.Add(new Animal
            {
                AnimalId = 100005,
                AnimalName = "Gaylord",
                Personality = "Gay",
                Description = "Brown and White",
                BroughtIn = DateTime.Today,
                MicrochipNumber = "211111111111111",
                Aggressive = false,
                AggressiveDescription = null,
                ChildFriendly = true,
                NeuterStatus = true,
                Notes = null,
                AnimalTypeId = "Dog",
                AnimalBreedId = "Lab",
                AnimalStatusId = "Available"
            });
        }

        public List<Animal> SelectAllAnimals()
        {
            return fakeAnimals;

        }
    }
}
