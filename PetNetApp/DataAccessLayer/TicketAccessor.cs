using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayer
{
    public class TicketAccessor : ITicketAccessor
    {
        public List<TicketVM> SelectAllTickets()
        {
            List<TicketVM> _tickets = new List<TicketVM>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_all_tickets";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //[TicketTitle], [UserId], [TicketStatusId], [TicketId], [TicketDate], [TicketActive], [Email]
                        var ticket = new TicketVM();
                        ticket.TicketTitle = reader.GetString(0);
                        ticket.UserId = reader.GetInt32(1);
                        ticket.TicketStatusId = reader.GetString(2);
                        ticket.TicketId = reader.GetInt32(3);
                        ticket.TicketDate = reader.GetDateTime(4);
                        ticket.TicketActive = reader.GetBoolean(5);
                        ticket.Email = reader.GetString(6);
                        _tickets.Add(ticket);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return _tickets;
        }
    }
}
