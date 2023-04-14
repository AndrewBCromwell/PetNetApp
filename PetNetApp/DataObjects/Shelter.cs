using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataObjects
{
    /// <summary>
    /// Brian Collum
    /// Created: 2023/02/23
    /// Shelter object and ShelterVM to contain required shelter data and extended shelter information
    /// </summary>
    public class Shelter
    {
        // Data Object by Brian Collum
        // This represents all the fields in the Shelter table
        public int ShelterId { get; set; }
        [Display(Name = "Shelter")]
        public string ShelterName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; } // This is stored in the DB as an nvarchar, so leaving it as a string here
        public string Phone { get; set; }   // This is stored in the DB as an nvarchar, so leaving it as a string here
        public string Email { get; set; }
        public string AreasOfNeed { get; set; }
        public bool ShelterActive { get; set; }
        // Mission Statement is not in the DB at the moment
        // public string MissionStatement { get; set; }
        // Shelter hours of operation
        // DO THIS LATER
    }
    public class ShelterVM : Shelter    // This will extend Shelter with Hours of Operation
    {
        // Shelter hours of operation

        // If you're confused, the hours of operation within here is a part of the ShelterVM object, while the other instance is it's own class containing the opening and closing hours of the shelter.
        public List<HoursOfOperation> HoursOfOperation { get; set; }
    }
    // The way this is set up in the database means that this can only allow times for one day so it must be made into it's own object.
    public class HoursOfOperation
    {
        public TimeSpan OpenHour { get; set; }
        public TimeSpan CloseHour { get; set; }
    }
}
