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
