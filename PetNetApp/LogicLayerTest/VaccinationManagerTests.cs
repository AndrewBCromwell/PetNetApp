/// <summary>
/// Zaid Rachman
/// Created: 2023/02/09
/// 
/// Unit test class for the logic in VaccinationManager
/// 
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayer;
using DataAccessLayerFakes;
using DataObjects;
using System.Collections.Generic;
namespace LogicLayerTest
{
    
    [TestClass]
    public class VaccinationManagerTests
    {
        VaccinationManager vaccinationManager = null;
        [TestInitialize]
        public void TestUp()
        {
            vaccinationManager = new VaccinationManager(new VaccinationAccessorFake());
        }
        /// <summary>
        /// Zaid Rachman
        /// 2023/02/09
        /// 
        /// Tests RetrieveVaccinationsByAnimal
        /// </summary>
        [TestMethod]
        public void TestRetrieveVaccinationsByAnimalId()
        {
            int animalId = 999999;
            int expectedResult = 1;
            int actualResult = vaccinationManager.RetrieveVaccinationsByAnimalId(animalId).Count;
            Assert.AreEqual(expectedResult, actualResult);
        }
        /// <summary>
        /// Zaid Rachman
        /// 2023/02/09
        /// 
        /// Tests AddVaccination
        /// </summary>
        [TestMethod]
        public void TestAddVaccinationByMedicalRecordId()
        {
            /*
             *  int medicalRecordId,
                int usersId, string vaccineName, DateTime vaccineAdminsterDate
             * */
            int animalId = 999999;
            Vaccination testVaccination = new Vaccination();
            testVaccination.VaccineId = 999995;
            testVaccination.UserId = 999999;
            testVaccination.MedicalRecordId = 999995;
            testVaccination.VaccineAdminsterDate = new DateTime(2000, 12, 12);
            testVaccination.VaccineName = "tester";

            bool expectedResult = true;
            bool actualResult = vaccinationManager.AddVaccination(testVaccination, animalId);
            Assert.AreEqual(expectedResult, actualResult);
        }
        /// <summary>
        /// Zaid Rachman
        /// 2023/02/09
        /// TestsEditVaccination
        /// 
        /// </summary>
        [TestMethod]
        public void TestEditVaccination()
        {
            Vaccination testOldVaccination = new Vaccination();
            testOldVaccination.VaccineId = 999997;
            testOldVaccination.UserId = 999999;
            testOldVaccination.MedicalRecordId = 999999;
            testOldVaccination.VaccineAdminsterDate = new DateTime(2000, 12, 12);
            testOldVaccination.VaccineName = "TestVaccine1";

            Vaccination testVaccination = testOldVaccination;
            testVaccination.VaccineId = 999999;
            testVaccination.UserId = 999999;
            testVaccination.MedicalRecordId = 999999;
            testVaccination.VaccineAdminsterDate = new DateTime(2000, 12, 12);
            testVaccination.VaccineName = "tester";



            bool expectedResult = true;
            bool actualResult = vaccinationManager.EditVaccination(testOldVaccination, testVaccination);
            Assert.AreEqual(expectedResult, actualResult);

        }

    }
}
