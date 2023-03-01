using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IUsersAccessor
    {

        
        // Volunteer(Chris)
        List<UsersVM> SelectUserByRole(string roleId, int shelterId);


        /// <summary>
        ///  /// Hoang Chu
        /// Created: 2023/02/17
        /// 
        /// Select all employess
        /// </summary>
        /// <returns></returns>
        List<UsersVM> SelectAllEmployees();

        /// <summary>
        /// Teft Francisco
        /// Created: 2023/02/14
        /// 
        /// Updates a user's active status with their user ID and active status as a boolean.
        /// </summary>
        ///
        /// <remarks>
        ///
        /// </remarks>
        /// <param userId="UsersId"></param>
        /// /// <param active="Active"></param>
        int UpdateUserActive(int userId, bool active);

        // LOG IN (Mads)
        int AuthenticateUserWithEmailAndPasswordHash(string email, string passwordHash);
        UsersVM SelectUserByEmail(string email);
        List<string> SelectRolesByUserID(int userId);

        // Mads - ACCOUNT SETTINGS
        List<string> SelectAllPronouns();
        List<string> SelectAllGenders();
        int UpdateUserDetails(Users oldUser, Users updatedUser);
        int UpdatePasswordHash(string email, string oldPasswordHash, string newPasswordHash);
        int UpdateUserEmail(string oldEmail, string newEmail, string passwordHash);

        // Alex Oetken
        int CreateNewUser(Users user, string PasswordHash);
        int DeactivateUserAccount(int UserId);

        // Zaid
        List<UsersVM> SelectUsersByUsersId(int usersId);
        // Role Mgmt + Add Role
        Users SelectUserByUsersId(int UsersId);
        UsersVM SelectUserByUsersIdWithRoles(int UsersId);
    }
}
