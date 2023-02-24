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
    }
}
