using DataAccessLayerFakes;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicLayerTest
{
    [TestClass]
    public class FundraisingEventManagerTests
    {
        private FundraisingEventManager _fundraisingEventManager = null;
        [TestInitialize]
        public void SetupTests()
        {
            _fundraisingEventManager = new FundraisingEventManager(new FundraisingEventAccessorFakes());
        }

        [TestCleanup]
        public void TeardownTests()
        {
            _fundraisingEventManager = null;
        }

        [TestMethod]
        public void TestRetrieveFundraisingEventsByShelterId()
        {
            //arrange
            FundraisingEventAccessorFakes fakes = new FundraisingEventAccessorFakes();
            int shelterId = 100006;
            int actualResult = 0;
            int expectedResult = 6;

            // act
            actualResult = fakes.SelectAllFundraisingEventsByShelterId(shelterId).Count;
            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
