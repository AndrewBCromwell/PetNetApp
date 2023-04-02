using DataObjects;
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
        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/05
        /// 
        /// A method to get the fundraising events for this shelter
        /// </summary>
        /// 
        /// <param name="shelterId">The shelter Id of the logged in user to retrieve all the events for</param>
        /// <exception cref="SQLException">Load Fails</exception>
        /// <returns>List<FundraisingEvent></FundraisingEvent></returns>
        List<FundraisingEventVM> RetrieveAllFundraisingEventsByShelterId(int shelterId);
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
