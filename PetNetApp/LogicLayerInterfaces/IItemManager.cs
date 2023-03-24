/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// Interface for ItemManager
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

namespace LogicLayerInterfaces
{
    public interface IItemManager
    {
        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/03/19
        /// 
        /// Returns an Item by Item Id. Takes in itemId as a parameter
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Item RetrieveItemByItemId(string itemId);
    }
}
