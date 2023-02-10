/// <summary>
/// Chris Dreismeier
/// Created: 2023/02/09
/// 
/// Unit Test class to test all the logic of the ScheduleManager
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataObjects;
using LogicLayer;
using DataAccessLayerInterfaces;
using DataAccessLayerFakes;
using System.Collections.Generic;
using LogicLayerInterfaces;

namespace LogicLayerTest
{
    [TestClass]
    public class ScheduleManagerTests
    {
        private IScheduleManager _scheduleManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _scheduleManager = new ScheduleManager(new ScheduleAccessorFakes());
        }

        [TestCleanup]
        public void TestTearDown()
        {
            _scheduleManager = null;
        }



        /// <summary>
        ///  Chris Dreismeier
        ///  2023/02/09
        /// </summary>
        [TestMethod]
        public void TestRetrieveScheduleByDate()
        {
            // arrange
            const int expectedCount = 2;
            DateTime selectedDate = new DateTime(DateTime.Now.Year, 2, 10, 7, 0, 0);
            int actualCount = 0;

            // act
            actualCount = _scheduleManager.RetrieveScheduleByDate(selectedDate).Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);

        }
    }
}
