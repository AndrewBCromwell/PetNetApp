using DataAccessLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class RoleAccessor : IRoleAccessor
    {

        // Created By: Asa Armstrong
        public int DeleteRoleByUsersIdAndRoleId(int usersId, string roleId)
        {
            int rowsAffected = 0;

            var conn = new DBConnection().GetConnection();
            var cmdText = "sp_delete_role_by_user_id_and_role_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsersId", usersId);
            cmd.Parameters.AddWithValue("@RoleId", roleId);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                /*if (rowsAffected == -1)
                {
                    throw new ApplicationException("Cannot remove the last 'Admin' Role.");
                }*/
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowsAffected;
        }
    }
}
