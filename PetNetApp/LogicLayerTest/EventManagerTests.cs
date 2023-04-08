using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using DataAccessLayerFakes;
using DataObjects;

namespace LogicLayerTest
{
    [TestClass]
    public class EventManagerTests
    {
        private EventManager _eventManager = null;
        private EventAccessorFakes fake = null;

        [TestInitialize]
        public void TestSetup()
        {
            _eventManager = new EventManager(new EventAccessorFakes());
            fake = new EventAccessorFakes();
        }

        [TestMethod]
        public void TestSelectAllEvent()
        {
            int expectedCount = 1;
            int actualCount = 0;

            actualCount = fake.SelectAllEvent().Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
