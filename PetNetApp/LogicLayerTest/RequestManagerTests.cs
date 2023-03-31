using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayer;
using DataAccessLayerFakes;
using DataObjects;
using System.Collections.Generic;

namespace LogicLayerTest
{
    [TestClass]
    public class RequestManagerTests
    {
        private RequestManager _requestManager = null;

        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/03/15
        /// </summary>
        [TestInitialize]
        public void TestSetup()
        {
            _requestManager = new RequestManager(new RequestAccessorFakes());
        }

        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/03/15
        /// </summary> 
        [TestMethod]
        public void TestRetrieveRequestsByShelterIdReturnsTheCorrectNumberOfRequests()
        {
            int expectedNumberOfRequests = 2;
            int shelterId = 55;
            List<RequestVM> requests = null;

            requests = _requestManager.RetrieveRequestsByShelterId(shelterId);

            Assert.AreEqual(expectedNumberOfRequests, requests.Count);
        }

        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/03/15
        /// </summary> 
        [TestMethod]
        public void TestRetrieveRequestsByShelterIdGivesTheCorrectNumberOfRequestLinesToEachRequest()
        {
            int expectedNumberOfRequestLines = 3;
            int indexToCheck = 1;
            int shelterId = 55;
            List<RequestVM> requests = null;

            requests = _requestManager.RetrieveRequestsByShelterId(shelterId);

            Assert.AreEqual(expectedNumberOfRequestLines, requests[indexToCheck].RequestLines.Count);
        }
    }
}
