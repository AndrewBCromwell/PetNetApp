using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataObjects;
using LogicLayer;

namespace LogicLayerTest
{
    [TestClass]
    public class KennelManagerTest
    {
        KennelManager kennelManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            kennelManager = new KennelManager(new DataAccessLayerFakes.KennelAccessorFake());
        }

        [TestMethod]
        public void TestRetrieveKennelsByShelterId()
        {
            int expectedCount = 3; 
            int actualCount = 0;
            int ShelterId = 1; 

            var kennels = kennelManager.RetrieveKennels(ShelterId);
            actualCount = kennels.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestRetrieveAnimalByAnimalId()
        {
            //arrange 
            int animalId = 100000;
            int expectedShelterId = 100000;
            int acutalShelterId;

            // act
            var kennel = kennelManager.RetrieveKennelIdByAnimalId(animalId);
            acutalShelterId = kennel.KennelId;

            // assert
            Assert.AreEqual(expectedShelterId, acutalShelterId);

        }

        [TestMethod]
        public void TestInsertAnimalIntoKennel()
        {
            //arrange 
            int animalId = 100000;
            int kennelId = 100000;

            // act
            bool success = kennelManager.AddAnimalIntoKennelByAnimalId(animalId, kennelId);
            
            // assert
            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void TestSelectAnimalsForKennel()
        {
            //arrange 
            int expectedCount = 1;
            int acutalCount = 0;

            // act
            var animals = kennelManager.RetrieveAllAnimalsForKennel(100000);
            acutalCount = animals.Count;

            // assert
            Assert.AreEqual(expectedCount, acutalCount);
        }


        [TestMethod]
        public void TestRetrieveAnimalTypes()
        {
            int expectedCount = 3;
            int actualCount = 0;

            var kennels = kennelManager.RetrieveAnimalTypes();
            actualCount = kennels.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestAddKennel()
        {
            bool expectedRes = true;
            bool actualRes = false;
            Kennel kennel = new Kennel();

            kennel.KennelId = 400000;
            kennel.KennelName = "Test Kennel";
            kennel.ShelterId = 100000;
            kennel.AnimalTypeId = "Dog";

            actualRes = kennelManager.AddKennel(kennel);

            Assert.AreEqual(expectedRes, actualRes);
        }

        [TestMethod]
        public void TestEditKennelStatus()
        {
            bool expectedRes = true;
            bool actualRes = false;
            int kennelId = 1; 

            actualRes = kennelManager.EditKennelStatusByKennelId(kennelId);

            Assert.AreEqual(expectedRes, actualRes);
        }

        [TestMethod]
        public void TestRemoveAnimalKenneling()
        {
            bool expectedRes = true;
            bool actualRes = false;
            int kennelId = 1; 

            actualRes = kennelManager.RemoveAnimalKennlingByKennelId(kennelId);

            Assert.AreEqual(expectedRes, actualRes);
        }
    }
}
