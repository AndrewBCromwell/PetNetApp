using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IRequestAccessor
    {
        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/03/10
        /// 
        /// Selects the requests sent to a spcific shelter
        /// </summary>        
        /// <param name="shelterId">The shelter Id of the shelter the request was sent to</param>
        /// <exception cref="Exception">Select Fails</exception>
        /// <returns>List of RequestVM</returns>
        List<RequestVM> SelectRequestsByShelterSentTo(int ShelterId);

        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/03/10
        /// 
        /// Adds each RequestResourceLine for a Request to the RequestResourceLines property of the Request
        /// </summary>        
        /// <param name="request">The RequestVM to set the RequestResourceLines propertie of</param>
        /// <exception cref="Exception">Select Fails</exception>
        /// <returns>The RequestVM that was passed in affter it gets updated</returns>
        RequestVM SelectRequestResourceLinesByRequestId(RequestVM request);
    }
}
