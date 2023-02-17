using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayer;
using LogicLayerInterfaces;
using DataAccessLayerFakes;
using DataObjects;
using System.Collections.Generic;

namespace LogicLayerTest
{
    [TestClass]
    public class RoleManagerTests
    {
        IRoleManager _roleManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _roleManager = new RoleManager(new RoleAccessorFakes());
        }

        [TestMethod]
        public void TestReturnsCorrectRoleList()
        {
            //arrange
            const int expectedCount = 2;
            int actualCount;

            //act
            actualCount = _roleManager.RetrieveAllRoles().Count;

            //assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestReturnsCorrectRoleListByUsersId()
        {
            //arrange
            const int expectedCount = 2;
            int actualCount;
            int usersId = 100001;

            //act
            actualCount = _roleManager.RetrieveRoleListByUserId(usersId).Count;

            //assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestAddRoleListToUserWorksWithCorrectData()
        {
            //arrange
            bool actualResult;
            int usersId = 100001;
            Role newRole = new Role();

            newRole.RoleId = "Veternarian";

            //act
            actualResult = _roleManager.AddRoleByUsersId(newRole, usersId);

            //assert
            Assert.IsTrue(actualResult);
        }

        [TestCleanup]
        public void TestTearDown()
        {
            _roleManager = null;
        }


    }
}
