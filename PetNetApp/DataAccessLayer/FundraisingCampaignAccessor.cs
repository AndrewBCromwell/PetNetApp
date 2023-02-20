using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayer
{
    public class FundraisingCampaignAccessor : IFundraisingCampaignAccessor
    {
        public List<FundraisingCampaign> SelectAllFundraisingCampaignsByShelterId(int shelterId)
        {
            throw new NotImplementedException();
        }
    }
}
