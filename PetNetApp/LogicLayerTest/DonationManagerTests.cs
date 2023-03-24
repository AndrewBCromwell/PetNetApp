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
        public void TestRetrieveDonationByDonationId()
        {
            int expectedId = 1;
            int actualId = 0;

            actualId = donationManager.RetrieveDonationByDonationId(1).DonationId;
            Assert.AreEqual(expectedId, actualId);
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
        [TestMethod]
        public void TestRetrieveDonationsByEventId()
        {
            // arrange
            int expectedResult1 = 2;
            int expectedResult2 = 1;
            int expectedResult3 = 0;
            int eventId1 = 1000;
            int eventId2 = 1001;
            int eventId3 = 1002;
            int actualResult1 = 0;
            int actualResult2 = 0;
            int actualResult3 = 0;

            // act
            actualResult1 = donationManager.RetrieveDonationsByEventId(eventId1).Count;
            actualResult2 = donationManager.RetrieveDonationsByEventId(eventId2).Count;
            actualResult3 = donationManager.RetrieveDonationsByEventId(eventId3).Count;

            // assert
            Assert.AreEqual(expectedResult1, actualResult1);
            Assert.AreEqual(expectedResult2, actualResult2);
            Assert.AreEqual(expectedResult3, actualResult3);
        }

        [TestMethod]
        public void TestRetrieveSumDonationsByEventId()
        {
            decimal expectedResult1 = 250m;
            decimal expectedResult2 = 110m;
            decimal expectedResult3 = 0m;
            int eventId1 = 1000;
            int eventId2 = 1001;
            int eventId3 = 1002;
            decimal actualResult1 = 0m;
            decimal actualResult2 = 0m;
            decimal actualResult3 = 0m;

            // act
            actualResult1 = donationManager.RetrieveSumDonationsByEventId(eventId1);
            actualResult2 = donationManager.RetrieveSumDonationsByEventId(eventId2);
            actualResult3 = donationManager.RetrieveSumDonationsByEventId(eventId3);

            // assert
            Assert.AreEqual(expectedResult1, actualResult1);
            Assert.AreEqual(expectedResult2, actualResult2);
            Assert.AreEqual(expectedResult3, actualResult3);
        }
    }
}
