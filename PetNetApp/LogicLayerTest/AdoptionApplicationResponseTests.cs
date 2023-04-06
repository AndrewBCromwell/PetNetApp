// Created By Asa Armstrong
// Created On 2023/04/04
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccessLayerFakes;
using DataObjects;
using LogicLayer;
using LogicLayerInterfaces;

namespace LogicLayerTest
{
    [TestClass]
    public class AdoptionApplicationResponseTests
    {
        private IAdoptionApplicationResponseManager _responseManager = null;
        readonly static DateTime dt = DateTime.Now;

        private AdoptionApplicationResponse _response = new AdoptionApplicationResponse()
        {
            AdoptionApplicationResponseId = 999_998,
            AdoptionApplicationId = 999_998,
            ResponderUserId = 999_998,
            Approved = false,
            AdoptionApplicationResponseDate = dt,
            AdoptionApplicationResponseNotes = "notes"
        };

        private AdoptionApplicationResponse _response2 = new AdoptionApplicationResponse()
        {
            AdoptionApplicationResponseId = 999_998,
            AdoptionApplicationId = 999_998,
            ResponderUserId = 999_998,
            Approved = false,
            AdoptionApplicationResponseDate = dt,
            AdoptionApplicationResponseNotes = "notes"
        };

        [TestInitialize]
        public void TestSetup()
        {
            _responseManager = new AdoptionApplicationResponseManager(new AdoptionApplicationResponseAccessorFakes());
        }

        [TestCleanup]
        public void TestTearDown()
        {
            _responseManager = null;
        }

        [TestMethod]
        public void TestAddAdoptionApplicationResponse()
        {
            Assert.IsTrue(_responseManager.AddAdoptionApplicationResponse(_response));
        }

        [TestMethod]
        public void TestRetrieveAdoptionApplicationResponse()
        {
            _responseManager.AddAdoptionApplicationResponse(_response);
            var response = _responseManager.RetrieveAdoptionApplicationResponse(_response.AdoptionApplicationId);
            Assert.IsTrue(response.Equals(_response));
        }

        [TestMethod]
        public void TestAdoptionApplicationResponseEquals()
        {
            Assert.IsTrue(_response.Equals(_response2));
        }

        [TestMethod]
        public void TestEditAdoptionApplicationResponse()
        {
            _responseManager.AddAdoptionApplicationResponse(_response);
            AdoptionApplicationResponse response = _response;
            response.AdoptionApplicationResponseNotes = "new comments";

            Assert.IsTrue(_responseManager.EditAdoptionApplicationResponse(response, _response));
        }
    }
}
