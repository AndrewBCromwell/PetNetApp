using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DataAccessLayerFakes;
using LogicLayer;
using DataObjects;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTest
{
    [TestClass]
    public class AnimalManagerTests
    {
        private AnimalManager _animalManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            //_animalManager = new AnimalManager();
            _animalManager = new AnimalManager(new AnimalAccessorFakes());
        }


        [TestMethod]
        public void TestRetrieveAllAnimals()
        {
            int expectedCount = 1;
            int actualCount = 0;
            string animal = "Rufus";

            var animals = _animalManager.RetrieveAllAnimals(animal);
            actualCount = animals.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestRetrieveAnimalByAnimalIdReturnsCorrectAnimal()
        {
            // Arrange
            const int animalId = 999998;
            const string expectedAnimalName = "Test name 2";
            string actualAnimalName = "";

            // Act
            Animal animal = _animalManager.RetrieveAnimalByAnimalId(animalId);
            actualAnimalName = animal.AnimalName;

            // Assert
            Assert.AreEqual(expectedAnimalName, actualAnimalName);
        }
    }
}
