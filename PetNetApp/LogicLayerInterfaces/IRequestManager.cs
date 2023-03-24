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
        /// <param name="shelterId">The shelter Id of the shelter the request was sent to</param>
        /// <exception cref="Exception">Select Fails</exception>
        /// <returns>List of RequestVM</returns>
        List<RequestVM> RetrieveRequestsByShelterId(int shelterId);
    }
}
