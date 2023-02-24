﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using DataAccessLayer;
using DataAccessLayerFakes;
using System.Security.Cryptography;

namespace LogicLayer
{
    /// <summary>
    /// Mads Rhea
    /// Created: 2023/01/27
    /// 
    /// Logic layer manager for Users.
    /// </summary>
    ///
    /// <remarks>
    /// Updater Name
    /// Updated: yyyy/mm/dd
    /// </remarks>

    public class UsersManager : IUsersManager
    {
        IUsersAccessor _userAccessor = null;

        public UsersManager()
        {
            _userAccessor = new UsersAccessor();
        }

        public UsersManager(IUsersAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }


        /// <summary>
        /// Chris Dreismeier
        /// Created: 2023/03/02
        /// 
        /// 
        /// </summary>
        /// Retrieves all users with a certain role
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="RoleId"></param>
        public List<UsersVM> RetrieveUserByRole(string roleId, int shelterId)
        {
            List<UsersVM> users = new List<UsersVM>();

            try
            {
                users = _userAccessor.SelectUserByRole(roleId,shelterId);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return users;
        }

        /// Hoang Chu
        /// Created: 2023/02/01
        ///         
        /// <returns>List<Users></returns>
        public List<UsersVM> RetriveAllEmployees()
        {
            List<UsersVM> employeeList = null;

            try
            {
                employeeList = _userAccessor.SelectAllEmployees();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found", ex);
            }

            return employeeList;
        }

        /// <summary>
        /// [Mads Rhea - 2023/02/10]
        /// Converts string into a HashSha256
        /// </summary>
        /// <returns>string</returns>
        public string HashSha256(string source)
        {
            string result = "";

            if (source == null || source == "")
            {
                throw new ArgumentNullException("Missing input");
            }

            byte[] data;

            using (SHA256 sha256hasher = SHA256.Create())
            {
                data = sha256hasher.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            var s = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            result = s.ToString();

            return result;
        }

        /// <summary>
        /// [Mads Rhea - 2023/02/10]
        /// Passes Email and Password and returns a UsersVM if values match a record found within the Users table.
        /// </summary>
        /// <returns>UsersVM</returns>
        public UsersVM LoginUser(string email, string password)
        {
            UsersVM user = null;

            try
            {
                password = HashSha256(password);
                if (1 == _userAccessor.AuthenticateUserWithEmailAndPasswordHash(email, password))
                {
                    user = _userAccessor.SelectUserByEmail(email);
                    try
                    {
                        user.Roles = _userAccessor.SelectRolesByUserID(user.UsersId);
                    }
                    catch (Exception up)
                    {
                        throw new ApplicationException("Unable to load roles for user.", up);
                    }
                    if (user.Roles.Count == 0)
                    {
                        throw new ApplicationException("You don't have permissions to use this application");
                    }
                }
                else
                {
                    throw new ApplicationException("Bad username or password.");
                }

            }
            catch (Exception up)
            {
                throw new ApplicationException("Something went wrong logging you in.", up);
            }

            return user;
        }

        /// <summary>
        /// [Mads Rhea - 2023/02/10]
        /// Returns all entries from Gender table.
        /// </summary>
        /// <returns>List of strings</returns>
        public List<string> RetrieveGenders()
        {
            List<string> genders = new List<string>();

            try
            {
                genders = _userAccessor.SelectAllGenders();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return genders;
        }

        /// <summary>
        /// [Mads Rhea - 2023/02/10]
        /// Returns all entries from Pronoun table.
        /// </summary>
        /// <returns>List of strings</returns>
        public List<string> RetrievePronouns()
        {
            List<string> pronouns = new List<string>();

            try
            {
                pronouns = _userAccessor.SelectAllPronouns();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return pronouns;
        }

        /// <summary>
        /// [Mads Rhea - 2023/02/10]
        /// Injects updated User details into the Users table.
        /// </summary>
        /// <returns>bool</returns>
        public bool EditUserDetails(Users oldUser, Users updatedUser)
        {
            bool result = false;

            try
            {
                result = 1 == _userAccessor.UpdateUserDetails(oldUser, updatedUser);
            }
            catch (Exception up)
            {

                throw up;
            }

            return result;
        }

        /// <summary>
        /// [Mads Rhea - 2023/02/10]
        /// Injects updated User Password into the Users table.
        /// </summary>
        /// <returns>bool</returns>
        public bool ResetPassword(string email, string oldPassword, string newPassword)
        {
            bool result = false;

            try
            {
                result = 1 == _userAccessor.UpdatePasswordHash(email, HashSha256(oldPassword), HashSha256(newPassword));

            }
            catch (Exception up)
            {

                throw new ApplicationException("Incorrect password", up);
            }

            return result;
        }

        /// <summary>
        /// [Alex Oetken - 2023/02/??]
        /// Updates User in the Users table to inactive.
        /// </summary>
        /// <returns>int</returns>
        public bool DeactivateUserAccount(int UserId)
        {
            bool result = false;

            try
            {
                result = (1 == _userAccessor.DeactivateUserAccount(UserId));
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        /// <summary>
        /// [Alex Oetken - 2023/02/??]
        /// Injects new User into the Users table.
        /// </summary>
        /// <returns>int</returns>
        public bool AddUser(Users user, string Password)
        {
            bool result = false;

            Password = HashSha256(Password);

            try
            {
                result = (1 == _userAccessor.CreateNewUser(user, Password));
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public List<UsersVM> RetrieveUsersByUsersId(int usersId)
        {
            List<UsersVM> usersList = new List<UsersVM>();

            try
            {
                usersList = _userAccessor.SelectUsersByUsersId(usersId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("User not found", ex);
            }
            return usersList;
        }
        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/02/09
        /// 
        /// 
        /// </summary>
        /// Retrieves a users with given usersId
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// 
        /// </remarks>
        /// <param usersId="UsersId"></param>
        /// 
        public Users RetrieveUserByUsersId(int UsersId)
        {
            //throw new NotImplementedException();

            Users _user = new Users();
            try
            {
                _user = _userAccessor.SelectUserByUsersId(UsersId);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not found", ex);
            }
            return _user;

        }

        // Teft Francisco
        public int EditUserActive(int userId, bool active)
        {
            int result = 0;
            try
            {
                if (1 == _userAccessor.UpdateUserActive(userId, active))
                {
                    result = 1;
                }
                return result;
            }
            catch (Exception e)
            {
                throw new ApplicationException("An error has occured", e);
            }
        }

        /// <summary>
        /// [Mads Rhea - 2023/02/24]
        /// Updates User email in the Users table.
        /// </summary>
        /// <returns>bool</returns>
        public bool UpdateEmail(string oldEmail, string newEmail, string passwordHash)
        {
            bool result = false;

            passwordHash = HashSha256(passwordHash);
            if (1 == _userAccessor.AuthenticateUserWithEmailAndPasswordHash(oldEmail, passwordHash))
            {
                try
                {
                    result = 1 == _userAccessor.UpdateUserEmail(oldEmail, newEmail, passwordHash);
                }
                catch (Exception up)
                {
                    throw new ApplicationException("Unable to update user email.", up);
                }
            }

            return result;
        }
    }
}
