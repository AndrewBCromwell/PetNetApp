using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayer;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;

namespace LogicLayer
{
    public class FundraisingEventManager : IFundraisingEventManager
    {
        private IFundraisingEventAccessor _fundraisingEventAccessor = null;
        private IInstitutionalEntityAccessor _institutionalEntityAccessor = new InstitutionalEntityAccessor();
        private IAnimalAccessor _animalAccessor = new AnimalAccessor();

        public FundraisingEventManager()
        {
            _fundraisingEventAccessor = new FundraisingEventAccessor();
        }

        public FundraisingEventManager(IFundraisingEventAccessor fundraisingEventAccessor)
        {
            _fundraisingEventAccessor = fundraisingEventAccessor;
        }

        public bool AddFundraiserAnimal(int fundRaisingEventId, int animalId)
        {
            bool isSuccess = false;

            try
            {
                if (_fundraisingEventAccessor.InsertFundraiserAnimal(fundRaisingEventId, animalId) == 1)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                new ApplicationException("Failed to add new fundraiser animal", ex);
            }

            return isSuccess;
        }

        public int AddFundraisingEvent(FundraisingEvent fundraisingEvent)
        {
            int id = 0;

            try
            {
                id = _fundraisingEventAccessor.InsertFundraisingEvent(fundraisingEvent);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to add new fundraising event.", ex);
            }

            return id;
        }

        public bool AddFundraisingEventEntity(int eventId, int contactId)
        {
            bool isSuccess = false;

            try
            {
                if (_fundraisingEventAccessor.InsertFundraisingEventEntity(eventId, contactId) == 1)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                new ApplicationException("Failed to add new fundraising event entity", ex);
            }

            return isSuccess;
        }

        public bool DeactivateFundraisingEvent(int eventId)
        {
            bool isSuccess = false;

            try
            {
                isSuccess = _fundraisingEventAccessor.DeactivateFundraisingEvent(eventId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to deactivate fundraising event", ex);
            }

            return isSuccess;
        }

        public FundraisingEvent FindFundraisingEvent(int eventId)
        {
            FundraisingEvent fundraisingEvent = null;

            try
            {
                fundraisingEvent = _fundraisingEventAccessor.SelectFundraisingEvent(eventId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Can not find fundraising event with this ID", ex);
            }

            return fundraisingEvent;
        }

        public List<Animal> RetrieveAnimalByEventId(int eventId, int shelterId)
        {
            List<Animal> animals = new List<Animal>();

            try
            {
                List<int> animalIdList = _fundraisingEventAccessor.SelectAnimalByFundraisingEvent(eventId);
                foreach (int animalId in animalIdList)
                {
                    animals.Add(_animalAccessor.SelectAnimalByAnimalId(animalId, shelterId));
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Can not get animal", ex);
            }

            return animals;
        }

        public List<InstitutionalEntity> RetrieveContactByEventId(int eventId)
        {
            List<InstitutionalEntity> contactList = new List<InstitutionalEntity>();

            try
            {
                List<int> contactListId = _fundraisingEventAccessor.SelectContactByFundraisingEvent(eventId);
                foreach (int institutionalEntityId in contactListId)
                {
                    try
                    {
                        InstitutionalEntity institutionalEntity = _institutionalEntityAccessor.SelectInstitutionalEntityByInstitutionalEntityId(institutionalEntityId);
                        if (institutionalEntity!=null)
                        {
                            contactList.Add(institutionalEntity);
                        }
                    }
                    catch
                    {
                    }
                    
                    
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Can not get the data", ex);
            }

            return contactList;
        }

        public List<InstitutionalEntity> RetrieveSponsorByEventId(int eventId)
        {
            List<InstitutionalEntity> sponsorList = new List<InstitutionalEntity>();

            try
            {
                List<int> sponsorIdList = _fundraisingEventAccessor.SelectSponsorByFundraisingEvent(eventId);
                foreach (int institutionalEntityId in sponsorIdList)
                {
                    try
                    {
                        InstitutionalEntity institutionalEntity = _institutionalEntityAccessor.SelectInstitutionalEntityByInstitutionalEntityId(institutionalEntityId);
                        if (institutionalEntity != null)
                        {
                            sponsorList.Add(institutionalEntity);
                        }
                    }
                    catch
                    {
                    }


                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Can not get the data", ex);
            }

            return sponsorList;
        }

        public bool UpdateFundraisingEvent(FundraisingEventVM fundraisingEvent)
        {
            bool isSuccess = false;

            try
            {
                if (_fundraisingEventAccessor.UpdateFundraisingEvent(fundraisingEvent) != 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Can not update data", ex);
            }

            return isSuccess;
        }
    }
}
