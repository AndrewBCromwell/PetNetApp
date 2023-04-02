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
    /// <summary>
    /// Stephen Jaurigue
    /// Created: 2023/02/23
    /// 
    /// The data access layer class to access institutional entity information from the database
    /// </summary>
    public class InstitutionalEntityAccessor : IInstitutionalEntityAccessor
    {
        public List<InstitutionalEntity> SelectAllContact()
        {
            List<InstitutionalEntity> contacts = new List<InstitutionalEntity>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_all_fundraising_contacts";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        InstitutionalEntity institutionalEntity = new InstitutionalEntity();

                        institutionalEntity.InstitutionalEntityId = reader.GetInt32(0);
                        institutionalEntity.CompanyName = reader.IsDBNull(1) ? null : reader.GetString(1);
                        institutionalEntity.GivenName = reader.GetString(2);
                        institutionalEntity.FamilyName = reader.GetString(3);
                        institutionalEntity.Email = reader.GetString(4);
                        institutionalEntity.Phone = reader.GetString(5);
                        institutionalEntity.Address = reader.GetString(6);
                        institutionalEntity.Address2 = reader.IsDBNull(7) ? null : reader.GetString(7);
                        institutionalEntity.Zipcode = reader.GetString(8);
                        institutionalEntity.ContactType = reader.GetString(9);

                        contacts.Add(institutionalEntity);
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

            return contacts;
        }

        public List<InstitutionalEntity> SelectAllHosts()
        {
            List<InstitutionalEntity> hosts = new List<InstitutionalEntity>();


            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_all_fundraising_hosts";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        InstitutionalEntity institutionalEntity = new InstitutionalEntity();

                        institutionalEntity.InstitutionalEntityId = reader.GetInt32(0);
                        institutionalEntity.CompanyName = reader.IsDBNull(1) ? null : reader.GetString(1);
                        institutionalEntity.GivenName = reader.GetString(2);
                        institutionalEntity.FamilyName = reader.GetString(3);
                        institutionalEntity.Email = reader.GetString(4);
                        institutionalEntity.Phone = reader.GetString(5);
                        institutionalEntity.Address = reader.GetString(6);
                        institutionalEntity.Address2 = reader.IsDBNull(7) ? null : reader.GetString(7);
                        institutionalEntity.Zipcode = reader.GetString(8);
                        institutionalEntity.ContactType = reader.GetString(9);

                        hosts.Add(institutionalEntity);
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

            return hosts;
        }

        public List<InstitutionalEntity> SelectAllSponsors()
        {
            List<InstitutionalEntity> sponsors = new List<InstitutionalEntity>();


            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_all_fundraising_sponsors";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        InstitutionalEntity institutionalEntity = new InstitutionalEntity();

                        institutionalEntity.InstitutionalEntityId = reader.GetInt32(0);
                        institutionalEntity.CompanyName = reader.IsDBNull(1) ? null : reader.GetString(1);
                        institutionalEntity.GivenName = reader.GetString(2);
                        institutionalEntity.FamilyName = reader.GetString(3);
                        institutionalEntity.Email = reader.GetString(4);
                        institutionalEntity.Phone = reader.GetString(5);
                        institutionalEntity.Address = reader.GetString(6);
                        institutionalEntity.Address2 = reader.IsDBNull(7) ? null : reader.GetString(7);
                        institutionalEntity.Zipcode = reader.GetString(8);
                        institutionalEntity.ContactType = reader.GetString(9);

                        sponsors.Add(institutionalEntity);
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

            return sponsors;
        }

        public List<InstitutionalEntity> SelectFundraisingSponsorsByCampaignId(int fundraisingCampaignId)
        {
            List<InstitutionalEntity> sponsors = new List<InstitutionalEntity>();


            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_fundraising_sponsors_by_campaignId";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.Parameters.Add("@FundraisingCampaignId", SqlDbType.Int).Value = fundraisingCampaignId;

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        InstitutionalEntity institutionalEntity = new InstitutionalEntity();

                        institutionalEntity.InstitutionalEntityId = reader.GetInt32(0);
                        institutionalEntity.CompanyName = reader.IsDBNull(1) ? null : reader.GetString(1);
                        institutionalEntity.GivenName = reader.GetString(2);
                        institutionalEntity.FamilyName = reader.GetString(3);
                        institutionalEntity.Email = reader.GetString(4);
                        institutionalEntity.Phone = reader.GetString(5);
                        institutionalEntity.Address = reader.GetString(6);
                        institutionalEntity.Address2 = reader.IsDBNull(7) ? null : reader.GetString(7);
                        institutionalEntity.Zipcode = reader.GetString(8);
                        institutionalEntity.ContactType = reader.GetString(9);

                        sponsors.Add(institutionalEntity);
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

            return sponsors;
        }

        public InstitutionalEntity SelectInstitutionalEntityByInstitutionalEntityId(int institutionalEntityId)
        {
            InstitutionalEntity institutionalEntity = new InstitutionalEntity();


            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_institutional_entity_by_institutionalId";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.Parameters.Add("@InstitutionalEntityId", SqlDbType.Int).Value = institutionalEntityId;

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        institutionalEntity.InstitutionalEntityId = reader.GetInt32(0);
                        institutionalEntity.CompanyName = reader.IsDBNull(1) ? null : reader.GetString(1);
                        institutionalEntity.GivenName = reader.GetString(2);
                        institutionalEntity.FamilyName = reader.GetString(3);
                        institutionalEntity.Email = reader.GetString(4);
                        institutionalEntity.Phone = reader.GetString(5);
                        institutionalEntity.Address = reader.GetString(6);
                        institutionalEntity.Address2 = reader.IsDBNull(7) ? null : reader.GetString(7);
                        institutionalEntity.Zipcode = reader.GetString(8);
                        institutionalEntity.ContactType = reader.GetString(9);

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

            return institutionalEntity;
        }
    }
}
