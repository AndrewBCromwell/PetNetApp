using DataAccessLayerFakes;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicLayerTest
{
    [TestClass]
    public class ImagesManagerTests
    {
        private IImagesManager _imagesManager = null;
        
        [TestInitialize]
        public void TestSetup()
        {
            _imagesManager = new ImagesManager(new ImagesAccessorFakes());
        }

        [TestCleanup]
        public void TestTearDown()
        {
            _imagesManager = null;
        }

        [TestMethod]
        public void TestSelectImagesByAnimalId()
        {
            const int expectedResult = 2;
            int animalId = 5;
            int actualResult = 0;

            actualResult = _imagesManager.RetrieveImagesByAnimalId(animalId).Count;

            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestInsertMedicalImageByAnimalId()
        {
            bool expectedResult = true;
            int animalId = 1;
            string imagefileName = "beepboop.png";
            bool actualResult = _imagesManager.AddMedicalImageByAnimalId(animalId, imagefileName);

            Assert.AreEqual(expectedResult, actualResult);

  
        }
    }
}
