using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// By: Barry Mikulas
/// Created: 2023/02/11
/// </summary>
namespace DataAccessLayerInterfaces
{
    public interface IRoleAccessor
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
        /// <returns>Rows edited</returns>
        int DeleteRoleByUsersIdAndRoleId(int usersId, string roleId);
        List<Role> SelectAllRoles();
        List<Role> SelectAllRolesByUserId(int userID);
        int InsertRoleByUsersId(Role role, int usersId);
    }
}
