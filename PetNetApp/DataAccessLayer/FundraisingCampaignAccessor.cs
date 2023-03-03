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
    public class FundraisingCampaignAccessor : IFundraisingCampaignAccessor
    {
 
        public List<FundraisingCampaignVM> SelectAllFundraisingCampaignsByShelterId(int shelterId)
        {
            List<FundraisingCampaignVM> fundraisingCampaigns = new List<FundraisingCampaignVM>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_all_fundraising_campaigns_by_shelterId";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ShelterId", SqlDbType.Int).Value = shelterId;

            try
            {
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            fundraisingCampaigns.Add(new FundraisingCampaignVM()
                            {
                                FundraisingCampaignId = reader.GetInt32(0),
                                UsersId = reader.GetInt32(1),
                                ShelterId = reader.GetInt32(2),
                                Title = reader.GetString(3),
                                StartDate = reader.IsDBNull(4) ? new DateTime?() : reader.GetDateTime(4),
                                EndDate = reader.IsDBNull(5) ? new DateTime?() : reader.GetDateTime(5),
                                Description = reader.IsDBNull(6) ? null : reader.GetString(6),
                                Complete = reader.GetBoolean(7),
                                Sponsors = new List<Sponsor>()
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
            return fundraisingCampaigns;
        }

        public int UpdateFundraisingCampaign(FundraisingCampaignVM oldFundraisingCampaignVM, FundraisingCampaignVM newFundraisingCampaignVM)
        {
            throw new NotImplementedException();
        }
        public int InsertFundraisingCampaign(FundraisingCampaignVM fundraisingCampaign)
        {
            throw new NotImplementedException();
        }

    }
}
