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
            int expectedCount = 3; 
            int actualCount = 0;
            int ShelterId = 1; 

            var kennels = kennelManager.RetrieveKennels(ShelterId);
            actualCount = kennels.Count;

            Assert.AreEqual(expectedCount, actualCount);
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
            int kennelId = 100008; 

            actualRes = kennelManager.RemoveAnimalKennlingByKennelId(kennelId);

            Assert.AreEqual(expectedRes, actualRes);
        }
    }
}
