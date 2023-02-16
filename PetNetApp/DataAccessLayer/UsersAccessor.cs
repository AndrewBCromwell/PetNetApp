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
                        user.UsersId = reader.GetInt32(0);
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

        /// <summary>
        /// Hoang Chu
        /// Created: 2023/03/02
        /// 
        /// 
        /// </summary>
        /// Selects all users with employee role
        public List<UsersVM> SelectAllEmployees()
        {
            List<UsersVM> employeeList = new List<UsersVM>();

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
                    UsersVM user = new UsersVM();
                    // [UsersId], [GenderId], [PronounId], [ShelterId], [GivenName], [FamilyName],
                    // [Email], [PasswordHash], [Address], [AddressTwo], [Zipcode], [Phone], [CreationDate], 
                    // [Active], [Suspended]

                    user.UsersId = reader.GetInt32(0);
                    user.GenderId = reader.GetString(1);
                    if (reader.IsDBNull(2))
                    {
                        user.PronounId = "N/A";
                    }
                    else
                    {
                        user.PronounId = reader.GetString(2);
                    }
                    user.ShelterId = reader.GetInt32(3);
                    user.GivenName = reader.GetString(4);
                    user.FamilyName = reader.GetString(5);
                    user.Email = reader.GetString(6);
                    user.Address = reader.GetString(7);
                    if (reader.IsDBNull(8))
                    {
                        user.AddressTwo = null;
                    }
                    else
                    {
                        user.AddressTwo = reader.GetString(8);
                    }

                    user.Zipcode = reader.GetString(9);
                    user.Phone = reader.GetString(10);
                    user.CreationDate = reader.GetDateTime(11);
                    user.Active = reader.GetBoolean(12);
                    user.SuspendEmployee = reader.GetBoolean(13);

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

        // Mads
        public int AuthenticateUserWithEmailAndPasswordHash(string email, string passwordHash)
        {
            int result = 0;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_authenticate_user";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 254);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);

            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            try
            {
                conn.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public UsersVM SelectUserByEmail(string email)
        {

            UsersVM user = null;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_user_by_email";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 254);

            cmd.Parameters["@Email"].Value = email;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    user = new UsersVM
                    {
                        UsersId = reader.GetInt32(0),
                        GenderId = reader.GetString(1),
                        PronounId = reader.GetString(2),
                        ShelterId = reader.GetInt32(3),
                        GivenName = reader.GetString(4),
                        FamilyName = reader.GetString(5),
                        Email = reader.GetString(6),
                        Address = reader.GetString(7),
                        AddressTwo = reader.GetString(8),
                        Zipcode = reader.GetString(9),
                        Phone = reader.GetString(10),
                        Active = reader.GetBoolean(11),
                        SuspendEmployee = reader.GetBoolean(12),
                        Roles = new List<string>()
                    };
                }
                reader.Close();
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return user;
        }

        public List<string> SelectRolesByUserID(int userId)
        {
            List<string> roles = new List<string>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_roles_by_userid";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UsersId", SqlDbType.Int);

            cmd.Parameters["@UsersId"].Value = userId;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        roles.Add(reader.GetString(0));
                    }
                }
                else
                {
                    throw new ArgumentException("Cannot retrieve roles.");
                }

                reader.Close();
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return roles;
        }

        public List<string> SelectAllPronouns()
        {
            List<string> pronouns = new List<string>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_all_pronouns";

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
                        pronouns.Add(reader.GetString(0));
                    }
                }
                else
                {
                    throw new ArgumentException("Cannot retrieve pronouns.");
                }

                reader.Close();
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return pronouns;
        }

        public List<string> SelectAllGenders()
        {
            List<string> genders = new List<string>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_all_genders";

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
                        genders.Add(reader.GetString(0));
                    }
                }
                else
                {
                    throw new ArgumentException("Cannot retrieve genders.");
                }

                reader.Close();
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return genders;
        }

        public int CreateNewUser(Users user, string PasswordHash)
        {

            int rows = 0;

            //connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            //cmdText
            var cmdText = "sp_insert_new_user";

            //command
            var cmd = new SqlCommand(cmdText, conn);

            //type
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //Parameters

            cmd.Parameters.AddWithValue("@GenderId", user.GenderId);
            cmd.Parameters.AddWithValue("@PronounId", user.PronounId);
            cmd.Parameters.AddWithValue("@GivenName", user.GivenName);
            cmd.Parameters.AddWithValue("@FamilyName", user.FamilyName);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@PasswordHash", PasswordHash);
            cmd.Parameters.AddWithValue("@Zipcode", user.Zipcode);
            cmd.Parameters.AddWithValue("@Phone", user.Phone);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        public int DeactivateUserAccount(int UserId)
        {
            int rows = 0;

            DBConnection connectionFactory = new DBConnection();

            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_deactivate_account";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UsersId", SqlDbType.Int);
            cmd.Parameters["@UsersId"].Value = UserId;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        // Barry
        /// <summary>
        /// Barry Mikukas
        /// Created: 2023/02/09
        /// 
        /// 
        /// </summary>
        /// Selects users with a given UsersId
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// 
        /// </remarks>
        /// <param usersId="UsersId"></param>
        public Users SelectUserByUsersId(int UsersId)
        {
            var user = new Users();

            var conn = new DBConnection().GetConnection();

            var cmdtext = "sp_select_user_by_usersId";

            var cmd = new SqlCommand(cmdtext, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UsersId", SqlDbType.Int);

            cmd.Parameters["@UsersId"].Value = UsersId;

            try
            {
                // open connection
                conn.Open();

                // execute and get a SqlDataReader
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    //// [GivenName], [FamilyName],[UserName],[gender], [Email]
                    //while (reader.Read())
                    //{
                    user.UsersId = reader.GetInt32(0);
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
                    //}
                }
                // close reader
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;

            //throw new NotImplementedException();
        }

        public UsersVM SelectUserByUsersIdWithRoles(int UsersId)
        {
            throw new NotImplementedException();
        }
    }

}



