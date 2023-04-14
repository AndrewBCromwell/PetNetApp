using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IUsersManager
    {
        List<UsersVM> RetrieveUserByRole(string roleId, int shelterId);
        List<UsersVM> RetriveAllEmployees();

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/02/23
        /// 
        /// </summary>
        /// <remarks>
        /// Oleksiy Fedchuk
        /// Updated: 2023/04/14
        /// 
        /// FinalQA
        /// </remarks>
        /// <param name="UsersId"></param>
        /// <returns></returns>
        Users RetrieveUserByUsersId(int UsersId);
        /// <summary>
        /// created 02/26/2023
        /// created by Barry Mikulas
        /// Sets user account suspend status to true
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns>bool of success status</returns>
        bool SuspendUserAccount(int UserId);
        /// <summary>
        /// created 02/26/2023
        /// created by Barry Mikulas
        /// Sets user account suspend status to false
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns>bool of success status</returns>
        bool UnsuspendUserAccount(int UserId);
        /// <summary>
        /// created 02/26/2023
        /// created by Barry Mikulas
        /// Returns count of active\unsuspended users for a given role type
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns>int</returns>
        int RetrieveCountActiveUnsuspendUserAccountsByRoleId(string RoleId);

        // Mads
        UsersVM LoginUser(string email, string password);
        string HashSha256(string source);
        List<string> RetrieveGenders();
        List<string> RetrievePronouns();
        bool EditUserDetails(Users oldUser, Users updatedUser);
        bool ResetPassword(string email, string oldPassword, string newPassword);
        bool UpdateEmail(string oldEmail, string newEmail, string passwordHash);
        List<string> RetrieveAllRoles();
        List<string> RetrieveRolesByUsersId(int usersId);
        bool RetrieveUserByEmail(string email);
        UsersVM AuthenticateUser(string email, string passwordHash);

        // Alex Oetken
        bool DeactivateUserAccount(int UserId);
        bool AddUser(Users user, string password);

        /// <summary>
        /// 
        /// Zaid Rachman
        /// Created: 2023/02/15
        /// Retrieves list of users by userId
        /// Used to see if user exists.
        /// 
        /// 
        /// </summary>
        ///  <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// 
        /// <param name="usersId"></param>
        /// <returns></returns>
        List<UsersVM> RetrieveUsersByUsersId(int usersId);

        /// <summary>
        /// Teft Francisco
        /// Created: 2023/02/14
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
        /// <param userId="UsersId"></param>
        /// <param active="Active"></param
        int EditUserActive(int userId, bool active);

        
      
        /// <summary>
        /// Chris Dreismeier
        /// Created: 2023/04/13
        /// 
        /// Updates users shelterid
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// 
        /// </remarks>
        /// <param name="usersId"></param>
        /// <param name="shelterId"></param>
        /// <param name="oldShelterId"></param>
        bool EditUserShelterId(int userId, int shelterId, int oldShelterId);

        /// Teft Francisco
        /// Created: 2023/02/14
        /// 
        /// 
        /// </summary>
        /// Retrieves a user's adoption records by their user ID.
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// 
        /// </remarks>
        /// <param userId="usersId"></param>
        List<UsersAdoptionRecords> RetrieveAdoptionRecordsByUserID(int usersId);
        UsersVM RetrieveUserByUserEmail(string email);
    }
}
