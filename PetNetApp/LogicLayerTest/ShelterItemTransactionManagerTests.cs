using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using DataAccessLayerFakes;
using LogicLayer;
using DataObjects;
using System.Collections.Generic;

namespace LogicLayerTest
{
    [TestClass]
    public class ShelterItemTransactionManagerTests
    {
        private IShelterItemTransactionManager _shelterItemTransactionManager;

        [TestInitialize]
        public void TestSetup()
        {
            _shelterItemTransactionManager = new ShelterItemTransactionManager(new ShelterItemTransactionAccessorFakes());
        }

        [TestMethod]
        public void TestRetrieveInventoryTransactionByShelterIdReturnsTheCorrectNumberOfRecords()
        {
            List<ShelterItemTransactionVM> shelterItemTransactions;
            int expectedCount = 2;
            int shelterId = 55;

            shelterItemTransactions = _shelterItemTransactionManager.RetrieveInventoryTransactionByShelterId(shelterId);

            Assert.AreEqual(expectedCount, shelterItemTransactions.Count);
        }
    }
}
