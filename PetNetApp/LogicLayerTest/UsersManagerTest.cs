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
        UsersManager usersManager = null;

        [TestInitialize]
        public void TestSetUp()
        {
            //usersManager = new UsersManager(new UserAccessorFake()); // Fake Data
            usersManager = new UsersManager(new UsersAccessor()); // Actual Data
        }

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
