using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayer;
using DataAccessLayerFakes;
using DataObjects;
using System.Collections.Generic;

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

            acctualResult = _medicalRecordManager.RetrieveLastMedicalRecordIdByAnimalId(animalId);

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

            acctualResult = _medicalRecordManager.RetrieveLastMedicalRecordIdByAnimalId(animalId);

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

        [TestMethod]
        public void UpdateTreatmentByMedicalRecordId()
        {
            int animalId = 100000;
            int expectedResult = 1;

            int actualResult = _medicalRecordManager.UpdateTreatmentByMedicalRecordId(animalId, "New Diagnosis Name", "New Diagnosis Notes");


            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/02/27
        /// </summary>
        [TestMethod]
        public void TestAddMedicalRecordAddsMedicalRecordReturningMedicalRecordId()
        {
            int returnedValue = 0;
            int actualMedicalRecordId = 56;
            int animalId = 3;
            MedicalRecordVM medicalRecord = new MedicalRecordVM()
            {
                MedicalRecordId = actualMedicalRecordId,
                AnimalId = animalId
            };
            List<MedicalRecordVM> recordsReturned;
            int recordsReturnedExpectedCount = 1;

            returnedValue = _medicalRecordManager.AddMedicalRecord(medicalRecord);
            recordsReturned = _medicalRecordManager.RetrieveMedicalRecordDiagnosisByAnimalId(animalId);

            Assert.AreEqual(actualMedicalRecordId, returnedValue);
            Assert.AreEqual(recordsReturnedExpectedCount, recordsReturned.Count);
        }

        [TestMethod]
        public void TestRetrieveMedicalRecordsByAnimalId()
        {
            int animalId = 100000;
            int expectedCount = 1;
            int actualCount = _medicalRecordManager.RetrieveAllMedicalRecordsByAnimalId(animalId).Count;

            Assert.AreEqual(expectedCount, actualCount);

        }
    }
}
