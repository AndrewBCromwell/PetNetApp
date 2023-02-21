using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccessLayerFakes;
using LogicLayer;

namespace LogicLayerTest
{
    [TestClass]
    public class FundraisingCampaignManagerTests
    {
        private FundraisingCampaignManager _fundraisingCampaignManager = null;

        [TestInitialize]
        public void SetupTests()
        {
            _fundraisingCampaignManager = new FundraisingCampaignManager(new FundraisingCampaignAccessorFakes());
        }

        [TestCleanup]
        public void TeardownTests()
        {
            _fundraisingCampaignManager = null;
        }

        [TestMethod]
        public void TestRetrieveFundraisingCampaignsByShelterId()
        {
            int expectedResult = 7;
            int actualResult = 0;
            int shelterId = 100003;

            actualResult = _fundraisingCampaignManager.RetrieveAllFundraisingCampaignsByShelterId(shelterId).Count;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
