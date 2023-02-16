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
        List<UsersVM> RetrieveUserByRole(string RoleId);
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
    }
}
