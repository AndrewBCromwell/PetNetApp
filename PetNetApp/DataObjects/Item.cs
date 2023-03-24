/// <summary>
/// Zaid Rachman
/// Created: 2023/03/19
/// 
/// Items object
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

namespace DataObjects
{
    /*This object is for inventory related items*/
    public class Item
    {
        public string ItemId { get; set; }
        public List<string> CategoryId { get; set; }
    }
}
