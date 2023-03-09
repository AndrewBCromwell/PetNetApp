using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayer;
using DataAccessLayerInterfaces;

namespace LogicLayer
{

    /// <summary>
    /// Stephen Jaurigue
    /// Created: 2023/02/23
    /// 
    /// The Logic Layer class for managing institutional entities
    /// </summary>
    public class InstitutionalEntityManager : IInstitutionalEntityManager
    {
        private IInstitutionalEntityAccessor _institutionalEntityAccessor = null;
        public InstitutionalEntityManager()
        {
            _institutionalEntityAccessor = new InstitutionalEntityAccessor();
        }
        public InstitutionalEntityManager(IInstitutionalEntityAccessor institutionalEntityAccessor)
        {
            _institutionalEntityAccessor = institutionalEntityAccessor;
        }

        public List<InstitutionalEntity> RetrieveAllSponsors()
        {
            List<InstitutionalEntity> sponsors = null;
            try
            {
                sponsors = _institutionalEntityAccessor.SelectAllSponsors();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load sponsors", ex);
            }
            return sponsors;
        }

        public List<InstitutionalEntity> RetrieveFundraisingSponsorsByCampaignId(int campaignId)
        {
            List<InstitutionalEntity> sponsors = null;
            try
            {
                sponsors = _institutionalEntityAccessor.SelectFundraisingSponsorsByCampaignId(campaignId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load sponsors", ex);
            }
            return sponsors;
        }
    }
}
