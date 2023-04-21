using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    public class AdoptionApplicationResponseManager : IAdoptionApplicationResponseManager
    {
        private IAdoptionApplicationResponseAccessor _adoptionApplicationResponseAccessor = null;

        public AdoptionApplicationResponseManager()
        {
            _adoptionApplicationResponseAccessor = new AdoptionApplicationResponseAccessor();
        }

        public AdoptionApplicationResponseManager(IAdoptionApplicationResponseAccessor adoptionApplicationResponseAccessor)
        {
            _adoptionApplicationResponseAccessor = adoptionApplicationResponseAccessor;
        }
        public bool AddAdoptionApplicationResponseByAdoptionApplicationId(AdoptionApplicationResponseVM adoptionApplicationResponseVM)
        {
            bool result = false;

            try
            {
                result = 1 == _adoptionApplicationResponseAccessor.InsertAdoptionApplicationResponseByAdoptionApplicationId(adoptionApplicationResponseVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
