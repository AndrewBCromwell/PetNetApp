using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataObjects
{
    public class FundraisingEvent
    {
        public int FundraisingEventId { get; set; }
        public int UserId { get; set; }
        public int? CampaignId { get; set; }
        public int ShelterId { get; set; }
        public string ImageId { get; set; }
        public bool Hidden { get; set; }
        public string Title { get; set; }
        public bool Complete { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string AdditionalInfo { get; set; }
        public decimal? Cost { get; set; }
        public int? NumOfAttendees { get; set; }
        public int? NumAnimalAdopted { get; set; }
        public string UpdateNotes { get; set; }

    }

    public class FundraisingEventVM : FundraisingEvent
    {
        public List<InstitutionalEntity> Contacts { get; set; }
        public List<InstitutionalEntity> Sponsors { get; set; }
        public InstitutionalEntity Host { get; set; }
        public FundraisingCampaignVM Campaign { get; set; }
        public List<AnimalVM> Animals { get; set; }
    }
}
