﻿/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// Interface for ItemManager
/// </summary>
///
/// <remarks>
/// Nathan Zumsande
/// Updated: 2023/03/31
/// Added methods AddItem, RetrieveAllCategories
/// AddItemCategory, RemoveItemCategory, AddCategory
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
        /// 
        /// <remarks>
        /// Oleksiy Fedchuk
        /// Updated: 2023/04/20
        /// 
        /// Final QA
        /// </remarks>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Item RetrieveItemByItemId(string itemId);

        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/03/22
        /// 
        /// Adds an Item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>True or false if row was added</returns>
        bool AddItem(string itemId);

        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/03/22
        /// 
        /// Returns a list of strings that are the item categories
        /// </summary>
        /// <returns>A list of the string categories</returns>
        List<string> RetrieveAllCategories();

        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/03/22
        /// 
        /// Adds an ItemCategory
        /// </summary>
        /// 
        /// <remarks>
        /// Oleksiy Fedchuk
        /// Updated: 2023/04/13
        /// 
        /// FinalQA
        /// </remarks>
        /// <param name="itemId"></param>
        /// <param name="category"></param>
        /// <returns>True or false if row was added</returns>
        bool AddItemCategory(string itemId, string category);

        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/04/06
        /// 
        /// Adds a Category
        /// </summary>
        /// 
        /// <remarks>
        /// Oleksiy Fedchuk
        /// Updated: 2023/04/13
        /// 
        /// FinalQA
        /// </remarks>
        /// <param name="categoryId"></param>
        /// <returns>True or false if row was added</returns>
        bool AddCategory(string categoryId);

        /// <summary>
        /// Nathan Zumsande
        /// Created: 2023/03/30
        /// 
        /// Removes an ItemCategory
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="category"></param>
        /// <returns>True or false if row was removed</returns>
        bool RemoveItemCategory(string itemId, string category);
    }
}
