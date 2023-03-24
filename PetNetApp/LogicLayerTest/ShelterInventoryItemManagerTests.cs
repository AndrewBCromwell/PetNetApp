/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// This is the unit test class for the ShelterInventoryItemManager
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
using DataAccessLayerFakes;

namespace LogicLayerTest
{
    [TestClass]
    public class ShelterInventoryItemManagerTests
    {
        ShelterInventoryItemManager _shelterInventoryItemManager = null;
        [TestInitialize]
        public void TestSetUp()
        {
            _shelterInventoryItemManager = new ShelterInventoryItemManager(new ShelterInventoryItemFakes());
        }


        [TestMethod]
        public void TestRetrieveShelterInventoryItemReturnsCorrectList()
        {
            int shelterId = 999999;
            int expectedResult = 2;
            int actualResult = _shelterInventoryItemManager.RetrieveInventoryByShelterId(shelterId).Count;
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void TestRetrieveShelterInventoryItemByShelterIdandItemIdReturnsCorrectList()
        {
            int shelterId = 999999;
            string itemId = "Apple";
            ShelterInventoryItemVM testShelterInventoryItemVM = new ShelterInventoryItemVM();
            testShelterInventoryItemVM = _shelterInventoryItemManager.RetrieveInventoryItemByShelterIdAndItemId(shelterId, itemId);
            int expectedResult = 999999;
            int actualResult = testShelterInventoryItemVM.ShelterId;
            Assert.AreEqual(expectedResult, actualResult);



        }
        [TestMethod]
        public void TestEditShelterInventoryItem()
        {
            ShelterInventoryItemVM testOldShelterInventoryItemVM = new ShelterInventoryItemVM
            {
                ShelterId = 999999,
                ItemId = "Apple",
                Quantity = 0,
                UseStatistic = 7.1m,
                LastUpdated = new DateTime(2000, 12, 12),
                LowInventoryThreshold = 5,
                HighInventoryThreshold = 10,
                InTransit = false,
                Urgent = false,
                Processing = false,
                DoNotOrder = false,
                CustomFlag = "Other information that may be important for the inventory item.",
                //VM
                ShelterName = "Shelter1",


            };
            ShelterInventoryItemVM testNewShelterInventoryItemVM = new ShelterInventoryItemVM
            {
                ShelterId = 999999,
                ItemId = "Apple",
                Quantity = 37,
                UseStatistic = 7.1m,
                LastUpdated = DateTime.Now,
                LowInventoryThreshold = 5,
                HighInventoryThreshold = 10,
                InTransit = true,
                Urgent = false,
                Processing = false,
                DoNotOrder = false,
                CustomFlag = "Other information that may be important for the inventory item.",
                //VM
                ShelterName = "Shelter1",


            };

        }
    }
}
