using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class AdoptionApplicationResponseAccessorFakes : IAdoptionApplicationResponseAccessor
    {
        private List<AdoptionApplicationResponseVM> fakeResponses = new List<AdoptionApplicationResponseVM>();
        public AdoptionApplicationResponseAccessorFakes()
        {
            fakeResponses.Add(new AdoptionApplicationResponseVM
            {
                AdoptionApplicationResponseId = 1,
                AdoptionApplicationId = 1,
                ResponderUserId = 100000,
                Approved = true,
                AdoptionApplicationResponseDate = DateTime.Now,
                AdoptionApplicationResponseNotes = "dog did a heckin like",
                Application = new AdoptionApplication(),
                Responder = new Users()
            });
        }

        public int InsertAdoptionApplicationResponseByAdoptionApplicationId(AdoptionApplicationResponseVM adoptionApplicationResponseVM)
        {
            fakeResponses.Add(adoptionApplicationResponseVM);
            int rows = 0;
            for (int i = 0; i < fakeResponses.Count; i++)
            {
                if (fakeResponses[i].AdoptionApplicationResponseId == adoptionApplicationResponseVM.AdoptionApplicationResponseId)
                {
                    rows = 1;
                }
            }
            return rows;
        }
    }
}
