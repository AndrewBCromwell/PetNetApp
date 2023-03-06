using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayer;
using DataAccessLayerInterfaces;
using LogicLayerInterfaces;

namespace LogicLayer
{
    public class ShelterItemTransactionManager : IShelterItemTransactionManager
    {
        private IShelterItemTransactionAccessor _shelterItemTransactionAccessor;

        public ShelterItemTransactionManager()
        {
            _shelterItemTransactionAccessor = new ShelterItemTransactionAccessor();
        }

        public ShelterItemTransactionManager(IShelterItemTransactionAccessor shelterItemTransactionAccessor)
        {
            _shelterItemTransactionAccessor = shelterItemTransactionAccessor;
        }

        public List<ShelterItemTransactionVM> RetrieveInventoryTransactionByShelterId(int shelterId)
        {
            List<ShelterItemTransactionVM> shelterItemTransactions;
            try
            {
                shelterItemTransactions = _shelterItemTransactionAccessor.SelcetShelterItemTransactionByShelterId(shelterId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Shelter Item Transaction records could not be retrieved.", ex);
            }
            return shelterItemTransactions;
        }
    }
}
