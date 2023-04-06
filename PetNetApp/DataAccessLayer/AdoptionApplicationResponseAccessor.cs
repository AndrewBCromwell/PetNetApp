// Created by Asa Armstrong
// Created on 2023/03/30
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
    public class AdoptionApplicationResponseAccessor : IAdoptionApplicationResponseAccessor
    {
        public int InsertAdoptionApplicationResponse(AdoptionApplicationResponse adoptionApplicationResponse)
        {
            int rowsAffected = 0;

            var conn = new DBConnection().GetConnection();
            var cmdText = "sp_insert_adoption_application_response_by_adoption_application_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AdoptionApplicationId", adoptionApplicationResponse.AdoptionApplicationId);
            cmd.Parameters.AddWithValue("@UsersId", adoptionApplicationResponse.ResponderUserId);
            cmd.Parameters.AddWithValue("@Approved", adoptionApplicationResponse.Approved);

            //cmd.Parameters.AddWithValue("@AdoptionApplicationResponseNotes", adoptionApplicationResponse.AdoptionApplicationResponseNotes);
            if (adoptionApplicationResponse.AdoptionApplicationResponseNotes == null || adoptionApplicationResponse.AdoptionApplicationResponseNotes.Length == 0)
            {
                cmd.Parameters.AddWithValue("@AdoptionApplicationResponseNotes", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@AdoptionApplicationResponseNotes", adoptionApplicationResponse.AdoptionApplicationResponseNotes);
            }

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

        public AdoptionApplicationResponseVM SelectAdoptionApplicationResponseByAdoptionApplicationId(int adoptionApplicationId)
        {
            AdoptionApplicationResponseVM responseVM = new AdoptionApplicationResponseVM();

            var conn = new DBConnection().GetConnection();
            var cmdText = "sp_select_adoption_application_response_by_adoption_application_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AdoptionApplicationId", adoptionApplicationId);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        responseVM.AdoptionApplicationResponseId = reader.GetInt32(0);
                        responseVM.AdoptionApplicationId = reader.GetInt32(1);
                        responseVM.ResponderUserId = reader.GetInt32(2);
                        responseVM.Approved = reader.GetBoolean(3);
                        responseVM.AdoptionApplicationResponseDate = reader.GetDateTime(4);
                        responseVM.AdoptionApplicationResponseNotes = reader.IsDBNull(5) ? null : reader.GetString(5);
                        responseVM.ApplicantId = reader.GetInt32(6);
                        responseVM.AdoptionApplicantGivenName = reader.IsDBNull(7) ? null : reader.GetString(7);
                        responseVM.AdoptionApplicantFamilyName = reader.GetString(8);
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

            return responseVM;
        }

        public int UpdateAdoptionApplicationResponse(AdoptionApplicationResponse newAdoptionApplicationResponse, AdoptionApplicationResponse oldAdoptionApplicationResponse)
        {
            int rowsAffected = 0;

            var conn = new DBConnection().GetConnection();
            var cmdText = "sp_update_adoption_application_response";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AdoptionApplicationResponseId", oldAdoptionApplicationResponse.AdoptionApplicationResponseId);
            cmd.Parameters.AddWithValue("@AdoptionApplicationId", oldAdoptionApplicationResponse.AdoptionApplicationId);
            cmd.Parameters.AddWithValue("@UsersId", oldAdoptionApplicationResponse.ResponderUserId);

            cmd.Parameters.AddWithValue("@OldApproved", oldAdoptionApplicationResponse.Approved);
            //cmd.Parameters.AddWithValue("@OldAdoptionApplicationResponseNotes", oldAdoptionApplicationResponse.AdoptionApplicationResponseNotes);
            if (oldAdoptionApplicationResponse.AdoptionApplicationResponseNotes == null || oldAdoptionApplicationResponse.AdoptionApplicationResponseNotes.Length == 0)
            {
                cmd.Parameters.AddWithValue("@OldAdoptionApplicationResponseNotes", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@OldAdoptionApplicationResponseNotes", oldAdoptionApplicationResponse.AdoptionApplicationResponseNotes);
            }

            cmd.Parameters.AddWithValue("@NewApproved", newAdoptionApplicationResponse.Approved);
            //cmd.Parameters.AddWithValue("@NewAdoptionApplicationResponseNotes", newAdoptionApplicationResponse.AdoptionApplicationResponseNotes);
            if (newAdoptionApplicationResponse.AdoptionApplicationResponseNotes == null || newAdoptionApplicationResponse.AdoptionApplicationResponseNotes.Length == 0)
            {
                cmd.Parameters.AddWithValue("@NewAdoptionApplicationResponseNotes", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@NewAdoptionApplicationResponseNotes", newAdoptionApplicationResponse.AdoptionApplicationResponseNotes);
            }

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowsAffected;
        }
    }
}
