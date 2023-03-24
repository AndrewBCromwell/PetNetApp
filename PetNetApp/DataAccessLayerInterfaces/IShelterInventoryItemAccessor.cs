/// <summary>
/// Zaid
/// Created: 2023/03/19
/// 
/// Interface for ShelterInventoryAccessor
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

namespace DataAccessLayerInterfaces
{
    public interface IShelterInventoryItemAccessor
    {
        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/03/19
        /// 
        /// Retrieves list of inventory items by shelterId. Takes in ShelterId as a parameter
        /// </summary>
        /// <param name="shelterId"></param>
        /// <returns></returns>
        List<ShelterInventoryItemVM> SelectInventoryByShelter(int shelterId);
        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/03/19
        /// 
        /// Retrieves list of inventory items by shelterId and ItemId as. Takes in ShelterId and ItemId as parameters.
        /// </summary>
        /// <param name="shelterId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        ShelterInventoryItemVM SelectShelterInventoryItemByShelterIdAndItemId(int shelterId, string itemId);
        /// <summary>
        ///  
        /// Zaid Rachman
        /// Created: 2023/03/19
        /// 
        /// Edits ShelterInventoryItem. Takes in the oldShelterInventoryItemVM and newShelterInventoryItemVM objects as parameters.
        /// 
        /// </summary>
        /// <param name="oldShelterInventoryItemVM"></param>
        /// <param name="newShelterInventoryItemVM"></param>
        /// <returns></returns>
        int UpdateShelterInventoryItem(ShelterInventoryItemVM oldShelterInventoryItemVM, ShelterInventoryItemVM newShelterInventoryItemVM);
    }
}
