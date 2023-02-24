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

        // Barry
        Users RetrieveUserByUsersId(int UsersId);

        // Mads
        UsersVM LoginUser(string email, string password);
        string HashSha265(string source);
        List<string> RetrieveGenders();
        List<string> RetrievePronouns();
        bool DeactivateUserAccount(int UserId);
        bool AddUser(Users user, string password);

        // Zaid Rachman

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
    }
}
