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
        private List<FundraisingCampaign> fakeFundraisingCampaigns = null;
        public FundraisingCampaignAccessorFakes()
        {
            
        }
        public List<FundraisingCampaign> SelectAllFundraisingCampaignsByShelterId(int shelterId)
        {
            int fundraisingCampaignId = 100000;
            fakeFundraisingCampaigns = new List<FundraisingCampaign>()
            {
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100003,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100003,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100003,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Goop", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Grearble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Grearble", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Grearble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Wreow", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Wreow", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100003,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Wow", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Wow", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Wow", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Wow", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Wow", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100003,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100003,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100002,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100003,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false},
                new FundraisingCampaign(){ ShelterId = 100001,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=true},
                new FundraisingCampaign(){ ShelterId = 100000,Title="Fundraising Event " + rand.Next(100),StartDate=DateTime.Today + TimeSpan.FromDays(rand.Next(10)), FundraisingCampaignId = fundraisingCampaignId++, Description="Garble", Complete=false}
            };
            for (int i = 0; i < rand.Next(1000); i++)
            {
                fakeFundraisingCampaigns.Add(new FundraisingCampaign() { ShelterId = 100000, Title = "Fundraising Event " + i, StartDate = DateTime.Now, FundraisingCampaignId = fundraisingCampaignId++, Description = "Boop", Complete = false });
            }
            return fakeFundraisingCampaigns.Where(fundraisingCampaing => fundraisingCampaing.ShelterId == shelterId).ToList();
        }
    }
}
