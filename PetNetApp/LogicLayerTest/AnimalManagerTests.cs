using DataAccessLayerFakes;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayerTest
{
    /// <summary>
    /// Summary description for AnimalManagerTests
    /// </summary>
    [TestClass]
    public class AnimalManagerTests
    {
        AnimalManager animalManager = null;
      
        [TestInitialize]
        public void TestSetup()
        {
            animalManager = new AnimalManager(new AnimalAccessorFakes());
        }

      

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestRetrieveAllAnimalsReturnsCorrectList()
        {
            // arrange
            const int expectedCount = 6;
            int actualcount = 0;

            // act
            actualcount = animalManager.RetrieveAllAnimals().Count;

            // assert 
            Assert.AreEqual(expectedCount, actualcount);
        }
    }
}
