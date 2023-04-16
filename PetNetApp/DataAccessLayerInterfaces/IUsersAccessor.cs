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
        List<string> SelectAllRoles();
        UsersVM AuthenticateUser(string email, string passwordHash);
        int InsertOrDeleteUserRole(int usersId, string role, bool delete = false);

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
        /// <summary>
        /// Zaid Rachman
        /// Created: 2023/02/12
        /// 
        /// Takes a list of usersVM by the userID
        /// </summary>
        /// <remarks>
        /// Oleksiy Fedchuk
        /// Updated: 2023/04/13
        /// 
        /// FinalQA
        /// </remarks>
        List<UsersVM> SelectUsersByUsersId(int usersId);

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/02/12
        /// 
        /// Takes a usersId and returns a users object
        /// </summary>
        /// <param name="usersId">The userId being retrieved</param>
        /// <returns>Users object</returns>
        Users SelectUserByUsersId(int usersId);

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/02/12
        /// 
        /// Takes a usersId and returns a users object
        /// </summary>
        /// <param name="usersId">The userId being retrieved</param>
        /// <returns>UsersVM object</returns>
        UsersVM SelectUserByUsersIdWithRoles(int usersId);

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/02/26
        /// 
        /// Takes a usersId and changes the suspend status to the value of suspend parameter
        /// </summary>
        /// <param name="usersId">The userId being updated</param>
        /// <param name="suspend">True if suspending, false if unsuspending</param>
        /// <returns>int count of updated users - should be 1</returns>
        int UpdateUserSuspend(int usersId, bool suspend);

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/02/26
        /// 
        /// Takes a roleId and counts the number active, unsuspended accounts with that roleId
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>int count of accounts</returns>
        int SelectCountActiveUnsuspendedUsersByRole(string roleId);

        /// <summary>
        /// Teft Francisco
        /// Created: 2023/03/03
        /// 
        /// Takes a user's user id and returns previous adoption records associated with that user.
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>int count of accounts</returns>
        List<UsersAdoptionRecords> SelectAdoptionRecordsByUserID(int usersId);
        /// <summary>
        /// Chris Dreismeier
        /// Created: 2023/04/13
        /// 
        /// takes in a userid and shelterid and assigns that shelterid to the user
        /// </summary>
        /// <param name="shelterid"></param>
        /// <param name="userid"></param>
        /// <returns>int count rows affected</returns>
        int UpdateUserShelterid(int userid, int shelterid, int oldShelterId);
    }
}
