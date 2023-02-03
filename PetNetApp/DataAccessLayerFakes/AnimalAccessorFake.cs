using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class AnimalAccessorFake : IAnimalAccessor
    {
        List<AnimalVM> fakeAnimals = new List<AnimalVM>();

        public AnimalAccessorFake()
        {
            fakeAnimals.Add(new AnimalVM
            {
                AnimalId = 999999,
                AnimalName = "Test name 1",
                AnimalGender = "Test gender 1",
                AnimalTypeId = "Test type 1",
                AnimalBreedId = "Test breed 1",
                Personality = "Test personality 1",
                Description = "Test description 1",
                AnimalStatusId = "Test status 1",
                AnimalStatusDescription = "Test status description 1",
                ReceivedDate = DateTime.Parse("2023-06-01"),
                MicrochipSerialNumber = '1',
                Aggressive = false,
                AggressionDescription = "Not aggressive",
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
                Personality = "Test personality 2",
                Description = "Test description 2",
                AnimalStatusId = "Test status 2",
                AnimalStatusDescription = "Test status description 2",
                ReceivedDate = DateTime.Parse("2023-06-02"),
                MicrochipSerialNumber = '2',
                Aggressive = true,
                AggressionDescription = "Bites",
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
                Personality = "Test personality 3",
                Description = "Test description 3",
                AnimalStatusId = "Test status 3",
                AnimalStatusDescription = "Test status description 3",
                ReceivedDate = DateTime.Parse("2023-06-03"),
                MicrochipSerialNumber = '3',
                Aggressive = false,
                AggressionDescription = "Not aggressive",
                ChildFriendly = true,
                NeuterStatus = true,
                Notes = "N/A"
            });
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

        public int UpdateAnimal(Animal oldAnimal, Animal newAnimal)
        {
            throw new NotImplementedException();
        }
    }
}
