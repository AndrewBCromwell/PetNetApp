using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface ITicketManager
    {
        /// <summary>
        /// William Rients
        /// Created: 2023/02/17
        /// 
        /// Selects a list of tickets
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <exception cref="Exception">No tickets to be selected</exception>
        /// <returns>List of ticket objects</returns>	
        List<TicketVM> RetrieveAllTickets();

        /// <summary>
        /// William Rients
        /// Created: 2023/03/03
        /// 
        /// Creates a ticket
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <exception cref="Exception">Creating ticket failed</exception>
        /// <returns>True or false if ticket was created</returns>
        bool CreateNewTicket(int UserId, string TicketStatusId, string TicketTitle, string TicketContext);
    }
}
