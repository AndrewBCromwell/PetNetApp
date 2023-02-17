﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class RoleManagerTests
    {
        private IRoleManager _roleManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _roleManager = new RoleManager(new RoleAccessorFakes());
        }

        [TestCleanup]
        public void TestTearDown()
        {
            _roleManager = null;
        }

        // Created By: Asa Armstrong
        [TestMethod]
        public void TestRemoveRoleByUsersIdAndRoleIdPassRemoving1OfManyAdmin()
        {
            Assert.AreEqual(true, _roleManager.RemoveRoleByUsersIdAndRoleId(100000, "Admin"));
        }

        // Created By: Asa Armstrong
        [TestMethod]
        [ExpectedException(typeof(ApplicationException), "Cannot remove the last 'Admin' Role.")]
        public void TestRemoveRoleByUsersIdAndRoleIdRemoving1Of1AdminThrowsException()
        {
            _roleManager.RemoveRoleByUsersIdAndRoleId(100000, "Admin");
            _roleManager.RemoveRoleByUsersIdAndRoleId(100001, "Admin");
        }

        // Created By: Asa Armstrong
        [TestMethod]
        public void TestRemoveRoleByUsersIdAndRoleIdPassRemovingNonAdminRoleId()
        {
            Assert.AreEqual(true, _roleManager.RemoveRoleByUsersIdAndRoleId(100000, "Vet"));
        }
    }
}
