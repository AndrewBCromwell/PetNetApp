using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayerInterfaces;
using LogicLayer;
using DataAccessLayerFakes;
using DataObjects;

namespace LogicLayerTest
{
    [TestClass]
    public class InstitutionalEntityManagerTests
    {
        private IInstitutionalEntityManager _institutionalEntityManager = null;

        [TestInitialize]
        public void SetupTests()
        {
            _institutionalEntityManager = new InstitutionalEntityManager(new InstitutionalEntityAccessorFake());
        }

        [TestCleanup]
        public void TeardownTests()
        {
            _institutionalEntityManager = null;
            FundraisingFakeData.ResetFakeFundraisingCampaignData();
        }

        [TestMethod]
        public void TestSelectFundraisingSponsorsByCampaignId()
        {
            int campaignId1 = 100000;
            int expectedResult1 = 5;
            int actualResult1 = 0;

            int campaignId2 = 100001;
            int expectedResult2 = 0;
            int actualResult2 = 0;

            int campaignId3 = 100004;
            int expectedResult3 = 3;
            int actualResult3 = 0;

            actualResult1 = _institutionalEntityManager.RetrieveFundraisingSponsorsByCampaignId(campaignId1).Count;
            actualResult2 = _institutionalEntityManager.RetrieveFundraisingSponsorsByCampaignId(campaignId2).Count;
            actualResult3 = _institutionalEntityManager.RetrieveFundraisingSponsorsByCampaignId(campaignId3).Count;

            Assert.AreEqual(expectedResult1, actualResult1);
            Assert.AreEqual(expectedResult2, actualResult2);
            Assert.AreEqual(expectedResult3, actualResult3);

        }

        [TestMethod]
        public void TestRetrievesCorrectNumberOfInstitutionalEntitiesByShelterIdAndEntityType()
        {
            InstitutionalEntityAccessorFake fakes = new InstitutionalEntityAccessorFake();
            string entityType = "Host";
            int shelterId = 100000;
            // arrange
            int expectedResult = fakes._institutionalEntitiesWithShelterId.FindAll(i => i.ContactType == entityType && i.ShelterId == shelterId).Count;

            // act
            int actualResult = _institutionalEntityManager.RetrieveAllInstitutionalEntitiesByShelterIdAndEntityType(shelterId, entityType).Count;

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
