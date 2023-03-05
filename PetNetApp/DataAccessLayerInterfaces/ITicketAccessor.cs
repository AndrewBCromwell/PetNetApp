using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces
{
    public interface ITicketAccessor
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
        List<TicketVM> SelectAllTickets();

        /// <summary>
        /// William Rients
        /// Created: 2023/03/03
        /// 
        /// Inserts a ticket
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <exception cref="Exception">Inserting ticket failed</exception>
        /// <returns>Rows Affected</returns>
        int InsertTicket(int UserId, string TicketStatusId, string TicketTitle, string TicketContext);
    }
}
