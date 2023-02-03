using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DataAccessLayerFakes;
using LogicLayer;
using DataObjects;
using System;

namespace LogicLayerTest
{
    [TestClass]
    public class AnimalManagerTests
    {
        private AnimalManager _animalManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            // _animalManager = new AnimalManager(new DataAccessLayer.AnimalAccessor());
            _animalManager = new AnimalManager(new AnimalAccessorFake());
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
