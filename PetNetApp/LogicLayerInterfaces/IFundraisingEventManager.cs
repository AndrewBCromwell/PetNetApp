using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/05
        /// 
        /// A method to get the fundraising events for this shelter
        /// </summary>
        /// 
        /// <param name="oldFundraisingEventVM">the original event object</param>
        /// <param name="newFundraisingEventVM">the updated event object</param>
        /// <exception cref="ApplicationException">Edit fails</exception>
        /// <returns>bool representing success of the event update</returns>
        bool EditFundraisingEventResults(FundraisingEventVM oldFundraisingEventVM, FundraisingEventVM newFundraisingEventVM);

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/30
        /// 
        /// A method to to get a fundraising event by its event id
        /// </summary>
        /// <param name="fundraisingEventId">the id of the event to retrieve.</param>
        /// <returns>FundraisingEventVM</returns>
        FundraisingEventVM RetrieveFundraisingEventByFundraisingEventId(int fundraisingEventId);
    }
}
