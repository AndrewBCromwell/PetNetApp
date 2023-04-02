using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IFundraisingEventManager
    {
        int AddFundraisingEvent(FundraisingEvent fundraisingEvent);
        bool AddFundraiserAnimal(int fundRaisingEventId, int animalId);
        bool AddFundraisingEventEntity(int eventId, int contactId);
        FundraisingEvent FindFundraisingEvent(int eventId);
        List<InstitutionalEntity> RetrieveSponsorByEventId(int eventId);
        List<InstitutionalEntity> RetrieveContactByEventId(int eventId);
        List<Animal> RetrieveAnimalByEventId(int eventId, int shelterId);
        bool UpdateFundraisingEvent(FundraisingEventVM fundraisingEvent);
        bool DeactivateFundraisingEvent(int eventId);
    }
}
