using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class FundraisingCampaign
    {
        public int FundraisingCampaignId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public bool Complete { get; set; }
        public int UsersId { get; set; }
        public int ShelterId { get; set; }
    }

    public class FundraisingCampaignVM : FundraisingCampaign
    {
        //public List<CampaignUpdate> CampaignUpdates { get; set; }
        //public List<FundraisingEvent> FundraisingEventList { get; set; }
    }
}
