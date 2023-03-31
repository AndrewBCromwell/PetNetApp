﻿/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// Interface for itemAccessor
/// </summary>
///
/// <remarks>
/// Nathan Zumsande
/// Updated: 2023/03/31
/// Added methods InsertItem, SelectAllCategories
/// InsertItemCategory, DeleteItemCategory
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

        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/03/22
        /// 
        /// Inserts an Item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>Number of rows affected</returns>
        int InsertItem(string itemId);

        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/03/22
        /// 
        /// Returns a list of all the categories in the category table
        /// </summary>
        /// <returns>A list of all the categories</returns>
        List<string> SelectAllCategories();

        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/03/22
        /// 
        /// Inserts an ItemCategory
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="category"></param>
        /// <returns>Number of rows affected</returns>
        int InsertItemCategory(string itemId, string category);

        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/03/22
        /// 
        /// Deletes an ItemCategory
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="category"></param>
        /// <returns>Number of rows affected</returns>
        int DeleteItemCategory(string itemId, string category);
    }
}
