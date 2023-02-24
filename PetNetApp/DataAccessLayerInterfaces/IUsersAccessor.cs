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
        // Chris
        List<UsersVM> SelectUserByRole(string RoleId);

        // Hoang
        List<UsersVM> SelectAllEmployees();

        // Mads - LOG IN
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
    }
}
