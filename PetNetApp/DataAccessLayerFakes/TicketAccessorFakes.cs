using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class TicketAccessorFakes : ITicketAccessor
    {
        List<TicketVM> fakeTickVMs = new List<TicketVM>();
        TicketVM fakeTicketVM = new TicketVM();

        public TicketAccessorFakes()
        {
            fakeTickVMs.Add(new TicketVM
            {
                TicketId = 100000,
                UserId = 100000,
                TicketStatusId = "Open",
                TicketTitle = "Want to speak with admin",
                TicketDate = DateTime.Now,
                TicketActive = true,
                Email = "fakeEmail@company.com"
            });

            fakeTickVMs.Add(new TicketVM
            {
                TicketId = 100001,
                UserId = 100001,
                TicketStatusId = "Open",
                TicketTitle = "Want to speak with admin",
                TicketDate = DateTime.Now,
                TicketActive = true,
                Email = "fakeEmail@company.com"
            });

            fakeTickVMs.Add(new TicketVM
            {
                TicketId = 100002,
                UserId = 100002,
                TicketStatusId = "Open",
                TicketTitle = "Want to speak with admin",
                TicketDate = DateTime.Now,
                TicketActive = true,
                Email = "fakeEmail@company.com"
            });
        }

        public int InsertTicket(int UserId, string TicketStatusId, string TicketTitle, string TicketContext)
        {
            int result = 0;
            int existing = fakeTickVMs.Count;
            fakeTickVMs.Add(fakeTicketVM);
            result = fakeTickVMs.Count - existing;
            return result;
        }

        public List<TicketVM> SelectAllTickets()
        {
            return fakeTickVMs;
        }

        public int UpdateTicketStatus(Ticket newTicket, Ticket oldTicket)
        {
            int result = 0;

            for (int i = 0; i < fakeTickVMs.Count; i++)
            {
                if (fakeTickVMs[i].TicketId == oldTicket.TicketId)
                {
                    fakeTickVMs[i].TicketStatusId = newTicket.TicketStatusId;

                    result++;
                    break;
                }
            }

            return result;
        }
    }
}
