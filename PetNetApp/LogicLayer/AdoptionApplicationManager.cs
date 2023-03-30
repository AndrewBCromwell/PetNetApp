using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayerInterfaces;
using DataObjects;
using DataAccessLayerInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    public class AdoptionApplicationManager : IAdoptionApplicationManager
    {
        private IAdoptionApplicationAccessor _adoptionApplicationAccessor = null;

        public AdoptionApplicationManager()
        {
            _adoptionApplicationAccessor = new AdoptionApplicationAccessor();
        }

        public AdoptionApplicationManager(IAdoptionApplicationAccessor adoptionApplicationAccessor)
        {
            _adoptionApplicationAccessor = adoptionApplicationAccessor;
        }

        public bool AddAdoptionApplication(AdoptionApplicationVM adoptionApplication)
        {
            bool success = false;
            try
            {
                if (1 == _adoptionApplicationAccessor.InsertAdoptionApplication(adoptionApplication))
                {
                    success = true;
                }
            }
            catch (Exception up)
            {
                throw new ApplicationException("Adoption application failed to add", up);
            }
            return success;
        }

        public List<string> RetrieveAllHomeOwnershipTypes()
        {
            List<string> types = null;
            try
            {
                types = _adoptionApplicationAccessor.SelectAllHomeOwnershipTypes();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Failed to retrieve home ownership types", e);
            }
            return types;
        }

        public List<string> RetrieveAllHomeTypes()
        {
            List<string> types = null;
            try
            {
                types = _adoptionApplicationAccessor.SelectAllHomeTypes();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Failed to retrieve home types", e);
            }
            return types;
        }
    }
}
