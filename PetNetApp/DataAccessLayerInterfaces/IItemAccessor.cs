/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// Interface for itemAccessor
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
    public interface IItemAccessor
    {
        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/03/19
        /// 
        /// Returns an Item by Item Id. Takes in itemId as a parameter
        /// </summary>
        /// <param name="ItemId"></param>
        /// <returns></returns>
        Item SelectItemByItemId(string ItemId);
    }
}
