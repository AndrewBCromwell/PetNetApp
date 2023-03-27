/// <summary>
/// Oleksiy Fedchuk
/// Created: 2023/02/24
/// 
/// 
/// Class for the creation of User Objects with set data fields
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
    public class Volunteer
    {
        public int FundraisingEventId { get; set; }
        public int UsersId { get; set; }
    }

    public class VolunteerVM : Volunteer
    {
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
    }
}
