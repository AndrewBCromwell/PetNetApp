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


        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/30
        /// 
        /// A method to update a fundraising event object, with event update information
        /// </summary>
        /// <param name="oldFundraisingEventVM">the original funraising event object</param>
        /// <param name="newFundraisingEventVM">the updated fundraising event objecxt</param>
        /// <returns>the number of events updated</returns>
        int UpdateFundraisingEventResults(FundraisingEventVM oldFundraisingEventVM, FundraisingEventVM newFundraisingEventVM);

        /// <summary>
        /// Barry Mikulas 
        /// 2023/03/30
        /// 
        /// Loads a fundraising event by its event id
        /// </summary>
        /// <param name="fundraisingEventId">The id of the fundraising event to load</param>
        /// <returns>A Fundraising Event VM</returns>
        FundraisingEventVM SelectFundraisingEventByFundraisingEventId(int fundraisingEventId);
    }
}
