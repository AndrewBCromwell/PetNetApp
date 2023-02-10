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
<<<<<<< HEAD
            
=======
            //kennelManager = new KennelManager();
>>>>>>> origin/main
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
    }
}
