using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    /// <summary>
    /// Stephen Jaurigue
    /// Created: 2023/02/23
    /// 
    /// The data access layer fake class used for testing purposes while developing institutional entity features and for the logic tests
    /// </summary>
    public class InstitutionalEntityAccessorFake : IInstitutionalEntityAccessor
    {
        private List<InstitutionalEntity> _institutionalEntities = FundraisingFakeData.InstitutionalEntities;
        private List<Tuple<int, int>> _fundraisingCampaignEntities = FundraisingFakeData.FundraisingCampaignEntities;

        public InstitutionalEntityAccessorFake()
        {
            // Contact Type Overview
            // 14-17 arent Sponsor
            // 14,17 are Host
            // 15,16 are Contact

        }
        public List<InstitutionalEntity> SelectFundraisingSponsorsByCampaignId(int fundraisingCampaignId)
        {
            // piece by piece lambda version
            //var entityIdsForCampaign = fundraisingCampaignEntity.Where((join) => join.Item1 == fundraisingCampaignId);
            //var matchingEntitiesFromIds = entityIdsForCampaign.Select((id) => institutionalEntity.First((entity) => entity.InstitutionalEntityId == id.Item2));
            //var matchingEntitiesThatAreSponsors = matchingEntitiesFromIds.Where((entity) => entity.ContactType == "Sponsor");
            //return matchingEntitiesThatAreSponsors.ToList();

            // join lambda version
            //var matchingEntitiesFromIdsJoin = institutionalEntity.Where((entity) => entity.ContactType == "Sponsor").Join(fundraisingCampaignEntity.Where((join) => join.Item1 == fundraisingCampaignId), (entity) => entity.InstitutionalEntityId, (join) => join.Item2, (entity, join) => entity);
            //return matchingEntitiesFromIdsJoin.ToList();

            // linq way
            var sponsors = from institutionalEntityRecord in _institutionalEntities
                           join fundraisingCampaignEntityRecord in _fundraisingCampaignEntities on institutionalEntityRecord.InstitutionalEntityId equals fundraisingCampaignEntityRecord.Item2
                           where fundraisingCampaignEntityRecord.Item1 == fundraisingCampaignId && institutionalEntityRecord.ContactType == "Sponsor"
                           select institutionalEntityRecord;
            return sponsors.ToList();
        }

        public List<InstitutionalEntity> SelectAllSponsors()
        {
            var sponsors = from institutionalEntityRecord in _institutionalEntities
                           where institutionalEntityRecord.ContactType == "Sponsor"
                           select institutionalEntityRecord;
            return sponsors.ToList();
        }

        public List<InstitutionalEntity> SelectAllInstitutionalEntitiesByShelterIdAndEntityType(int shelterId, string entityType)
        {
            throw new NotImplementedException();
        }

        public InstitutionalEntity SelectInstitutionalEntityByInstitutionalEntityId(int institutionalEntityId)
        {
            InstitutionalEntity institutionalEntity = new InstitutionalEntity();

            foreach (InstitutionalEntity fakeEntity in _institutionalEntities)
            {
                if (fakeEntity.InstitutionalEntityId == institutionalEntityId)
                {
                    institutionalEntity = fakeEntity;
                    return institutionalEntity;
                }
            }
            if (institutionalEntity == null)
            {
                throw new ApplicationException("Entity not found");
            }
            return institutionalEntity;
        }

        public int InsertInstitutionalEntity(InstitutionalEntity institutionalEntity)
        {
            _institutionalEntities.Add(institutionalEntity);
            int rows = 0;

            for (int i = 0; i < _institutionalEntities.Count; i++)
            {
                if (_institutionalEntities[i].InstitutionalEntityId == institutionalEntity.InstitutionalEntityId)
                {
                    rows = 1;
                }
            }
            return rows;
        }

        public int UpdateInstitutionalEntity(InstitutionalEntity oldEntity, InstitutionalEntity newEntity)
        {
            int result = 0;

            for (int i = 0; i < _institutionalEntities.Count; i++)
            {
                if (_institutionalEntities[i].InstitutionalEntityId == oldEntity.InstitutionalEntityId)
                {
                    // the real database will check for every editable field in the stored procedure
                    _institutionalEntities[i].Address = _institutionalEntities[i].Address == oldEntity.Address
                        ? _institutionalEntities[i].Address = newEntity.Address : oldEntity.Address;

                    result++;
                    break;
                }
            }

            return result;
        }
    }
}
