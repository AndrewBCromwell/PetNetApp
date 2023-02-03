using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class UsersAccessor : IUsersAccessor
    {
        public List<Users> SelectAllEmployees()
        {
            List<Users> employeeList = new List<Users>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_all_employees";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Users user = new Users();
                    // [UsersId], [GenderId], [PronounId], [ShelterId], [GivenName], [FamilyName],
                    // [Email], [PasswordHash], [Address], [AddressTwo], [Zipcode], [Phone], [CreationDate], 
                    // [Active], [Suspended]

                    user.UsersId = reader.GetInt32(0);
                    user.GenderId = reader.GetString(1);
                    //user.PronoundId = reader.GetString(2);
                    user.ShelterId = reader.GetInt32(3);
                    user.GivenName = reader.GetString(4);
                    user.FamilyName = reader.GetString(5);
                    user.Email = reader.GetString(6);
                    user.PasswordHash = reader.GetString(7);
                    user.Address = reader.GetString(8);
                    if (reader.IsDBNull(9))
                    {
                        user.AddressTwo = null;
                    }
                    else
                    {
                        user.AddressTwo = reader.GetString(9);
                    }

                    user.Zipcode = reader.GetString(10);
                    user.Phone = reader.GetString(11);
                    user.CreationDate = reader.GetDateTime(12);
                    user.Active = reader.GetBoolean(13);
                    user.Suspended = reader.GetBoolean(14);

                    employeeList.Add(user);
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

            return employeeList;
        }
    }
}
