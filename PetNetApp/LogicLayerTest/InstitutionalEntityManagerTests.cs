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
        public void TestAddNewInstitutionalEntity()
        {
            InstitutionalEntity entity = new InstitutionalEntity()
            {
                InstitutionalEntityId = 1008,
                CompanyName = "SpaceX",
                GivenName = "Glen",
                FamilyName = "Musk",
                Email = "glen@spacex.com",
                Phone = "1239876541",
                Address = "1233 Boca Chica Blvd",
                AddressTwo = null,
                Zipcode = "78520",
                ContactType = "Sponsor",
                ShelterId = 100000
            };

            bool actualResult = _institutionalEntityManager.AddInstitutionalEntity(entity);

            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void TestUpdateInstitutionalEntityWorksWithCorrectData()
        {
            // Arrange
            InstitutionalEntity oldEntity = _institutionalEntityManager.RetrieveInstitutionalEntityByInstitutionalEntityId(1009);
            InstitutionalEntity newEntity = new InstitutionalEntity
            {
                InstitutionalEntityId = 1009,
                CompanyName = "SpaceX",
                GivenName = "Nole",
                FamilyName = "Musk",
                Email = "nole@spacex.com",
                Phone = "1339876541",
                Address = "1323 Boca Chico Blvd",
                AddressTwo = null,
                Zipcode = "78520",
                ContactType = "Contact",
                ShelterId = 100000
            };

            // Act
            bool actualResult = _institutionalEntityManager.EditInstitutionalEntity(oldEntity, newEntity);

            // Assert
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void TestUpdateInstitutionalEntityFailsWithBadData()
        {
            // Arrange
            InstitutionalEntity badEntity = new InstitutionalEntity
            {
                InstitutionalEntityId = 1008,
                CompanyName = "SpaceX",
                GivenName = "Nole",
                FamilyName = "Musk",
                Email = "nole@spacex.com",
                Phone = "1339876541",
                Address = "1323 Boca Chico Blvd",
                AddressTwo = null,
                Zipcode = "78520",
                ContactType = "Contact",
                ShelterId = 100000
            };
            InstitutionalEntity newEntity = badEntity;

            // Act
            bool actualResult = _institutionalEntityManager.EditInstitutionalEntity(badEntity, newEntity);

            // Assert
            Assert.IsFalse(actualResult);
        }
    }
}
