using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public string TicketStatusId { get; set; }
        public string TicketTitle { get; set; }
        public string TicketContext { get; set; }
        public DateTime TicketDate { get; set; }
        public bool TicketActive { get; set; }
    }

    public class TicketVM : Ticket
    {
        public string Email { get; set; }
    }
}
