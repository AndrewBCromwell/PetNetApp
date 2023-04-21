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
    public class AdoptionApplicationResponseAccessor : IAdoptionApplicationResponseAccessor
    {
        public int InsertAdoptionApplicationResponseByAdoptionApplicationId(AdoptionApplicationResponseVM adoptionApplicationResponseVM)
        {
            int result = 0;

            DBConnection factory = new DBConnection();
            var conn = factory.GetConnection();
            var cmdText = "sp_add_adoption_application_response";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AdoptionApplicationId", adoptionApplicationResponseVM.AdoptionApplicationId);
            cmd.Parameters.AddWithValue("@UsersId", adoptionApplicationResponseVM.ResponderUserId);
            cmd.Parameters.AddWithValue("@Approved", adoptionApplicationResponseVM.Approved);
            cmd.Parameters.AddWithValue("@AdoptionApplicationResponseDate", adoptionApplicationResponseVM.AdoptionApplicationResponseDate);
            cmd.Parameters.AddWithValue("@AdoptionApplicationResponseNotes", adoptionApplicationResponseVM.AdoptionApplicationResponseNotes);

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
    }
}
