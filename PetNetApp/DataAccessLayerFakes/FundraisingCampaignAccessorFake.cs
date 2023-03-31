using DataAccessLayerInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerFakes
{
    /// <summary>
    /// Stephen Jaurigue
    /// Created: 2023/02/23
    /// 
    /// The data access layer fake class used for testing purposes while developing fundraising campaign features and for the logic tests
    /// </summary>
    public class FundraisingCampaignAccessorFake : IFundraisingCampaignAccessor
    {
        private List<FundraisingCampaignVM> _fundraisingCampaigns = FundraisingFakeData.FundraisingCampaigns;
        private List<Tuple<int, int>> _fundraisingCampaignEntities = FundraisingFakeData.FundraisingCampaignEntities;
        public FundraisingCampaignAccessorFake()
        {
        }

        public int DeleteFundraisingCampaign(FundraisingCampaignVM fundraisingCampaign)
        {
            var currentCampaign = _fundraisingCampaigns.First((campaign) => campaign.FundraisingCampaignId == fundraisingCampaign.FundraisingCampaignId);
            
            if (currentCampaign != null)
            {
                // database action
                currentCampaign.Active = false;
                return 1;
            }
            return 0;
        }

        public int InsertFundraisingCampaign(FundraisingCampaignVM fundraisingCampaign)
        {
            int previousCount = _fundraisingCampaigns.Count;
            _fundraisingCampaigns.Add(fundraisingCampaign);
            foreach (var item in fundraisingCampaign.Sponsors)
            {
                _fundraisingCampaignEntities.Add(new Tuple<int, int>(fundraisingCampaign.FundraisingCampaignId, item.InstitutionalEntityId));
            }
            return _fundraisingCampaigns.Count - previousCount + fundraisingCampaign.Sponsors.Count;
        }

        public List<FundraisingCampaignVM> SelectAllActiveFundraisingCampaigns()
        {
            return _fundraisingCampaigns.Where(fundraisingCampaing => fundraisingCampaing.Active).ToList();
        }

        public List<FundraisingCampaignVM> SelectAllActiveFundraisingCampaignsByShelterId(int shelterId)
        {
            return _fundraisingCampaigns.Where(fundraisingCampaing => fundraisingCampaing.ShelterId == shelterId && fundraisingCampaing.Active).ToList();
        }

        public List<FundraisingCampaignVM> SelectAllFundraisingCampaignsByShelterId(int shelterId)
        {
            return _fundraisingCampaigns.Where(fundraisingCampaing => fundraisingCampaing.ShelterId == shelterId).ToList();
        }

        public FundraisingCampaignVM SelectFundraisingCampaignByFundraisingCampaignId(int fundraisingCampaignId)
        {
            return _fundraisingCampaigns.First((campaign) => campaign.FundraisingCampaignId == fundraisingCampaignId);
        }

        public int UpdateFundraisingCampaignDetails(FundraisingCampaignVM oldFundraisingCampaignVM, FundraisingCampaignVM newFundraisingCampaignVM)
        {
            int recordsChanged = 0;
            var editing = _fundraisingCampaigns.Find(campaign => campaign.FundraisingCampaignId == oldFundraisingCampaignVM.FundraisingCampaignId);
            if (oldFundraisingCampaignVM.Title != editing.Title || oldFundraisingCampaignVM.Description != editing.Description || oldFundraisingCampaignVM.EndDate != editing.EndDate || oldFundraisingCampaignVM.StartDate != editing.StartDate)
            {
                return 0;
            }
            else
            {
                var fundraisingCampaignEntitiesToAdd = newFundraisingCampaignVM.Sponsors.Where(newEntity => !oldFundraisingCampaignVM.Sponsors.Exists(oldEntity => oldEntity.InstitutionalEntityId == newEntity.InstitutionalEntityId));
                var fundraisingCampaignEntitiesToRemove = oldFundraisingCampaignVM.Sponsors.Where(oldEntity => !newFundraisingCampaignVM.Sponsors.Exists(newEntity => newEntity.InstitutionalEntityId == oldEntity.InstitutionalEntityId));
                foreach (var item in fundraisingCampaignEntitiesToRemove)
                {
                    _fundraisingCampaignEntities.Remove(_fundraisingCampaignEntities.First(join => join.Item2 == item.InstitutionalEntityId && join.Item1 == oldFundraisingCampaignVM.FundraisingCampaignId));
                    recordsChanged++;
                }
                foreach (var item in fundraisingCampaignEntitiesToAdd)
                {
                    _fundraisingCampaignEntities.Add(new Tuple<int, int>(oldFundraisingCampaignVM.FundraisingCampaignId, item.InstitutionalEntityId));
                    recordsChanged++;
                }

                _fundraisingCampaigns.Remove(editing);
                _fundraisingCampaigns.Add(newFundraisingCampaignVM);
                recordsChanged++;
                return recordsChanged;
            }
        }
    }
}
