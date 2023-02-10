<<<<<<< HEAD
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayer;
using DataAccessLayerFakes;
=======
﻿using DataAccessLayerFakes;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> origin/main

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
<<<<<<< HEAD
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
=======
        public void TestRetrieveMedicalDiagnosisByAnimalId()
        {
            int animalId = 100000;
            int expectedCount = 1;
            int actualCount = 0;

            var medicalRecords = _medicalRecordManager.RetrieveMedicalRecordDiagnosisByAnimalId(animalId);
            actualCount = medicalRecords.Count;

            Assert.AreEqual(expectedCount, actualCount);
>>>>>>> origin/main
        }
    }
}
