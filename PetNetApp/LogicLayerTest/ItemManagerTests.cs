/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// Unit test class for ItemManager
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataObjects;
using LogicLayer;
using LogicLayerInterfaces;
using DataAccessLayerFakes;

namespace LogicLayerTest
{
    [TestClass]
    public class ItemManagerTests
    {
        ItemManager _itemManager = null;
        [TestInitialize]
        public void TestSetup()
        {
            _itemManager = new ItemManager(new ItemAccessorFakes());
        }

        [TestMethod]
        public void TestRetrieveItemByItemIdReturnsCorrectList()
        {
            string itemId = "Dog Food";
            int expectedResult = 4;
            int actualResult = _itemManager.RetrieveItemByItemId(itemId).CategoryId.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }

}
