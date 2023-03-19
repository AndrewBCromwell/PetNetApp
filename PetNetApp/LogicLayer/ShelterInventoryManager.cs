/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// Logic layer for ShelterInventoryManager
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
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayer;
using DataAccessLayerInterfaces;

namespace LogicLayer
{
    public class ShelterInventoryItemManager : IShelterInventoryItemManager
    {
        private IShelterInventoryItemAccessor _shelterInventoryItemAccessor = null;
        public ShelterInventoryItemManager()
        {
            _shelterInventoryItemAccessor = new ShelterInventoryItemAccessor();
        }
        public ShelterInventoryItemManager(IShelterInventoryItemAccessor shelterInventoryItemAccessor)
        {
            _shelterInventoryItemAccessor = shelterInventoryItemAccessor;
        }

        public bool EditShelterInventoryItem(ShelterInventoryItemVM oldShelterInventoryItemVM, ShelterInventoryItemVM newShelterInventoryItemVM)
        {
            bool result = false;
            try
            {
                result = (1 == _shelterInventoryItemAccessor.UpdateShelterInventoryItem(oldShelterInventoryItemVM, newShelterInventoryItemVM));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        public List<ShelterInventoryItemVM> RetrieveInventoryByShelterId(int shelterId)
        {

            List<ShelterInventoryItemVM> shelterInventoryItemVMs = null;
            try
            {
                shelterInventoryItemVMs = _shelterInventoryItemAccessor.SelectInventoryByShelter(shelterId);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not found", ex);
            }
            return shelterInventoryItemVMs;
        }

        public ShelterInventoryItemVM RetrieveInventoryItemByShelterIdAndItemId(int shelterId, string itemId)
        {
            ShelterInventoryItemVM shelterInventoryItemVMs = null;
            try
            {
                shelterInventoryItemVMs = _shelterInventoryItemAccessor.SelectShelterInventoryItemByShelterIdAndItemId(shelterId, itemId);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not found", ex);
            }
            return shelterInventoryItemVMs;
        }
    }
}
