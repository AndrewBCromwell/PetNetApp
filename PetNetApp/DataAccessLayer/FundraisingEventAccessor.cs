using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class FundraisingEventAccessor : IFundraisingEventAccessor
    {
        public int DeactivateFundraisingEvent(int fundraisingEventId)
        {
            int rowAffected = 0;

            DBConnection factory = new DBConnection();
            var conn = factory.GetConnection();
            var cmdText = "sp_deactivate_fundrasing_event";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FundraisingEventId", fundraisingEventId);

            try
            {
                conn.Open();
                rowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rowAffected;
        }

        public int InsertFundraiserAnimal(int fundraisingEventId, int animalId)
        {
            int rowAffected = 0;

            DBConnection factory = new DBConnection();
            var conn = factory.GetConnection();
            var cmdText = "sp_insert_fundraiser_animal";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FundraisingEventId", fundraisingEventId);
            cmd.Parameters.AddWithValue("@AnimalId", animalId);

            try
            {
                conn.Open();
                rowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rowAffected;
        }

        public int InsertFundraisingEvent(FundraisingEvent fundraisingEvent)
        {
            int id = 0;

            DBConnection factory = new DBConnection();
            var conn = factory.GetConnection();
            var cmdText = "sp_insert_fundrasing_event";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UsersId", fundraisingEvent.UserId);
            if (fundraisingEvent.ImageId == null)
            {
                cmd.Parameters.AddWithValue("@ImageId", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ImageId", fundraisingEvent.ImageId);
            }
            if (fundraisingEvent.CampaignId == null)
            {
                cmd.Parameters.AddWithValue("@CampaignId", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CampaignId", fundraisingEvent.CampaignId);
            }
            cmd.Parameters.AddWithValue("@ShelterId", fundraisingEvent.ShelterId);
            cmd.Parameters.AddWithValue("@Title", fundraisingEvent.Title);
            cmd.Parameters.AddWithValue("@StartTime", fundraisingEvent.StartTime);
            cmd.Parameters.AddWithValue("@EndTime", fundraisingEvent.EndTime);
            cmd.Parameters.AddWithValue("@Hidden", fundraisingEvent.Hidden);
            if (fundraisingEvent.Description == null)
            {
                cmd.Parameters.AddWithValue("@Description", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Description", fundraisingEvent.Description);
            }
            if (fundraisingEvent.AdditionalInfo == null)
            {
                cmd.Parameters.AddWithValue("@AdditionalInfo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@AdditionalInfo", fundraisingEvent.AdditionalInfo);
            }
            cmd.Parameters.AddWithValue("@NumOfAttendees", fundraisingEvent.NumOfAttendees);

            try
            {
                conn.Open();
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return id;
        }

        public int InsertFundraisingEventEntity(int eventId, int contactId)
        {
            int rowAffected = 0;

            DBConnection factory = new DBConnection();
            var conn = factory.GetConnection();
            var cmdText = "sp_insert_fundraising_event_entity";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EventId", eventId);
            cmd.Parameters.AddWithValue("@ContactId", contactId);

            try
            {
                conn.Open();
                rowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rowAffected;
        }

        public List<int> SelectAnimalByFundraisingEvent(int eventId)
        {
            List<int> animalIdList = new List<int>();

            DBConnection factory = new DBConnection();
            var conn = factory.GetConnection();
            var cmdText = "sp_select_animal_by_eventId";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FundraisingEventId", eventId);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        animalIdList.Add(reader.GetInt32(0));
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

            return animalIdList;
        }

        public List<int> SelectContactByFundraisingEvent(int eventId)
        {
            List<int> contactIdList = new List<int>();

            DBConnection factory = new DBConnection();
            var conn = factory.GetConnection();
            var cmdText = "sp_select_contact_by_eventId";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FundraisingEventId", eventId);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        contactIdList.Add(reader.GetInt32(0));
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

            return contactIdList;
        }

        public FundraisingEvent SelectFundraisingEvent(int eventId)
        {
            FundraisingEvent fundraisingEvent = new FundraisingEvent();

            DBConnection factory = new DBConnection();
            var conn = factory.GetConnection();
            var cmdText = "sp_select_fundrasing_event";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FundraisingEventId", eventId);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        fundraisingEvent.FundraisingEventId = eventId;
                        fundraisingEvent.UserId = reader.GetInt32(0);
                        fundraisingEvent.ImageId = reader.IsDBNull(1) ? null : reader.GetString(1);
                        if (reader.IsDBNull(2))
                        {
                            fundraisingEvent.CampaignId = null;
                        }
                        else
                        {
                            fundraisingEvent.CampaignId = reader.GetInt32(2);
                        }
                        fundraisingEvent.ShelterId = reader.GetInt32(3);
                        fundraisingEvent.Title = reader.GetString(4);
                        fundraisingEvent.StartTime = reader.GetDateTime(5);
                        fundraisingEvent.EndTime = reader.GetDateTime(6);
                        fundraisingEvent.Hidden = reader.GetBoolean(7);
                        fundraisingEvent.Description = reader.GetString(8);
                        fundraisingEvent.AdditionalInfo = reader.GetString(9);
                        fundraisingEvent.NumOfAttendees = reader.GetInt32(10);

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

        public List<int> SelectSponsorByFundraisingEvent(int eventId)
        {
            List<int> sponsorIdList = new List<int>();

            DBConnection factory = new DBConnection();
            var conn = factory.GetConnection();
            var cmdText = "sp_select_sponsor_by_eventId";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FundraisingEventId", eventId);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sponsorIdList.Add(reader.GetInt32(0));
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

            return sponsorIdList;
        }

        public int UpdateFundraisingEvent(FundraisingEventVM fundraisingEvent)
        {
            int rowAffected = 0;

            DBConnection factory = new DBConnection();
            var conn = factory.GetConnection();
            SqlTransaction transaction = null;

            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();

                var removeFundraiserAnimalcmd = new SqlCommand("sp_delete_fundraiser_animal", conn, transaction);
                removeFundraiserAnimalcmd.CommandType = System.Data.CommandType.StoredProcedure;
                removeFundraiserAnimalcmd.Parameters.AddWithValue("@FundraisingEventId", fundraisingEvent.FundraisingEventId);
                rowAffected += removeFundraiserAnimalcmd.ExecuteNonQuery();

                var removeFundraisingInstitutionalcmd = new SqlCommand("sp_delete_fundraising_event_entity", conn, transaction);
                removeFundraisingInstitutionalcmd.CommandType = System.Data.CommandType.StoredProcedure;
                removeFundraisingInstitutionalcmd.Parameters.AddWithValue("@EventId", fundraisingEvent.FundraisingEventId);
                rowAffected += removeFundraisingInstitutionalcmd.ExecuteNonQuery();

                
                foreach (var animal in fundraisingEvent.Animals)
                {
                    var addFundraiserAnimalcmd = new SqlCommand("sp_insert_fundraiser_animal", conn, transaction);
                    addFundraiserAnimalcmd.CommandType = System.Data.CommandType.StoredProcedure;
                    addFundraiserAnimalcmd.Parameters.AddWithValue("@FundraisingEventId", fundraisingEvent.FundraisingEventId);
                    addFundraiserAnimalcmd.Parameters.AddWithValue("@AnimalId", animal.AnimalId);
                    rowAffected += addFundraiserAnimalcmd.ExecuteNonQuery();
                }

               
                List<InstitutionalEntity> institutionalEntitiesToAdd = fundraisingEvent.Contacts;
                foreach (InstitutionalEntity institutional in fundraisingEvent.Sponsors)
                {
                    institutionalEntitiesToAdd.Add(institutional);
                }
                foreach (InstitutionalEntity institutional in institutionalEntitiesToAdd)
                {
                    var addFundraisingInstitutionalcmd = new SqlCommand("sp_insert_fundraising_event_entity", conn, transaction);
                    addFundraisingInstitutionalcmd.CommandType = System.Data.CommandType.StoredProcedure;
                    addFundraisingInstitutionalcmd.Parameters.AddWithValue("@EventId", fundraisingEvent.FundraisingEventId);
                    addFundraisingInstitutionalcmd.Parameters.AddWithValue("@ContactId", institutional.InstitutionalEntityId);
                    rowAffected += addFundraisingInstitutionalcmd.ExecuteNonQuery();
                }
                

                var cmdText = "sp_update_fundrasing_event";
                var cmd = new SqlCommand(cmdText, conn, transaction);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FundraisingEventId", fundraisingEvent.FundraisingEventId);
                cmd.Parameters.AddWithValue("@UsersId", fundraisingEvent.UserId);
                cmd.Parameters.AddWithValue("@ShelterId", fundraisingEvent.ShelterId);
                cmd.Parameters.AddWithValue("@Title", fundraisingEvent.Title);
                cmd.Parameters.AddWithValue("@Hidden", fundraisingEvent.Hidden);

                cmd.Parameters.Add("@ImageId", SqlDbType.NVarChar).Value = fundraisingEvent.ImageId == null ? (object)DBNull.Value : fundraisingEvent.ImageId;
                cmd.Parameters.Add("@CampaignId", SqlDbType.Int).Value = fundraisingEvent.CampaignId == null ? (object)DBNull.Value : fundraisingEvent.CampaignId;
                cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = fundraisingEvent.StartTime == null ? (object)DBNull.Value : fundraisingEvent.StartTime;
                cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = fundraisingEvent.EndTime == null ? (object)DBNull.Value : fundraisingEvent.EndTime;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = fundraisingEvent.Description == null ? (object)DBNull.Value : fundraisingEvent.Description;
                cmd.Parameters.Add("@AdditionalInfo", SqlDbType.NVarChar).Value = fundraisingEvent.AdditionalInfo == null ? (object)DBNull.Value : fundraisingEvent.AdditionalInfo;
                cmd.Parameters.Add("@NumOfAttendees", SqlDbType.NVarChar).Value = fundraisingEvent.NumOfAttendees == null ? (object)DBNull.Value : fundraisingEvent.NumOfAttendees;
                rowAffected += cmd.ExecuteNonQuery();

                transaction.Commit();

            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rowAffected;
        }
    }
}
