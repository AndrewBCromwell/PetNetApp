using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayerInterfaces;
using DataAccessLayerFakes;
using LogicLayer;

namespace LogicLayerTest
{
    [TestClass]
    public class TestManagerTests
    {
        private ITestManager _testManager = null;


        [TestInitialize]
        public void TestSetup()
        {
            _testManager = new TestManager(new TestAccessorFake());
        }

        [TestCleanup]
        public void TestTearDown()
        {
            _testManager = null;
        }

        [TestMethod]
        public void TestSelectTestsByAnimalId()
        {
            // arrange
            const int expectedCount = 2;
            int animalId = 1;
            int actualCount = 0;

            // act
            actualCount = _testManager.RetrieveTestsByAnimalId(animalId).Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);

        }

        [TestMethod]
        public void TestSelectTestByMedicalRecordId()
        {
            int medicalRecordId = 1;
            int expectedTestId = 1;
            int actualTestId = _testManager.RetrieveTestByMedicalRecordId(medicalRecordId).TestId;

            Assert.AreEqual(expectedTestId, actualTestId);
        }
    }
}
