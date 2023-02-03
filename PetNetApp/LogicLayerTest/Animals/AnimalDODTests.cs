using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayerInterfaces;
using DataAccessLayerFakes;
using DataObjects;
using LogicLayer;
using LogicLayerInterfaces;

namespace LogicLayerTest.Animals
{
    [TestClass]
    public class AnimalDODTests
    {
        private IDeathManager _deathManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _deathManager = new DeathManager(new FakeDeathAccessor());
        }

        [TestCleanup]
        public void TestTearDown()
        {
            _deathManager = null;
        }

        [TestMethod]
        public void TestAddAnimalDOD()
        {
            DeathVM death = new DeathVM()
            {
                UsersId = 100000,
                AnimalId = 100000,
                DeathDate = DateTime.Now,
                DeathCause = "death cause",
                DeathDisposal = "death disposal",
                DeathDisposalDate = DateTime.Now,
                DeathNotes = "death notes"
            };

            Assert.AreEqual(_deathManager.AddAnimalDOD(death), true);
        }
    }
}
