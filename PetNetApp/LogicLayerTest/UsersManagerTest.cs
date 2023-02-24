using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccessLayer;
using DataObjects;
using LogicLayer;
using DataAccessLayerInterfaces;
using DataAccessLayerFakes;
using System.Collections.Generic;
using LogicLayerInterfaces;


namespace LogicLayerTest
{
    [TestClass]
    public class UsersManagerTest
    {
        private IUsersManager _userManager = null;


        [TestInitialize]
        public void TestSetup()
        {
            _userManager = new UsersManager(new UsersAccessorFakes()); // Fake Data
            // _userManager = new UsersManager(new UsersAccessor()); // Actual Data
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
            int shelterId = 1;
            int actualCount = 0;

            // act
            actualCount = _userManager.RetrieveUserByRole(role,shelterId).Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);


        }

        [TestMethod]
        public void TestSelectAllEmployee()
        {
            List<UsersVM> listUser = null;
            listUser = _userManager.RetriveAllEmployees();

            int actualResult = listUser.Count;
            int expectedResult = 4;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]

        public void TestDeactivateAccount()
        {
            //arrage 
            int userId = 1000;
            bool expectedResult = true;
            bool actualResult = false;

            //act 
            actualResult = _userManager.DeactivateUserAccount(userId);

            //assert
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void TestCreateUser()
        {
            //arrage 
            bool actualResult = false;

            //act 
            actualResult = _userManager.AddUser(new Users(), "fakePassword");

            //assert
            Assert.IsTrue(actualResult);

        }

        /// <summary>
        /// Zaid Rachman
        /// 2023/02/15
        /// 
        /// Tests SelectUsersByUsersId by inputing a sample usersId
        /// </summary>
        [TestMethod]
        /*This test method is used to test if the user exists*/
        public void TestSelectUsersByUsersId()
        {
            int sampleId = 1000;
            int expectedResult = 1;

            int actualResult = _userManager.RetrieveUsersByUsersId(sampleId).Count;
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestSelectUserByUsersId()
        {
            //arrange
            Users expectedUser;
            expectedUser = new Users()
            {
                UsersId = 1000,
                GivenName = "Stephan",
                FamilyName = "technowiz",
                Email = "Stephan@company.com",
                Address = "4150 riverview road",
                Zipcode = "52411",
                Phone = "319-123-1325",
                Active = true

            };

            int usersId = 1000;

            //act
            var actualUser = _userManager.RetrieveUserByUsersId(usersId);

            //assert
            Assert.AreEqual(actualUser.GivenName, expectedUser.GivenName);
            Assert.AreEqual(actualUser.FamilyName, expectedUser.FamilyName);
            Assert.AreEqual(actualUser.Email, expectedUser.Email);
            Assert.AreEqual(actualUser.Address, expectedUser.Address);
            Assert.AreEqual(actualUser.Zipcode, expectedUser.Zipcode);
            Assert.AreEqual(actualUser.Phone, expectedUser.Phone);
            Assert.AreEqual(actualUser.Active, expectedUser.Active);
        }

        [TestMethod]
        public void TestEditUserActive()
        {
            // Arrange
            int rowsAffected;

            // Act
            rowsAffected = _userManager.EditUserActive(1001, false);

            int expectedRowResult = 1;

            // Assert
            Assert.AreEqual(rowsAffected, expectedRowResult);
        }
    }
}
