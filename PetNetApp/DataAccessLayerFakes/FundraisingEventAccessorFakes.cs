using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;

namespace DataAccessLayerFakes
{
    public class FundraisingEventAccessorFakes : IFundraisingEventAccessor
    {
        private Random rand = new Random();
        private List<FundraisingEventVM> fakeFundraisingEvents = null;
        private List<FundraisingEventVM> _fundraisingEvents = FundraisingFakeData.FundraisingEvents;

        public FundraisingEventAccessorFakes()
        {

        }

        public List<FundraisingEventVM> SelectAllFundraisingEventsByShelterId(int shelterId)
        {
            //throw new NotImplementedException();
            int fundraisingEventId = 100000;
            string[] etList = { "Dogs", "Cats", "Frogs", "Snakes", "Turtles" };
            fakeFundraisingEvents = new List<FundraisingEventVM>()
            {
                new FundraisingEventVM(){ FundraisingEventId = fundraisingEventId++, UsersId = 100000, CampaignId = 100000, ShelterId = 100006, ImageId = 0,  Complete=false, Hidden=false, Title="Fundraising Event for " + etList[rand.Next(0, etList.Length)] + rand.Next(100),StartTime=DateTime.Today + TimeSpan.FromDays(4), EndTime = DateTime.Today + TimeSpan.FromDays(4) + TimeSpan.FromHours(4) , Description="Garble", AdditionalInfo="Things to know", Cost = 100.00M, NumOfAttendees = 65, NumAnimalsAdopted = 4, UpdateNotes = ""},
                new FundraisingEventVM(){ FundraisingEventId = fundraisingEventId++, UsersId = 100000, CampaignId = 100000, ShelterId = 100006, ImageId = 0,  Complete=false, Hidden=false, Title="Fundraising Event for " + etList[rand.Next(0, etList.Length)] + rand.Next(100),StartTime=DateTime.Today + TimeSpan.FromDays(4), EndTime = DateTime.Today + TimeSpan.FromDays(4) + TimeSpan.FromHours(4) , Description="Garble", AdditionalInfo="Things to know", Cost = 0.00M, NumOfAttendees = rand.Next(100), NumAnimalsAdopted = rand.Next(20), UpdateNotes = ""},
                new FundraisingEventVM(){ FundraisingEventId = fundraisingEventId++, UsersId = 100000, CampaignId = 100000, ShelterId = 100006, ImageId = 0,  Complete=false, Hidden=false, Title="Fundraising Event for " + etList[rand.Next(0, etList.Length)] + rand.Next(100),StartTime=DateTime.Today + TimeSpan.FromDays(4), EndTime = DateTime.Today + TimeSpan.FromDays(4) + TimeSpan.FromHours(4) , Description="Garble", AdditionalInfo="Things to know", Cost = 0.00M, NumOfAttendees = rand.Next(100), NumAnimalsAdopted = rand.Next(20), UpdateNotes = ""},
                new FundraisingEventVM(){ FundraisingEventId = fundraisingEventId++, UsersId = 100000, CampaignId = 100000, ShelterId = 100006, ImageId = 0,  Complete=false, Hidden=false, Title="Fundraising Event for " + etList[rand.Next(0, etList.Length)] + rand.Next(100),StartTime=DateTime.Today + TimeSpan.FromDays(4), EndTime = DateTime.Today + TimeSpan.FromDays(4) + TimeSpan.FromHours(4) , Description="Garble", AdditionalInfo="Things to know", Cost = 0.00M, NumOfAttendees = rand.Next(100), NumAnimalsAdopted = rand.Next(20), UpdateNotes = ""},
                new FundraisingEventVM(){ FundraisingEventId = fundraisingEventId++, UsersId = 100000, CampaignId = 100000, ShelterId = 100006, ImageId = 0,  Complete=false, Hidden=false, Title="Fundraising Event for " + etList[rand.Next(0, etList.Length)] + rand.Next(100),StartTime=DateTime.Today + TimeSpan.FromDays(4), EndTime = DateTime.Today + TimeSpan.FromDays(4) + TimeSpan.FromHours(4) , Description="Garble", AdditionalInfo="Things to know", Cost = 0.00M, NumOfAttendees = rand.Next(100), NumAnimalsAdopted = rand.Next(20), UpdateNotes = ""},
                new FundraisingEventVM(){ FundraisingEventId = fundraisingEventId++, UsersId = 100000, CampaignId = 100000, ShelterId = 100006, ImageId = 0,  Complete=false, Hidden=false, Title="Fundraising Event for " + etList[rand.Next(0, etList.Length)] + rand.Next(100),StartTime=DateTime.Today + TimeSpan.FromDays(4), EndTime = DateTime.Today + TimeSpan.FromDays(4) + TimeSpan.FromHours(4) , Description="Garble", AdditionalInfo="Things to know", Cost = 0.00M, NumOfAttendees = rand.Next(100), NumAnimalsAdopted = rand.Next(20), UpdateNotes = ""}
            };

            for (int i = 0; i < 3000; i++)
            {
                int days = rand.Next(10);
                int siRand = rand.Next(4);
                fakeFundraisingEvents.Add(new FundraisingEventVM()
                {
                    FundraisingEventId = fundraisingEventId++,
                    UsersId = 100000,
                    CampaignId = 100000,
                    ShelterId = 100000 + siRand,
                    ImageId = 0,
                    Complete = false,
                    Hidden = false,
                    Title = "Fundraising Event for " + etList[rand.Next(0, etList.Length)] + rand.Next(100),
                    StartTime = DateTime.Today + TimeSpan.FromDays(days),
                    EndTime = DateTime.Today + TimeSpan.FromDays(days) + TimeSpan.FromHours(4),
                    Description = "Garble",
                    AdditionalInfo = "Things to know",
                    Cost = (decimal)rand.NextDouble() * rand.Next(2000),
                    NumOfAttendees = rand.Next(100),
                    NumAnimalsAdopted = rand.Next(20),
                    UpdateNotes = "Nothing to report"
                });
            }

            return fakeFundraisingEvents.Where(fe => fe.ShelterId == shelterId).ToList();
        }

        public FundraisingEventVM SelectFundraisingEventByFundraisingEventId(int fundraisingEventId)
        {
            return _fundraisingEvents.First(fundraisingEvent => fundraisingEvent.FundraisingEventId == fundraisingEventId);
        }

        public int UpdateFundraisingEventResults(FundraisingEventVM oldFundraisingEventVM, FundraisingEventVM newFundraisingEventVM)
        {
            // throw new NotImplementedException();
            int recordsChanged = 0;
            var testEvent = _fundraisingEvents.Find(fundraisingEvent => fundraisingEvent.FundraisingEventId == oldFundraisingEventVM.FundraisingEventId);
            //simulate check for concurrency
            if (oldFundraisingEventVM.Cost != testEvent.Cost || oldFundraisingEventVM.NumOfAttendees != testEvent.NumOfAttendees || oldFundraisingEventVM.NumAnimalsAdopted != testEvent.NumAnimalsAdopted || oldFundraisingEventVM.UpdateNotes != testEvent.UpdateNotes)
            {
                return 0;
            }
            else
            {
                //remove exisiting fundraising event with id that matches old event
                _fundraisingEvents.Remove(testEvent);
                //add the updated event in
                _fundraisingEvents.Add(newFundraisingEventVM);
                recordsChanged++;
                return recordsChanged;

            }
        }
    }
}
