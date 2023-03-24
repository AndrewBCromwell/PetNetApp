/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// ShelterInventoryItemAccessor fakes
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class ShelterInventoryItemFakes : IShelterInventoryItemAccessor
    {
        private List<ShelterInventoryItemVM> fakeShelterInventoryItemVMs = new List<ShelterInventoryItemVM>();

        public ShelterInventoryItemFakes()
        {
            fakeShelterInventoryItemVMs.Add(new ShelterInventoryItemVM
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
                //CategoryId = "Food"


            });
            fakeShelterInventoryItemVMs.Add(new ShelterInventoryItemVM
            {
                ShelterId = 999999,
                ItemId = "Orange",
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
                ShelterName = "Shelter2",
                //CategoryId = "Food"

            });
            fakeShelterInventoryItemVMs.Add(new ShelterInventoryItemVM
            {
                ShelterId = 999998,
                ItemId = "Water",
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
                ShelterName = "Shelter3",
                //CategoryId = "liquid"
            });

        }
        public List<ShelterInventoryItemVM> SelectInventoryByShelter(int shelterId)
        {
            List<ShelterInventoryItemVM> shelterInventoryItemVMs = new List<ShelterInventoryItemVM>();
            foreach (ShelterInventoryItemVM shelterInventoryItemVM in fakeShelterInventoryItemVMs)
            {
                if (shelterInventoryItemVM.ShelterId == shelterId)
                {
                    shelterInventoryItemVMs.Add(shelterInventoryItemVM);
                }
            }
            return shelterInventoryItemVMs;
        }

        public ShelterInventoryItemVM SelectShelterInventoryItemByShelterIdAndItemId(int shelterId, string itemId)
        {
            ShelterInventoryItemVM shelterInventoryItemVMs = new ShelterInventoryItemVM();
            foreach (ShelterInventoryItemVM shelterInventoryItemVM in fakeShelterInventoryItemVMs)
            {
                if (shelterInventoryItemVM.ShelterId == shelterId && shelterInventoryItemVM.ItemId == itemId)
                {
                    return shelterInventoryItemVM;
                }
            }
            return shelterInventoryItemVMs; //Will return null if shelter is not found
        }

        public int UpdateShelterInventoryItem(ShelterInventoryItemVM oldShelterInventoryItemVM, ShelterInventoryItemVM newShelterInventoryItemVM)
        {
            int rowsAffected = 0;
            for (int i = 0; i < fakeShelterInventoryItemVMs.Count; i++)
            {
                if (fakeShelterInventoryItemVMs[i].ShelterId == oldShelterInventoryItemVM.ShelterId &&
                   fakeShelterInventoryItemVMs[i].ItemId == oldShelterInventoryItemVM.ItemId)
                {
                    fakeShelterInventoryItemVMs[i].LowInventoryThreshold = newShelterInventoryItemVM.LowInventoryThreshold;
                    fakeShelterInventoryItemVMs[i].HighInventoryThreshold = newShelterInventoryItemVM.HighInventoryThreshold;
                    fakeShelterInventoryItemVMs[i].InTransit = newShelterInventoryItemVM.InTransit;
                    fakeShelterInventoryItemVMs[i].LastUpdated = newShelterInventoryItemVM.LastUpdated;
                    fakeShelterInventoryItemVMs[i].Processing = newShelterInventoryItemVM.Processing;
                    fakeShelterInventoryItemVMs[i].Quantity = newShelterInventoryItemVM.Quantity;
                    fakeShelterInventoryItemVMs[i].ShelterName = newShelterInventoryItemVM.ShelterName;
                    fakeShelterInventoryItemVMs[i].CustomFlag = newShelterInventoryItemVM.CustomFlag;
                    fakeShelterInventoryItemVMs[i].DoNotOrder = newShelterInventoryItemVM.DoNotOrder;
                    fakeShelterInventoryItemVMs[i].Urgent = newShelterInventoryItemVM.Urgent;
                    fakeShelterInventoryItemVMs[i].UseStatistic = newShelterInventoryItemVM.UseStatistic;
                    rowsAffected++;
                }
            }
            return rowsAffected;

        }
    }
}
