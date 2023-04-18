using DataAccessLayerFakes;
using DataObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicLayerTest
{
    [TestClass]
    public class AdoptionApplicationResponseTests  
    {
        private AdoptionApplicationResponseManager _manager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _manager = new AdoptionApplicationResponseManager(new AdoptionApplicationResponseAccessorFakes());
        }


        [TestMethod]
        public void TestAddAdoptionApplicationResponseByAdoptionApplicationId()
        {
            bool expectedResult = true;
            bool actualResult = false;
            AdoptionApplicationResponseVM application = new AdoptionApplicationResponseVM()
            {
                AdoptionApplicationResponseId = 1,
                AdoptionApplicationId = 1,
                ResponderUserId = 1,
                Approved = false,
                AdoptionApplicationResponseDate = DateTime.Now,
                AdoptionApplicationResponseNotes = "denied, too stinky",
                Application = new AdoptionApplication(),
                Responder = new Users()
            };

            actualResult = _manager.AddAdoptionApplicationResponseByAdoptionApplicationId(application);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
