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
        IRoleManager roleManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            //roleManager = new RoleManager();
            roleManager = new RoleManager(new RoleAccessorFake());
        }

        [TestMethod]
        public void TestReturnsCorrectRoleList()
        {
            //arrange
            const int expectedCount = 2;
            int actualCount;

            //act
            actualCount = roleManager.RetrieveAllRoles().Count;

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
            actualCount = roleManager.RetrieveRoleListByUserId(usersId).Count;

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
            actualResult = roleManager.AddRoleByUsersId(newRole, usersId);

            //assert
            Assert.IsTrue(actualResult);
        }

    }
}
