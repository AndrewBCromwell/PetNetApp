using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class AdoptionApplicationResponse
    {
        public int AdoptionApplicationResponseId { get; set; }
        public int AdoptionApplicationId { get; set; }
        public int ResponderUserId { get; set; }
        public bool Approved { get; set; }
        public DateTime AdoptionApplicationResponseDate { get; set; }
        public string AdoptionApplicationResponseNotes { get; set; }
    }

    public class AdoptionApplicationResponseVM : AdoptionApplication
    {
        public AdoptionApplication Application { get; set; }
        public Users Responder { get; set; }
    }
}
