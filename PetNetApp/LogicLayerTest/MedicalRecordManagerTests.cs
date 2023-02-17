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

        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/02/08
        /// </summary>
        [TestMethod]
        public void TestSelectLastMedicalRecordIdByAnimalIdReturnsCorrectNumber()
        {
            int expectedResult = 61;
            int animalId = 51;
            int acctualResult;

            acctualResult = _medicalRecordManager.getLastMedicalRecordIdByAnimalId(animalId);

            Assert.AreEqual(expectedResult, acctualResult);
        }

        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/02/08
        /// </summary>
        [TestMethod]
        public void TestSelectLastMedicalRecordIdByAnimalIdReturnsZeroIfNoMedicalRecordForAnimal()
        {
            int expectedResult = 0;
            int animalId = 49;
            int acctualResult;

            acctualResult = _medicalRecordManager.getLastMedicalRecordIdByAnimalId(animalId);

            Assert.AreEqual(expectedResult, acctualResult);
        }

        [TestMethod]
        public void TestRetrieveMedicalDiagnosisByAnimalId()
        {
            int animalId = 100000;
            int expectedCount = 1;
            int actualCount = 0;

            var medicalRecords = _medicalRecordManager.RetrieveMedicalRecordDiagnosisByAnimalId(animalId);
            actualCount = medicalRecords.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
