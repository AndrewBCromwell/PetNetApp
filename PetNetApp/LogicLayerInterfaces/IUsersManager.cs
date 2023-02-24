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

        // Mads Rhea
        UsersVM LoginUser(string email, string password);
        string HashSha256(string source);
        List<string> RetrieveGenders();
        List<string> RetrievePronouns();
        bool EditUserDetails(Users oldUser, Users updatedUser);
        bool ResetPassword(string email, string oldPassword, string newPassword);
        bool UpdateEmail(string oldEmail, string newEmail, string passwordHash);

        // Alex Oetken
        bool DeactivateUserAccount(int UserId);
        bool AddUser(Users user, string password);
    }
}
