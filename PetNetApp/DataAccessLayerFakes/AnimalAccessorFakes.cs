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
        List<AnimalVM> fakeAnimals = new List<AnimalVM>();
        List<Animal> fakeAnimals1 = new List<Animal>();
        private AnimalVM fakeAnimalVM = new AnimalVM();

        public AnimalAccessorFakes()
        {
            fakeAnimalVM = new AnimalVM()
            {
                AnimalId = 100000,
                AnimalName = "Chip",
                AnimalGender = "Male",
                AnimalTypeId = "Dog",
                AnimalBreedId = "Lab",
                Personality = "Calm",
                Description = "Needs Attention",
                AnimalStatusId = "Healthy",
                BroughtIn = DateTime.Now,
                MicrochipNumber = "dog12345",
                Aggressive = false,
                AggressiveDescription = "Not Aggressive",
                ChildFriendly = true,
                NeuterStatus = true,
                Notes = "No notes"
            };

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

            fakeAnimals.Add(new AnimalVM
            {
                AnimalId = 999999,
                AnimalName = "Test name 1",
                AnimalGender = "Test gender 1",
                AnimalTypeId = "Test type 1",
                AnimalBreedId = "Test breed 1",
                KennelName = "Test kennel 1",
                Personality = "Test personality 1",
                Description = "Test description 1",
                AnimalStatusId = "Test status 1",
                AnimalStatusDescription = "Test status description 1",
                BroughtIn = DateTime.Parse("2023-06-01"),
                MicrochipNumber = "Test SN",
                Aggressive = false,
                AggressiveDescription = "Not aggressive",
                ChildFriendly = true,
                NeuterStatus = true,
                Notes = "N/A"
            });

            fakeAnimals.Add(new AnimalVM
            {
                AnimalId = 999998,
                AnimalName = "Test name 2",
                AnimalGender = "Test gender 2",
                AnimalTypeId = "Test type 2",
                AnimalBreedId = "Test breed 2",
                KennelName = "Test kennel 2",
                Personality = "Test personality 2",
                Description = "Test description 2",
                AnimalStatusId = "Test status 2",
                AnimalStatusDescription = "Test status description 2",
                BroughtIn = DateTime.Parse("2023-06-02"),
                MicrochipNumber = "Test SN",
                Aggressive = true,
                AggressiveDescription = "Bites",
                ChildFriendly = false,
                NeuterStatus = false,
                Notes = "N/A"
            });

            fakeAnimals.Add(new AnimalVM
            {
                AnimalId = 999997,
                AnimalName = "Test name 3",
                AnimalGender = "Test gender 3",
                AnimalTypeId = "Test type 3",
                AnimalBreedId = "Test breed 3",
                KennelName = "Test kennel 1",
                Personality = "Test personality 3",
                Description = "Test description 3",
                AnimalStatusId = "Test status 3",
                AnimalStatusDescription = "Test status description 3",
                BroughtIn = DateTime.Parse("2023-06-03"),
                MicrochipNumber = "Test SN",
                Aggressive = false,
                AggressiveDescription = "Not aggressive",
                ChildFriendly = true,
                NeuterStatus = true,
                Notes = "N/A"
            });

            fakeAnimals1.Add(new Animal
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

            fakeAnimals1.Add(new Animal
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

            fakeAnimals1.Add(new Animal
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

            fakeAnimals1.Add(new Animal
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

            fakeAnimals1.Add(new Animal
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

            fakeAnimals1.Add(new Animal
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

        public AnimalVM SelectAnimalMedicalProfileByAnimalId(int animalId)
        {
            AnimalVM animalVM = null;
            animalVM = fakeAnimalVM;
            return animalVM;
        }

        public AnimalVM SelectAnimalByAnimalId(int animalId)
            {
            AnimalVM animalVM = new AnimalVM();

            foreach (AnimalVM fakeAnimal in fakeAnimals)
            {
                if(fakeAnimal.AnimalId == animalId)
                {
                    animalVM = fakeAnimal;
                    return animalVM;
                }
            }
            if (animalVM == null)
            {
                throw new ApplicationException("Animal not found");
            }
            return animalVM;
        }

        public List<Animal> SelectAllAnimals(String animalName)
        {
            return animals.Where(a => a.AnimalName == animalName).ToList();
        }

        public List<Animal> SelectAllAnimals()
        {
            return fakeAnimals1;

        }

        public List<Animal> SelectAllAnimalsNotInKennel()
        {
            throw new NotImplementedException();
        }
    }
}
