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
        public int InsertTicket(int UserId, string TicketStatusId, string TicketTitle, string TicketContext)
        {
            int result = 0;

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_insert_ticket";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@TicketStatusId", TicketStatusId);
            cmd.Parameters.AddWithValue("@TicketTitle", TicketTitle);
            cmd.Parameters.AddWithValue("@TicketContext", TicketContext);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

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
                        //[TicketTitle], [TicketContext], [UserId], [TicketStatusId], [TicketId], [TicketDate], [TicketActive], [Email]
                        var ticket = new TicketVM();
                        ticket.TicketTitle = reader.GetString(0);
                        ticket.TicketContext = reader.GetString(1);
                        ticket.UserId = reader.GetInt32(2);
                        ticket.TicketStatusId = reader.GetString(3);
                        ticket.TicketId = reader.GetInt32(4);
                        ticket.TicketDate = reader.GetDateTime(5);
                        ticket.TicketActive = reader.GetBoolean(6);
                        ticket.Email = reader.GetString(7);
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
