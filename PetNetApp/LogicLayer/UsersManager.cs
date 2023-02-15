using System;
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
        public List<UsersVM> RetrieveUserByRole(string RoleId)
        {
            List<UsersVM> users = new List<UsersVM>();

            try
            {
                users = _userAccessor.SelectUserByRole(RoleId);
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
        /// <returns>List<Users></returns>

        // Mads Rhea
        // Created: 2023_02_10

        public string HashSha265(string source)
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

        public UsersVM LoginUser(string email, string password)
        {
            UsersVM user = null;

            try
            {
                password = HashSha265(password);
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

                }
                else
                {
                    throw new ApplicationException("User not found.");
                }

            }
            catch (Exception up)
            {
                throw new ApplicationException("Bad username or password.", up);
            }

            return user;
        }

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

        public bool AddUser(Users user, string Password)
        {
            bool result = false;

            Password = HashSha265(Password); 

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
    }
}
