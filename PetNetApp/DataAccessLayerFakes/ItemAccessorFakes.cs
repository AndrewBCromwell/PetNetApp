/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// ItemAccessor Fake
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
using DataAccessLayerInterfaces;

namespace DataAccessLayerFakes
{
    public class ItemAccessorFakes : IItemAccessor
    {
        List<Item> fakeItems = new List<Item>();
        public ItemAccessorFakes()
        {
            fakeItems.Add(new Item
            {
                ItemId = "Cat Food",
                CategoryId = new List<string> { "Cat", "Food", "Testing CategoryId" }
            });
            fakeItems.Add(new Item
            {
                ItemId = "Dog Food",
                CategoryId = new List<string> { "Dog", "Food", "Testing CategoryId", "Healthy" }
            });
            fakeItems.Add(new Item
            {
                ItemId = "Bird Food",
                CategoryId = new List<string> { "Bird", "Food", "Testing CategoryId" }
            });

        }
        public Item SelectItemByItemId(string ItemId)
        {
            Item itemReturn = null;
            foreach (Item fakeItem in fakeItems)
            {
                if (fakeItem.ItemId == ItemId)
                {
                    itemReturn = fakeItem;
                    break;
                }
            }
            return itemReturn;
        }
    }
}
