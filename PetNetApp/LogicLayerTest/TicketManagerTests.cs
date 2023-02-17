using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DataAccessLayerFakes;
using LogicLayer;
using DataObjects;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTest
{
    /// <summary>
    /// Summary description for TicketManagerTests
    /// </summary>
    [TestClass]
    public class TicketManagerTests
    {
        private TicketManager _ticketManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _ticketManager = new TicketManager(new TicketAccessorFakes());
        }

        //[TestCleanup]
        //public void testTearDown()
        //{
        //    _ticketManager = null;
        //}

        [TestMethod]
        public void TestRetrieveAllTickets()
        {
            // Arrange
            int expectedCount = 3;
            int actualCount = 0;

            // Act
            var tickets = _ticketManager.RetrieveAllTickets();
            actualCount = tickets.Count();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

    }
}
