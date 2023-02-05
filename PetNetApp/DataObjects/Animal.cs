using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Animal
    {
		public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string AnimalGender { get; set; }
        public string AnimalTypeId { get; set; }
        public string AnimalBreedId { get; set; }
        public string Personality { get; set; }
        public string Description { get; set; }
        public string AnimalStatusId { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string MicrochipSerialNumber { get; set; }
        public bool Aggressive { get; set; }
        public string AggressionDescription { get; set; }
        public bool ChildFriendly { get; set; }
        public bool NeuterStatus { get; set; }
        public string Notes { get; set; }
    }

    public class AnimalVM : Animal
    {
        public string AnimalStatusDescription { get; set; }
        public string KennelName { get; set; }
        // public List<MedicalRecord> MedicalNotes { get; set; }
        // public DeathVM AnimalDeath { get; set; }
    }

}
