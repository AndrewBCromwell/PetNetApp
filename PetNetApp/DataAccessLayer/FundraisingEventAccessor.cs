using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{

    /// <summary>
    /// Barry Mikulas
    /// Created: 2023/03/10
    /// 
    /// The data access layer class to access fundraising event information from the database
    /// </summary>
    public class FundraisingEventAccessor : IFundraisingEventAccessor
    {
        public List<FundraisingEventVM> SelectAllFundraisingEventsByCampaignId(int campaignId)
        {
            List<FundraisingEventVM> fundraisingEvents = new List<FundraisingEventVM>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_all_active_fundraising_events_by_campaignId";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CampaignId", SqlDbType.Int).Value = campaignId;

            try
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            fundraisingEvents.Add(new FundraisingEventVM()
                            {
                                FundraisingEventId = reader.GetInt32(0),
                                UsersId = reader.GetInt32(1),
                                ImageId = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2),
                                CampaignId = reader.IsDBNull(3) ? null : (int?)reader.GetInt32(3),
                                ShelterId = reader.GetInt32(4),
                                Title = reader.GetString(5),
                                StartTime = reader.IsDBNull(6) ? new DateTime?() : reader.GetDateTime(6),
                                EndTime = reader.IsDBNull(7) ? new DateTime?() : reader.GetDateTime(7),
                                Hidden = reader.GetBoolean(8),
                                Complete = reader.GetBoolean(9),
                                Description = reader.IsDBNull(10) ? null : reader.GetString(10),
                                AdditionalInfo = reader.IsDBNull(11) ? null : reader.GetString(11),
                                Cost = reader.IsDBNull(12) ? null : (decimal?)reader.GetDecimal(12),
                                NumOfAttendees = reader.IsDBNull(13) ? null : (int?)reader.GetInt32(13),
                                NumAnimalsAdopted = reader.IsDBNull(14) ? null : (int?)reader.GetInt32(14),
                                UpdateNotes = reader.IsDBNull(15) ? null : reader.GetString(15),
                                Sponsors = new List<InstitutionalEntity>(),
                                Contacts = new List<InstitutionalEntity>(),
                                Host = new InstitutionalEntity()

                            });
                        }
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
            return fundraisingEvents;
        }

        public List<FundraisingEventVM> SelectAllFundraisingEventsByShelterId(int shelterId)
        {
            //throw new NotImplementedException();
            List<FundraisingEventVM> fundraisingEvents = new List<FundraisingEventVM>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_all_fundraising_events_by_shelterId";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ShelterId", SqlDbType.Int).Value = shelterId;

            try
            {
                conn.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            fundraisingEvents.Add(new FundraisingEventVM()
                            {
                                // [FundraisingEventId], [UsersId], [ImageId], [CampaignId], [ShelterId], [Title], [StartTime], [EndTime],
                                // [Hidden], [Complete], [Description], [AdditionalInfo], [Cost], [NumOfAttendees], [NumAnimalsAdopted], [UpdateNotes]
                                FundraisingEventId = reader.GetInt32(0),
                                UsersId = reader.GetInt32(1),
                                ImageId = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2),
                                CampaignId = reader.IsDBNull(3) ? null : (int?)reader.GetInt32(3),
                                ShelterId = reader.GetInt32(4),
                                Title = reader.GetString(5),
                                StartTime = reader.IsDBNull(6) ? new DateTime?() : reader.GetDateTime(6),
                                EndTime = reader.IsDBNull(7) ? new DateTime?() : reader.GetDateTime(7),
                                Hidden = reader.GetBoolean(8),
                                Complete = reader.GetBoolean(9),
                                Description = reader.IsDBNull(10) ? null : reader.GetString(10),
                                AdditionalInfo = reader.IsDBNull(11) ? null : reader.GetString(11),
                                Cost = reader.IsDBNull(12) ? null : (decimal?)reader.GetDecimal(12),
                                NumOfAttendees = reader.IsDBNull(13) ? null : (int?)reader.GetInt32(13),
                                NumAnimalsAdopted = reader.IsDBNull(14) ? null : (int?)reader.GetInt32(14),
                                UpdateNotes = reader.IsDBNull(15) ? null : reader.GetString(15),
                                Sponsors = new List<InstitutionalEntity>(),
                                Contacts = new List<InstitutionalEntity>(),
                                Host = new InstitutionalEntity()

                            });
                        }
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
            return fundraisingEvents;

        }

        public FundraisingEventVM SelectFundraisingEventByFundraisingEventId(int fundraisingEventId)
        {
            //throw new NotImplementedException();

            FundraisingEventVM fundraisingEvent = null;

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_fundraising_event_by_fundraising_event_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EventId", SqlDbType.Int).Value = fundraisingEventId;

            try
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        fundraisingEvent = new FundraisingEventVM()
                        {
                            // [FundraisingEventId], [UsersId], [ImageId], [CampaignId], [ShelterId], [Title], [StartTime], [EndTime],
                            // [Hidden], [Complete], [Description], [AdditionalInfo], [Cost], [NumOfAttendees], [NumAnimalsAdopted], [UpdateNotes]
                            FundraisingEventId = reader.GetInt32(0),
                            UsersId = reader.GetInt32(1),
                            ImageId = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2),
                            CampaignId = reader.IsDBNull(3) ? null : (int?)reader.GetInt32(3),
                            ShelterId = reader.GetInt32(4),
                            Title = reader.GetString(5),
                            StartTime = reader.IsDBNull(6) ? new DateTime?() : reader.GetDateTime(6),
                            EndTime = reader.IsDBNull(7) ? new DateTime?() : reader.GetDateTime(7),
                            Hidden = reader.GetBoolean(8),
                            Complete = reader.GetBoolean(9),
                            Description = reader.IsDBNull(10) ? null : reader.GetString(10),
                            AdditionalInfo = reader.IsDBNull(11) ? null : reader.GetString(11),
                            Cost = reader.IsDBNull(12) ? null : (decimal?)reader.GetDecimal(12),
                            NumOfAttendees = reader.IsDBNull(13) ? null : (int?)reader.GetInt32(13),
                            NumAnimalsAdopted = reader.IsDBNull(14) ? null : (int?)reader.GetInt32(14),
                            UpdateNotes = reader.IsDBNull(15) ? null : reader.GetString(15),
                            Sponsors = new List<InstitutionalEntity>(),
                            Contacts = new List<InstitutionalEntity>(),
                            Host = new InstitutionalEntity()
                        };
                    }
                    else
                    {
                        throw new ApplicationException("No Fundraising Events with id " + fundraisingEventId);
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

            return fundraisingEvent;

        }

        public int UpdateFundraisingEventResults(FundraisingEventVM oldFundraisingEventVM, FundraisingEventVM newFundraisingEventVM)
        {
            //throw new NotImplementedException();

            int recordsUpdated = 0;

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_update_fundraising_event_results";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@FundraisingEventId", SqlDbType.Int).Value = oldFundraisingEventVM.FundraisingEventId;

            cmd.Parameters.AddWithValue("@OldComplete", oldFundraisingEventVM.Complete);
            cmd.Parameters.AddWithValue("@OldCost", oldFundraisingEventVM.Cost);
            cmd.Parameters.AddWithValue("@OldNumOfAttendees", oldFundraisingEventVM.NumOfAttendees);
            cmd.Parameters.AddWithValue("@OldNumAnimalsAdopted", oldFundraisingEventVM.NumAnimalsAdopted);
            if (oldFundraisingEventVM.UpdateNotes == null)
            {
                cmd.Parameters.AddWithValue("@OldUpdateNotes", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@OldUpdateNotes", oldFundraisingEventVM.UpdateNotes);
            }


            cmd.Parameters.AddWithValue("@NewComplete", newFundraisingEventVM.Complete);
            cmd.Parameters.AddWithValue("@NewCost", newFundraisingEventVM.Cost);
            cmd.Parameters.AddWithValue("@NewNumOfAttendees", newFundraisingEventVM.NumOfAttendees);
            cmd.Parameters.AddWithValue("@NewNumAnimalsAdopted", newFundraisingEventVM.NumAnimalsAdopted);
            if (newFundraisingEventVM.UpdateNotes == null)
            {
                cmd.Parameters.AddWithValue("@NewUpdateNotes", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@NewUpdateNotes", newFundraisingEventVM.UpdateNotes);
            }

            try
            {
                conn.Open();

                recordsUpdated = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return recordsUpdated;
        }
    }
}
