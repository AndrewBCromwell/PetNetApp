using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;

namespace DataAccessLayerFakes
{
    public class FundraisingEventFakes : IFundraisingEventAccessor
    {
        private List<FundraisingEvent> fundraisingEventsFake = new List<FundraisingEvent>();
        private List<Tuple<int, int>> fundraiserAnimal = new List<Tuple<int, int>>();
        private List<Tuple<int, int>> fundraisingEventEntity = new List<Tuple<int, int>>();

        public FundraisingEventFakes()
        {
            fundraisingEventsFake.Add(new FundraisingEventVM()
            {
                FundraisingEventId = 100000,
                Title = "Test 1",
                UserId = 100000,
                Description = "This is a test"
            });
            fundraisingEventsFake.Add(new FundraisingEventVM()
            {
                FundraisingEventId = 100001,
                Title = "Test 2",
                UserId = 100000,
                Description = "This is a test"
            });
            fundraisingEventsFake.Add(new FundraisingEventVM()
            {
                FundraisingEventId = 100003,
                Title = "Test 3",
                UserId = 100000,
                Description = "This is a test"
            });

            InsertFundraiserAnimal(100000, 100000);
            InsertFundraiserAnimal(100000, 100001);
            InsertFundraiserAnimal(100001, 100003);
            InsertFundraiserAnimal(100002, 100004);

            InsertFundraisingEventEntity(100000, 100000);
            InsertFundraisingEventEntity(100000, 100001);
            InsertFundraisingEventEntity(100000, 100002);
            InsertFundraisingEventEntity(100001, 100003);
            InsertFundraisingEventEntity(100002, 100004);
            InsertFundraisingEventEntity(100002, 100005);
        }

        public int DeactivateFundraisingEvent(int fundraisingEventId)
        {
            int rowAffected = 0;
            foreach (FundraisingEvent fundraisingEvent in fundraisingEventsFake)
            {
                if (fundraisingEvent.FundraisingEventId == fundraisingEventId)
                {
                    fundraisingEvent.Hidden = true;
                    rowAffected = 1;
                }
            }
            return rowAffected;
        }

        public int InsertFundraiserAnimal(int fundraisingEventId, int animalId)
        {
            int rowAffected = 0;

            try
            {
                fundraiserAnimal.Add(new Tuple<int, int>(fundraisingEventId, animalId));
                rowAffected = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowAffected;
        }

        public int InsertFundraisingEvent(FundraisingEvent fundraisingEvent)
        {
            int rowAffected = 0;
            try
            {
                fundraisingEventsFake.Add(fundraisingEvent);
                rowAffected = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rowAffected;
        }

        public int InsertFundraisingEventEntity(int eventId, int contactId)
        {
            int rowAffected = 0;

            try
            {
                fundraisingEventEntity.Add(new Tuple<int, int>(eventId, contactId));
                rowAffected = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowAffected;
        }

        public List<int> SelectAnimalByFundraisingEvent(int eventId)
        {
            List<int> animalIdList = new List<int>();

            foreach (var animal in fundraiserAnimal)
            {
                if (animal.Item1 == eventId)
                {
                    animalIdList.Add(animal.Item2);
                }
            }

            return animalIdList;
        }

        public List<int> SelectContactByFundraisingEvent(int eventId)
        {
            List<int> contactIdList = new List<int>();

            foreach (var contact in fundraisingEventEntity)
            {
                if (contact.Item1 == eventId)
                {
                    contactIdList.Add(contact.Item2);
                }
            }

            return contactIdList;
        }

        public FundraisingEvent SelectFundraisingEvent(int eventId)
        {
            FundraisingEvent result = new FundraisingEvent();
            foreach (FundraisingEvent fundraisingEvent in fundraisingEventsFake)
            {
                if (fundraisingEvent.FundraisingEventId == eventId)
                {
                    result = fundraisingEvent;
                }
            }
            return result;
        }

        public List<int> SelectSponsorByFundraisingEvent(int eventId)
        {
            List<int> sponsorIdList = new List<int>();

            foreach (var contact in fundraisingEventEntity)
            {
                if (contact.Item1 == eventId)
                {
                    sponsorIdList.Add(contact.Item2);
                }
            }

            return sponsorIdList;
        }

        public int UpdateFundraisingEvent(FundraisingEventVM fundraisingEvent)
        {
            int rowAffected = 0;
            foreach (FundraisingEvent fEvent in fundraisingEventsFake)
            {
                if (fEvent.FundraisingEventId == fundraisingEvent.FundraisingEventId)
                {
                    fEvent.UserId = fundraisingEvent.UserId;
                    fEvent.CampaignId = fundraisingEvent.CampaignId == null ? null : fundraisingEvent.CampaignId;
                    fEvent.ShelterId = fundraisingEvent.ShelterId;
                    fEvent.ImageId = fundraisingEvent.ImageId;
                    fEvent.Hidden = fundraisingEvent.Hidden;
                    fEvent.Title = fundraisingEvent.Title;
                    fEvent.StartTime = fundraisingEvent.StartTime;
                    fEvent.EndTime = fundraisingEvent.EndTime;
                    fEvent.Description = fundraisingEvent.Description;
                    fEvent.NumOfAttendees = fundraisingEvent.NumOfAttendees;
                    fEvent.AdditionalInfo = fundraisingEvent.AdditionalInfo;
                }
            }
            return rowAffected;
        }
    }
}
