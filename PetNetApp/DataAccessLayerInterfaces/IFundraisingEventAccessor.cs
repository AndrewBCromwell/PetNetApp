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
        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/05
        /// 
        /// A method to get the fundraising events for the logged in user's shelter id
        /// </summary>
        /// 
        /// <param name="shelterId">ShelterId to select all the Fundraising Events for</param>
        /// <exception cref="SQLEXception">Load Fails</exception>
        /// <returns>List<FundraisingEvent></returns>
        List<FundraisingEventVM> SelectAllFundraisingEventsByShelterId(int shelterId);
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
