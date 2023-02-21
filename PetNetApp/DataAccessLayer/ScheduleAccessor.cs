/// <summary>
/// Chris Dreismeier
/// Created: 2023/02/09
/// 
/// 
/// Class for Accessing data from the database
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
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
    public class ScheduleAccessor : IScheduleAccessor
    {

        /// <summary>
        /// Chris Dreismeier
        /// Created: 2023/02/09
        /// 
        /// Gets all people who are scheduled on the date passed through
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="selectedDate">date the user selected to see who is scheduled that day</param>
        /// <exception cref="SQLException">Select fails</exception>
        /// <returns>List<ScheduleVM></returns>
        public List<ScheduleVM> SelectScheduleByDate(DateTime selectedDate)
        {
            var schedules = new List<ScheduleVM>();

            var conn = new DBConnection().GetConnection();

            var cmdtext = "sp_select_schedule_by_date";

            var cmd = new SqlCommand(cmdtext, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@selectedDate", SqlDbType.DateTime);

            cmd.Parameters["@selectedDate"].Value = selectedDate;

            try
            {
                // open connection
                conn.Open();

                // execute and get a SqlDataReader
                var reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ScheduleVM schedule = new ScheduleVM();
                        schedule.ScheduleId = reader.GetInt32(0);
                        schedule.UserId = reader.GetInt32(1);
                        schedule.JobId = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2);
                        schedule.StartTime = reader.GetDateTime(3);
                        schedule.EndTime = reader.GetDateTime(4);
                        schedule.GivenName = reader.GetString(5);
                        schedule.FamilyName = reader.GetString(6);
                        schedules.Add(schedule);
                    }
                }
                // close reader
                reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return schedules;
        }


        /// <summary>
        /// Chris Dreismeier
        /// Created: 2023/02/17
        /// 
        /// Gets all of the Schedules that for the user passed through
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="userId">The user that you want to see specific schedule</param>
        /// <exception cref="SQLException">Select fails</exception>
        /// <returns>List<ScheduleVM></returns>
        public List<ScheduleVM> SelectScheduleByUser(int userId)
        {
            var schedules = new List<ScheduleVM>();

            var conn = new DBConnection().GetConnection();

            var cmdtext = "sp_select_schedule_by_userId";

            var cmd = new SqlCommand(cmdtext, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserId", SqlDbType.Int);

            cmd.Parameters["@UserId"].Value = userId;

            try
            {
                // open connection
                conn.Open();

                // execute and get a SqlDataReader
                var reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ScheduleVM schedule = new ScheduleVM();
                        schedule.ScheduleId = reader.GetInt32(0);
                        schedule.UserId = reader.GetInt32(1);
                        schedule.JobId = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2);
                        schedule.StartTime = reader.GetDateTime(3);
                        schedule.EndTime = reader.GetDateTime(4);
                        schedule.GivenName = reader.GetString(5);
                        schedule.FamilyName = reader.GetString(6);
                        schedules.Add(schedule);
                    }
                }
                // close reader
                reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return schedules;
        }
    }
}
