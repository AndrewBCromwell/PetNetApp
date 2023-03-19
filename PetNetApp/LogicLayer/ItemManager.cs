/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// Logic layer for ItemManager
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
using DataAccessLayerInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    public class ItemManager : IItemManager
    {
        private IItemAccessor _itemAccessor = null;
        public ItemManager()
        {
            _itemAccessor = new ItemAccessor();
        }
        public ItemManager(IItemAccessor itemAccessor)
        {
            _itemAccessor = itemAccessor;

        }
        public Item RetrieveItemByItemId(string itemId)
        {
            Item item = null;
            try
            {
                item = _itemAccessor.SelectItemByItemId(itemId);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Items not found", ex);
            }
            return item;
        }
    }
}
