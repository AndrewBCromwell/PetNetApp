using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicLayerTest
{
    [TestClass]
    public class DonationManagerTests
    {
        DonationManager donationManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            donationManager = new DonationManager(new DataAccessLayerFakes.DonationAccessorFake());
        }

        [TestMethod]
        public void TestRetrieveDonationsByShelterId()
        {
            int expectedResult = 4;
            int actualResult = 0;
            int shelterId = 1;

            actualResult = donationManager.RetrieveDonationsByShelterId(shelterId).Count;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
