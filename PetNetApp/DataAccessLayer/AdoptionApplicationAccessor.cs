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
            // come back once have animal passed in to application
            cmd.Parameters.AddWithValue("@AnimalId", app.AnimalId);
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

        public List<AdoptionApplicationVM> SelectAllAdoptionApplicationsByAnimalId(int animalId)
        {
            List<AdoptionApplicationVM> applications = new List<AdoptionApplicationVM>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_select_all_adoption_applications_by_animal_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@animalId", animalId);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AdoptionApplicationVM application = new AdoptionApplicationVM()
                        {
                            AdoptionApplicationId = reader.GetInt32(0),
                            AnimalId = reader.GetInt32(1),
                            ApplicationStatusId = reader.GetString(2),
                            AdoptionApplicationDate = reader.GetDateTime(3),
                            ApplicantId = reader.GetInt32(4)
                        };

                        Applicant applicant = new Applicant()
                        {
                            ApplicantId = reader.GetInt32(4),
                            UserId = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5),
                            ApplicantGivenName = reader.GetString(6),
                            ApplicantFamilyName = reader.GetString(7),
                            ApplicantAddress = reader.GetString(8),
                            ApplicantAddress2 = reader.IsDBNull(9) ? "" : reader.GetString(9),
                            ApplicantZipCode = reader.GetString(10),
                            ApplicantPhoneNumber = reader.GetString(11),
                            ApplicantEmail = reader.GetString(12),
                            HomeTypeId = reader.GetString(13),
                            HomeOwnershipId = reader.GetString(14),
                            NumberOfChildren = reader.GetInt32(15),
                            NumberOfPets = reader.GetInt32(16),
                            CurrentlyAcceptingAnimals = reader.GetBoolean(17)
                        };

                        application.AdoptionApplicant = applicant;
                        applications.Add(application);
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

            return applications;
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

        public int UpdateAdoptionApplicationStatusByAnimalIdForApprovedApplication(AdoptionApplicationResponse response)
        {
            int rowsAffected = 0;

            var conn = new DBConnection().GetConnection();
            var cmdText = "sp_update_application_status_by_animal_id_for_approved_application";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@adoptionApplicationId", response.AdoptionApplicationId);
            cmd.Parameters.AddWithValue("@usersId", response.ResponderUserId);
            cmd.Parameters.AddWithValue("@approved", response.Approved);
            cmd.Parameters.AddWithValue("@adoptionApplicationResponseDate", response.AdoptionApplicationResponseDate);
            cmd.Parameters.AddWithValue("@adoptionApplicationResponseNotes", response.AdoptionApplicationResponseNotes);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rowsAffected;
        }
    }
}
