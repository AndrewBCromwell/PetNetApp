using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IRequestManager
    {
        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/03/10
        /// 
        /// Retrieves the requests sent to a spcific shelter
        /// </summary>
        /// <remarks>
        /// Oleksiy Fedchuk
        /// Updated: 2023/04/17
        /// 
        /// Final QA
        /// </remarks>
        /// <param name="shelterId">The shelter Id of the shelter the request was sent to</param>
        /// <exception cref="Exception">Select Fails</exception>
        /// <returns>List of RequestVM</returns>
        List<RequestVM> RetrieveRequestsByShelterId(int shelterId);

        /// <summary>
        /// Andrew Cromwell
        /// Created: 2023/04/06
        /// 
        /// Inserts a new request into the request table
        /// </summary>        
        /// <param name="request">The RequestVM with the data to insert</param>
        /// <exception cref="Exception">Insert Fails</exception>
        /// <returns>bool of whether the insert was successful</returns>
        bool AddInventoryItemRequest(RequestVM request);
    }
}
