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
        List<UsersVM> SelectUserByRole(string RoleId);

        /// <summary>
        ///  /// Hoang Chu
        /// Created: 2023/02/17
        /// 
        /// Select all employess
        /// </summary>
        /// <returns></returns>
        List<UsersVM> SelectAllEmployees();

        // LOG IN (Mads)
        int AuthenticateUserWithEmailAndPasswordHash(string email, string passwordHash);
        UsersVM SelectUserByEmail(string email);
        List<string> SelectRolesByUserID(int userId);

        // ACCOUNT SETTINGS (Mads)
        List<string> SelectAllPronouns();
        List<string> SelectAllGenders();
    }
}
