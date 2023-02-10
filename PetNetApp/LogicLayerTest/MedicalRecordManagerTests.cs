using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayer;
using DataAccessLayerFakes;

namespace LogicLayerTest
{
    [TestClass]
    public class MedicalRecordManagerTests
    {
        private MedicalRecordManager _medicalRecordManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _medicalRecordManager = new MedicalRecordManager(new MedicalRecordAccessorFakes());
        }

        [TestMethod]
        public void TestSelectLastMedicalRecordIdByAnimalIdReturnsCorrectNumber()
        {
            int expectedResult = 61;
            int animalId = 51;
            int acctualResult;

            acctualResult = _medicalRecordManager.getLastMedicalRecordIdByAnimalId(animalId);

            Assert.AreEqual(expectedResult, acctualResult);
        }

        [TestMethod]
        public void TestSelectLastMedicalRecordIdByAnimalIdReturnsZeroIfNoMedicalRecordForAnimal()
        {
            int expectedResult = 0;
            int animalId = 49;
            int acctualResult;

            acctualResult = _medicalRecordManager.getLastMedicalRecordIdByAnimalId(animalId);

            Assert.AreEqual(expectedResult, acctualResult);
        }
    }
}
