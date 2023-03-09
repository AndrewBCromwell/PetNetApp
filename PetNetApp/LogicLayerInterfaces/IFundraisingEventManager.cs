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
        List<FundraisingEvent> RetrieveAllFundraisingEventsByShelterId(int shelterId);
    }
}
