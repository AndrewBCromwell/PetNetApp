using DataAccessLayerInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerFakes
{
    public class FundraisingCampaignAccessorFakes : IFundraisingCampaignAccessor
    {
        private Random rand = new Random();
        private List<FundraisingCampaignVM> addedFundraisingCampaigns = null;
        public FundraisingCampaignAccessorFakes()
        {
            addedFundraisingCampaigns = new List<FundraisingCampaignVM>()
            {
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Consistent Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = 110000, Description="Garble", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100002,Title="Consistent Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = 110001, Description="Garble Goop", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Consistent Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = 110002, Description="Awesome sauce", Complete=false}
            };
        }

        public int InsertFundraisingCampaign(FundraisingCampaignVM fundraisingCampaign)
        {
            int previousCount = addedFundraisingCampaigns.Count;
            addedFundraisingCampaigns.Add(fundraisingCampaign);
            return addedFundraisingCampaigns.Count - previousCount + fundraisingCampaign.Sponsors.Count;
        }

        public List<FundraisingCampaignVM> SelectAllFundraisingCampaignsByShelterId(int shelterId)
        {
            int fundraisingCampaignId = 100000;
            List<FundraisingCampaignVM> fakeFundraisingCampaigns = new List<FundraisingCampaignVM>()
            {
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100003,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100003,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100003,Title="Fundraising Event " + rand.Next(100),StartDate=null, FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Grearble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Grearble", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Grearble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Wreow", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Wreow", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100003,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Wow", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Wow", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Wow", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Wow", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Wow", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100003,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100003,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100003,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaignVM(){ Sponsors = new List<Sponsor>(), ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false}
            };
            //for (int i = 0; i < 3000; i++)
            //{
            //    fakeFundraisingCampaigns.Add(new FundraisingCampaignVM() { ShelterId = 100000, Title = "Fundraising Event " + i, StartDate = DateTime.Now, FundraisingCampaignId = fundraisingCampaignId++, Description = "Boop", Complete = false });
            //}
            return addedFundraisingCampaigns.Concat(fakeFundraisingCampaigns).Where(fundraisingCampaing => fundraisingCampaing.ShelterId == shelterId).ToList();
        }

        public int UpdateFundraisingCampaign(FundraisingCampaignVM oldFundraisingCampaignVM, FundraisingCampaignVM newFundraisingCampaignVM)
        {
            var editing = addedFundraisingCampaigns.Find(campaign => campaign.FundraisingCampaignId == oldFundraisingCampaignVM.FundraisingCampaignId);
            if (oldFundraisingCampaignVM.Title != editing.Title || oldFundraisingCampaignVM.Description != editing.Description || oldFundraisingCampaignVM.EndDate != editing.EndDate || oldFundraisingCampaignVM.StartDate != editing.StartDate)
            {
                return 0;
            }
            else
            {
                addedFundraisingCampaigns.Remove(editing);
                addedFundraisingCampaigns.Add(newFundraisingCampaignVM);
                return 1 + newFundraisingCampaignVM.Sponsors.Count;
            }
        }
    }
}
