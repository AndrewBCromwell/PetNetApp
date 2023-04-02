using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IFundraisingEventAccessor
    {
        int InsertFundraisingEvent(FundraisingEvent fundraisingEvent);
        int InsertFundraiserAnimal(int fundraisingEventId, int animalId);
        int InsertFundraisingEventEntity(int eventId, int contactId);
        FundraisingEvent SelectFundraisingEvent(int eventId);
        List<int> SelectContactByFundraisingEvent(int eventId);
        List<int> SelectSponsorByFundraisingEvent(int eventId);
        List<int> SelectAnimalByFundraisingEvent(int eventId);
        int UpdateFundraisingEvent(FundraisingEventVM fundraisingEvent);
        int DeactivateFundraisingEvent(int fundraisingEventId);
    }
}
