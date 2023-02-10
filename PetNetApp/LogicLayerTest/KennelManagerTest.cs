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
            //kennelManager = new KennelManager();
            kennelManager = new KennelManager(new DataAccessLayerFakes.KennelAccessorFake());
        }

        [TestMethod]
        public void TestRetrieveKennelsByShelterId()
        {
            int expectedCount = 3; // fake data should be 3
            int actualCount = 0;
            int ShelterId = 1; // fake data should be shelterid = 1

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
        public void TestSelectAnimalsForKennel ()
        {
            //arrange 
            int expectedCount = 1;
            int acutalCount = 0;

            // act
            var animals = kennelManager.RetrieveAllAnimalsForKennel();
            acutalCount = animals.Count;

            // assert
            Assert.AreEqual(expectedCount, acutalCount);
        }

    }
}
