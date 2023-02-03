using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccessLayer;
using DataObjects;
using LogicLayer;
using DataAccessLayerInterfaces;
using DataAccessLayerFakes;
using System.Collections.Generic;

namespace LogicLayerTest
{
    [TestClass]
    public class UsersManagerTest
    {
        private IUsersManager _userManager = null;


        [TestInitialize]
        public void TestSetup()
        {
            _userManager = new UsersManager(new UsersAccessorFakes());
        }

        [TestCleanup]
        public void TestTearDown()
        {
            _userManager = null;
        }


        [TestMethod]
        public void TestRetrieveUserByRole()
        {
            // arrange
            const int expectedCount = 3;
            string role = "Volunteer";
            int actualCount = 0;

            // act
            actualCount = _userManager.RetrieveUserByRole(role).Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);
        UsersManager usersManager = null;

        [TestMethod]
        public void TestSelectAllEmployee()
        {
            List<Users> listUser = null;
            listUser = usersManager.RetriveAllEmployees();

            int actualResult = listUser.Count;
            int expectedResult = 10; // 3 for fake data

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
