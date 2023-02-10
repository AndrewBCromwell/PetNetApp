using DataAccessLayerFakes;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
