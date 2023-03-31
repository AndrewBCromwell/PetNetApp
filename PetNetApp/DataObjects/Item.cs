/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// Items object
/// </summary>
///
/// <remarks>
/// Brian Collum
/// Updated: 2023/03/24
/// 
/// Updated Item's default getter to always initialize the list of tags
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /*This object is for inventory related items*/
    public class Item
    {
        public string ItemId { get; set; }  // This is the name of the item, also item.itemid in the DB. NVarchar(50)
        public List<string> CategoryId  // This is a list of Categories, or tags
        {   // Custom getter to make sure that the list of tags is initialized on object creation. Otherwise the CategoryID List itself can be null, which can lead to nullPointerExceptions
            get
            {
                if (_tags == null)
                {
                    _tags = new List<string>();
                }
                return _tags;
            }
            set { _tags = value; }
        }
        private List<string> _tags; // This is a list of tags built from itemcategory.itemid in the DB. NVarchar(50) This is used in object initialization
    }
}
