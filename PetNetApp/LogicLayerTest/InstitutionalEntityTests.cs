﻿/// <summary>
/// Barry Mikulas
/// Created: 2023/03/01
/// 
/// Test methods for Institutional Entity Manager methods
/// </summary>
///
/// <remarks>
/// Updater
/// Updated: 
/// Comments:
/// </remarks>
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayerInterfaces;
using DataAccessLayerFakes;
using DataObjects;
using LogicLayer;
using LogicLayerInterfaces;

namespace LogicLayerTest
{
    [TestClass]
    public class InstitutionalEntityTests
    {
        private IInstitutionalEntityManager _institutionalEntityManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _institutionalEntityManager = new InstitutionalEntityManager(new InstitutionalEntityAccessorFakes());
        }

        [TestMethod]
        public void TestRetrievesCorrectNumberOfInstitutionalEntitiesByShelterIdAndEntityType()
        {
            InstitutionalEntityAccessorFakes fakes = new InstitutionalEntityAccessorFakes();
            string entityType = "Host";
            int shelterId = 100000;
            // arrange
            int expectedResult = fakes._institutionalEntities.FindAll(i => i.ContactType == entityType && i.ShelterId == shelterId).Count;
            //int expectedResult = 3;

            // act
            int actualResult = _institutionalEntityManager.RetrieveAllInstitutionalEntitiesByShelterIdAndEntityType(shelterId, entityType).Count;

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCleanup]
        public void TestTearDown()
        {
            _institutionalEntityManager = null;
        }
    }
}
