using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IRoleManager
    {
        /// <summary>
        /// Asa Armstrong
        /// Created: 2023/02/24
        /// 
        /// Deletes the role assigned to a user by the user's Id and role's Id.
        /// </summary>
        ///
        /// <remarks>
        /// Asa Armstrong
        /// Updated: 2023/02/24
        /// Added Comment.
        /// </remarks>
        /// <param name="usersId">usersId</param>
        /// <param name="roleId">roleId</param>
        /// <exception cref="SQLException">Delete fails.</exception>
        /// <returns>True if the record was removed</returns>
        bool RemoveRoleByUsersIdAndRoleId(int usersId, string roleId);
        // created by Barry Mikulas
        List<Role> RetrieveAllRoles();
        List<Role> RetrieveRoleListByUserId(int usersId);
        bool AddRoleByUsersId(Role role, int usersId);
    }
}
