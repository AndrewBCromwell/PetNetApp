using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    public class TicketManager : ITicketManager
    {
        private ITicketAccessor _ticketAccessor = null;

        public TicketManager()
        {
            _ticketAccessor = new TicketAccessor();
        }

        public TicketManager(ITicketAccessor ticketAccessor)
        {
            _ticketAccessor = ticketAccessor;
        }

        public bool CreateNewTicket(int UserId, string TicketStatusId, string TicketTitle, string TicketContext)
        {
            bool result = false;

            try
            {
                if (0 < _ticketAccessor.InsertTicket(UserId, TicketStatusId, TicketTitle, TicketContext))
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Failed to create new ticket.", e);
            }
            return result;
        }

        public List<TicketVM> RetrieveAllTickets()
        {
            try
            {
                return _ticketAccessor.SelectAllTickets();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Failed to retrieve tickets", e);
            }
        }
    }
}
