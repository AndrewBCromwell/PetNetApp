using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class EventAccessor:IEventAccessor
    {
        public List<Event> SelectAllEvent()
        {
            List<Event> events = new List<Event>();

            // connection
            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            // command text
            var cmdText = "sp_select_all_events";

            // command 
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // try-catch-finally
            try
            {
                // open a connection
                conn.Open();

                // execute command
                var reader = cmd.ExecuteReader();

                // process the results
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var ivent = new EventVM();

                        ivent.Eventid = reader.GetInt32(0);
                        ivent.EventTypeid = reader.GetString(1);
                        ivent.Shelterid = reader.GetInt32(2);
                        ivent.EventTitle = reader.GetString(3);
                        ivent.EventDescription = reader.GetString(4);
                        ivent.EventStart = reader.GetDateTime(5);
                        ivent.EventEnd = reader.GetDateTime(6);
                        ivent.EventAddress = reader.GetString(7);
                        ivent.EventZipcode = reader.GetString(8);
                        ivent.EventVisible = reader.GetBoolean(9);
                        
                        events.Add(ivent);
        }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return events;
        }
    }
}
