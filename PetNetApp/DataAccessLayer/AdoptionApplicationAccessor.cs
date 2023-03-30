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
    public class AdoptionApplicationAccessor : IAdoptionApplicationAccessor
    {
        public int InsertAdoptionApplication(AdoptionApplicationVM app)
        {
            int result = 0;

            DBConnection factory = new DBConnection();
            var conn = factory.GetConnection();
            var cmdText = "sp_insert_adoption_application";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UsersId", 100000);
            cmd.Parameters.AddWithValue("@ApplicantGivenName", app.AdoptionApplicant.ApplicantGivenName);
            cmd.Parameters.AddWithValue("@ApplicantFamilyName", app.AdoptionApplicant.ApplicantFamilyName);
            cmd.Parameters.AddWithValue("@ApplicantAddress", app.AdoptionApplicant.ApplicantAddress);
            cmd.Parameters.AddWithValue("@ApplicantAddress2", app.AdoptionApplicant.ApplicantAddress2);
            cmd.Parameters.AddWithValue("@ApplicantZipCode", app.AdoptionApplicant.ApplicantZipCode);
            cmd.Parameters.AddWithValue("@ApplicantPhoneNumber", app.AdoptionApplicant.ApplicantPhoneNumber);
            cmd.Parameters.AddWithValue("@ApplicantEmail", app.AdoptionApplicant.ApplicantEmail);
            cmd.Parameters.AddWithValue("@HomeTypeId", app.AdoptionApplicant.HomeTypeId);
            cmd.Parameters.AddWithValue("@HomeOwnershipId", app.AdoptionApplicant.HomeOwnershipId);
            cmd.Parameters.AddWithValue("@NumberOfChildren", app.AdoptionApplicant.NumberOfChildren);
            cmd.Parameters.AddWithValue("@NumberOfPets", app.AdoptionApplicant.NumberOfPets);
            cmd.Parameters.AddWithValue("@AnimalId", 100008);
            cmd.Parameters.AddWithValue("@ApplicationDate", app.AdoptionApplicationDate);


            try
            {
                conn.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());
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

        public List<string> SelectAllHomeOwnershipTypes()
        {
            List<string> homeOwnershipList = new List<string>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_all_home_ownership_types";
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
                        string type;
                        type = reader.GetString(0);
                        homeOwnershipList.Add(type);
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

            return homeOwnershipList;
        }

        public List<string> SelectAllHomeTypes()
        {
            List<string> homeTypeList = new List<string>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_all_home_types";
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
                        string type;
                        type = reader.GetString(0);
                        homeTypeList.Add(type);
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

            return homeTypeList;
        }
    }
}
