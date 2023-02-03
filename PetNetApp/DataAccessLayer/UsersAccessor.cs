using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class UsersAccessor : IUsersAccessor
    {

        /// <summary>
        /// Chris Dreismeier
        /// Created: 2023/03/02
        /// 
        /// 
        /// </summary>
        /// Selects all users with a certain role
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="RoleId"></param>
        public List<UsersVM> SelectUserByRole(string RoleId)
        {
            var users = new List<UsersVM>();

            var conn = new DBConnection().GetConnection();

            var cmdtext = "sp_select_users_by_roleId";

            var cmd = new SqlCommand(cmdtext, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@RoleId", SqlDbType.NVarChar);

            cmd.Parameters["@RoleId"].Value = RoleId;

            try
            {
                // open connection
                conn.Open();

                // execute and get a SqlDataReader
                var reader = cmd.ExecuteReader();

               
                if (reader.HasRows)
                {
                    // most of the time there will be a while loop
                    // here, we don't need it

                    reader.Read();
                    // [GivenName], [FamilyName],[UserName],[gender], [Email]
                    while (reader.Read())
                    {
                        UsersVM user = new UsersVM();
                        user.UserId = reader.GetInt32(0);
                        user.GenderId = reader.GetString(1);
                        user.PronounId = reader.GetString(2);
                        user.ShelterId = reader.GetInt32(3);
                        user.GivenName = reader.GetString(4);
                        user.FamilyName = reader.GetString(5);
                        user.Email = reader.GetString(6);
                        user.Address = reader.GetString(7);
                        user.AddressTwo = reader.GetString(8);
                        user.Zipcode = reader.GetString(9);
                        user.Phone = reader.GetString(10);
                        user.CreationDate = reader.GetDateTime(11);
                        user.Active = reader.GetBoolean(12);
                        user.SuspendEmployee = reader.GetBoolean(13);
                        users.Add(user);
                    }

                    
                    
                }
                // close reader
                reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return users;
        }
    }
}
