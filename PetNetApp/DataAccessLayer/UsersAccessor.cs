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
    /// <summary>
    /// Mads Rhea
    /// Created: 2023/01/27
    /// 
    /// Accessor for all tables relating to Users.
    /// </summary>
    ///
    /// <remarks>
    /// Updater Name
    /// Updated: yyyy/mm/dd
    /// </remarks>
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
        public List<UsersVM> SelectUserByRole(string roleId, int shelterId)
        {
            var users = new List<UsersVM>();

            var conn = new DBConnection().GetConnection();

            var cmdtext = "sp_select_users_by_roleId";

            var cmd = new SqlCommand(cmdtext, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@RoleId", SqlDbType.NVarChar);
            cmd.Parameters.Add("@ShelterId", SqlDbType.Int);

            cmd.Parameters["@RoleId"].Value = roleId;
            cmd.Parameters["@ShelterId"].Value = shelterId;

            try
            {
                // open connection
                conn.Open();

                // execute and get a SqlDataReader
                var reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UsersVM user = new UsersVM();
                        user.UsersId = reader.GetInt32(0);
                        user.GenderId = reader.GetString(1);
                        user.PronounId = reader.IsDBNull(2) ? null : reader.GetString(2);
                        user.ShelterId = reader.IsDBNull(3) ? null : (int?)reader.GetInt32(3);
                        user.GivenName = reader.IsDBNull(4) ? null : reader.GetString(4);
                        user.FamilyName = reader.GetString(5);
                        user.Email = reader.GetString(6);
                        user.Address = reader.IsDBNull(7) ? null : reader.GetString(7);
                        user.AddressTwo = reader.IsDBNull(8) ? null : reader.GetString(8);
                        user.Zipcode = reader.GetString(9);
                        user.Phone = reader.IsDBNull(10) ? null : reader.GetString(10);
                        user.CreationDate = reader.GetDateTime(11);
                        user.Active = reader.GetBoolean(12);
                        user.Suspend = reader.GetBoolean(13);
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
                    user.Suspend = reader.GetBoolean(13);

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

        /// <summary>
        /// [Mads Rhea - 2023/02/15]
        /// Confirms if given Email and PasswordHash match a User within the Users table.
        /// </summary>
        /// <returns>int</returns>
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

        /// <summary>
        /// [Mads Rhea - 2023/02/15]
        /// Returns user from the Users table based off of matching email.
        /// </summary>
        /// <returns>UsersVM</returns>
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
                        // nullable
                        GivenName = reader.GetString(4),
                        FamilyName = reader.GetString(5),
                        Email = reader.GetString(6),
                        Address = reader.GetString(7),
                        // nullable
                        Zipcode = reader.GetString(9),
                        Phone = reader.GetString(10),
                        CreationDate = reader.GetDateTime(11),
                        Active = reader.GetBoolean(12),
                        Suspend = reader.GetBoolean(13),
                        Roles = new List<string>()
                    };
                    if (reader.IsDBNull(3))
                    {
                        user.ShelterId = null;
                    }
                    else
                    {
                        user.ShelterId = reader.GetInt32(3);
                    }
                    if (reader.IsDBNull(8))
                    {
                        user.ShelterId = null;
                    }
                    else
                    {
                        user.AddressTwo = reader.GetString(8);
                    }
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

        /// <summary>
        /// [Mads Rhea - 2023/02/15]
        /// Returns all roles connected to the UsersId in the UserRoles table.
        /// </summary>
        /// <returns>List of strings</returns>
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

        /// <summary>
        /// [Mads Rhea - 2023/02/15]
        /// Returns all PronounId values from Pronoun table.
        /// </summary>
        /// <returns>List of strings</returns>
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

        /// <summary>
        /// [Mads Rhea - 2023/02/15]
        /// Returns all GenderId values from Gender table.
        /// </summary>
        /// <returns>List of strings</returns>
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

        /// <summary>
        /// [Alex Oetken - 2023/02/??]
        /// Injects new user into the Users table.
        /// </summary>
        /// <returns>int</returns>
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

        /// <summary>
        /// [Alex Oetken - 2023/02/??]
        /// Updates User active status to false based on UserId.
        /// </summary>
        /// <returns>int</returns>
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

        /// <summary>
        /// Zaid Rachman
        /// 2023/02/15
        /// 
        /// Selects users by users Id
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UsersVM> SelectUsersByUsersId(int usersId)
        {
            List<UsersVM> users = new List<UsersVM>();
            //connection
            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            //command text
            var cmdText = "sp_select_users_by_users_id";
            //command
            var cmd = new SqlCommand(cmdText, conn);
            //Command Type

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UsersId", SqlDbType.Int);

            cmd.Parameters["@UsersId"].Value = usersId;

            try
            {
                // open connection
                conn.Open();

                // execute and get a SqlDataReader
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        UsersVM user = new UsersVM();
                        user.UsersId = reader.GetInt32(0); users.Add(user);
                        user.GenderId = reader.GetString(1);
                        user.PronounId = reader.IsDBNull(2) ? null : reader.GetString(2);
                        user.ShelterId = reader.IsDBNull(3) ? null : (int?)reader.GetInt32(3);
                        user.GivenName = reader.IsDBNull(4) ? null : reader.GetString(4);
                        user.FamilyName = reader.GetString(5);
                        user.Email = reader.GetString(6);
                        //user.PasswordHash = reader.GetString(7);
                        user.Address = reader.IsDBNull(7) ? null : reader.GetString(7);
                        user.AddressTwo = reader.IsDBNull(8) ? null : reader.GetString(8);
                        user.Zipcode = reader.GetString(10);
                        user.Phone = reader.IsDBNull(10) ? null : reader.GetString(10);
                        user.CreationDate = reader.GetDateTime(12);
                        user.Active = reader.GetBoolean(13);
                        user.Suspend = reader.GetBoolean(14);
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
                    user.Suspend = reader.GetBoolean(13);
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
        /// <summary>
        /// By: Barry Mikulas
        /// Created: 2023/02/11
        /// </summary>
        /// <param name="UsersId"></param>
        /// <returns>UsersVM</returns>
        public UsersVM SelectUserByUsersIdWithRoles(int UsersId)
        {
            throw new NotImplementedException();
        }


        // Teft Francisco
        public int UpdateUserActive(int userId, bool active)
        {
            int rows;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_update_user_active_by_user_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UsersId", SqlDbType.Int);
            cmd.Parameters["@UsersId"].Value = userId;
            cmd.Parameters.Add("@Active", SqlDbType.Int);
            cmd.Parameters["@Active"].Value = active;


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

        /// <summary>
        /// [Mads Rhea - 2023/02/15]
        /// Injects updated user info into the Users table where the UsersId, GivenName, FamilyName, GenderId, PronounId, Address, AddressTwo, Phone, and Zipcode match.
        /// </summary>
        /// <returns>int</returns>
        public int UpdateUserDetails(Users oldUser, Users updatedUser)
        {


            int rows = 0;

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            var cmdText = "sp_update_user_details";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UsersId", oldUser.UsersId);
            cmd.Parameters.AddWithValue("@OldGivenName", oldUser.GivenName);
            cmd.Parameters.AddWithValue("@OldFamilyName", oldUser.FamilyName);
            cmd.Parameters.AddWithValue("@OldGenderId", oldUser.GenderId);
            cmd.Parameters.AddWithValue("@OldPronounId", oldUser.PronounId);
            cmd.Parameters.AddWithValue("@OldAddress", oldUser.Address);
            cmd.Parameters.AddWithValue("@OldAddressTwo", oldUser.AddressTwo);
            cmd.Parameters.AddWithValue("@OldPhone", oldUser.Phone);
            cmd.Parameters.AddWithValue("@OldZipcode", oldUser.Zipcode);

            cmd.Parameters.Add("@NewGivenName", SqlDbType.NVarChar, 50);
            cmd.Parameters["@NewGivenName"].Value = updatedUser.GivenName;
            cmd.Parameters.Add("@NewFamilyName", SqlDbType.NVarChar, 50);
            cmd.Parameters["@NewFamilyName"].Value = updatedUser.FamilyName;
            cmd.Parameters.Add("@NewGenderId", SqlDbType.NVarChar, 50);
            cmd.Parameters["@NewGenderId"].Value = updatedUser.GenderId;
            cmd.Parameters.Add("@NewPronounId", SqlDbType.NVarChar, 50);
            cmd.Parameters["@NewPronounId"].Value = updatedUser.PronounId;
            cmd.Parameters.Add("@NewAddress", SqlDbType.NVarChar, 50);
            cmd.Parameters["@NewAddress"].Value = updatedUser.Address;
            cmd.Parameters.Add("@NewAddressTwo", SqlDbType.NVarChar, 50);
            cmd.Parameters["@NewAddressTwo"].Value = updatedUser.AddressTwo;
            cmd.Parameters.Add("@NewPhone", SqlDbType.NVarChar, 13);
            cmd.Parameters["@NewPhone"].Value = updatedUser.Phone;
            cmd.Parameters.Add("@NewZipcode", SqlDbType.Char, 9);
            cmd.Parameters["@NewZipcode"].Value = updatedUser.Zipcode;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return rows;

        }

        /// <summary>
        /// [Mads Rhea - 2023/02/15]
        /// Injects updated PasswordHash into Users table where the Email and old PasswordHash match.
        /// </summary>
        /// <returns>int</returns>
        public int UpdatePasswordHash(string email, string oldPasswordHash, string newPasswordHash)
        {
            int rowsAffected = 0;

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            string cmdText = "sp_update_passwordHash";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@OldPasswordHash", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@NewPasswordHash", SqlDbType.NVarChar, 100);

            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters["@OldPasswordHash"].Value = oldPasswordHash;
            cmd.Parameters["@NewPasswordHash"].Value = newPasswordHash;

            try
            {
                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();

            }

            return rowsAffected;
        }

        /// <summary>
        /// [Mads Rhea - 2023/02/24]
        /// Updates User email in the Users table.
        /// </summary>
        /// <returns>int</returns>
        public int UpdateUserEmail(string oldEmail, string newEmail, string passwordHash)
        {
            int rowsAffected = 0;

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            string cmdText = "sp_update_user_email";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@OldEmail", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NewEmail", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);

            cmd.Parameters["@OldEmail"].Value = oldEmail;
            cmd.Parameters["@NewEmail"].Value = newEmail;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            try
            {
                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return rowsAffected;
        }

        /// <summary>
        /// [Barry Mikulas - 2023/02/26]
        /// Updates User suspended status to value sent in.
        /// </summary>
        /// <returns>int # records updated</returns>

        public int UpdateUserSuspend(int usersId, bool suspend)
        {
            int rowsAffected = 0;

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            string cmdText = "sp_update_user_suspend_by_user_id";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UsersId", SqlDbType.Int);
            cmd.Parameters.Add("@Suspended", SqlDbType.Bit);

            cmd.Parameters["@UsersId"].Value = usersId;
            cmd.Parameters["@Suspended"].Value = suspend;

            try
            {
                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return rowsAffected;
            // throw new NotImplementedException();
        }

        /// <summary>
        /// [Barry Mikulas - 2023/02/26]
        /// Returns the count of active, unsuspended accounts by roleId
        /// Used initially to check to get number of Admin roles are active, unsuspended
        /// </summary>
        /// <returns>int # of usersId matching criteria</returns>
        public int SelectCountActiveUnsuspendedUsersByRole(string roleId)
        {

            int roleCount = 0;

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();
            string cmdText = "sp_select_count_active_unsuspended_users_by_roleId";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@RoleId", SqlDbType.NVarChar, 50);

            cmd.Parameters["@RoleId"].Value = roleId;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader .Read();
                    roleCount = reader.GetInt32(0);
                    
                }
                // close reader
                reader.Close();

            }
            catch (Exception up)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return roleCount;
            // throw new NotImplementedException();
        }
    }



}



