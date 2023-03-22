using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        [TestMethod]
        public void TestRetrieveDonations()
        {
            int expectedResult = 4;
            int actualResult = 0;

            actualResult = donationManager.RetrieveAllDonations().Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRetrieveInKindsByDonationId()
        {
            int expectedResult = 3;
            int actualResult = 0;
            int donationId = 1;

            actualResult = donationManager.RetrieveInKindsByDonationId(donationId).Count;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
