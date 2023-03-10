/// <summary>
/// Asa Armstrong
/// Created: 2023/03/01
/// 
/// Data Accessor class to CRUD Institutional Entity objects.
/// </summary>
///
/// <remarks>
/// Asa Armstrong
/// Updated: 2023/03/01
/// Created
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
    /// <summary>
    /// Stephen Jaurigue
    /// Created: 2023/02/23
    /// 
    /// The data access layer class to access institutional entity information from the database
    /// </summary>
    public class InstitutionalEntityAccessor : IInstitutionalEntityAccessor
    {
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
                        institutionalEntity.AddressTwo = reader.IsDBNull(7) ? null : reader.GetString(7);
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
                        institutionalEntity.AddressTwo = reader.IsDBNull(7) ? null : reader.GetString(7);
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


        public List<InstitutionalEntity> SelectAllInstitutionalEntitiesByShelterIdAndEntityType(int shelterId, string entityType)
        {
            List<InstitutionalEntity> institutionalEntities = new List<InstitutionalEntity>();

            var conn = new DBConnection().GetConnection();
            var cmdText = "sp_select_all_institutionalEntities_by_shelterId_and_entityType";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ShelterId", shelterId);
            cmd.Parameters.AddWithValue("@EntityType", entityType);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        institutionalEntities.Add(new InstitutionalEntity
                        {
                            InstitutionalEntityId = reader.GetInt32(0),
                            CompanyName = (reader.IsDBNull(1) ? null : reader.GetString(1)),
                            GivenName = reader.GetString(2),
                            FamilyName = reader.GetString(3),
                            Email = reader.GetString(4),
                            Phone = reader.GetString(5),
                            Address = reader.GetString(6),
                            AddressTwo = (reader.IsDBNull(7) ? null : reader.GetString(7)),
                            Zipcode = reader.GetString(8).Substring(0, 5),
                            ContactType = reader.GetString(9),
                            ShelterId = reader.GetInt32(10)
                        });
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

            return institutionalEntities;
        }

        public InstitutionalEntity SelectInstitutionalEntityByInstitutionalEntityId(int institutionalEntityId)
        {
            throw new NotImplementedException();
        }

        public int InsertInstitutionalEntityByShelterId(int shelterId)
        {
            throw new NotImplementedException();
        }

        public int UpdateInstitutionalEntity(InstitutionalEntity oldEntity, InstitutionalEntity newEntity)
        {
            throw new NotImplementedException();
        }

        public int InsertInstitutionalEntity(InstitutionalEntity institutionalEntity)
        {
            throw new NotImplementedException();
        }
    }
}
