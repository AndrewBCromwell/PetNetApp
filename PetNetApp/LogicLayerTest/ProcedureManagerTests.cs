using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataObjects;
using DataAccessLayerFakes;
using LogicLayer;

namespace LogicLayerTest
{
    [TestClass]
    public class ProcedureManagerTests
    {
        private ProcedureManager _procedureManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _procedureManager = new ProcedureManager(new ProcedureAccessorFakes());
        }

        [TestMethod]
        public void TestAddProcedureByMedicalRecordIdReturnsTrueIfProcedureIsSaved()
        {
            Procedure procedure = new Procedure
            {
                ProcedureId = 0,
                MedicalRecordId = 0,
                UserId = 0,
            };
            int medicalRecordId = 0;

            bool result = _procedureManager.AddProcedureByMedicalRecordId(procedure, medicalRecordId);

            Assert.IsTrue(result);
        }
    }
}
