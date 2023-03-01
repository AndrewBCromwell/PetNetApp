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
        // Created By: Asa Armstrong
        int DeleteRoleByUsersIdAndRoleId(int usersId, string roleId);

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/02/11
        /// 
        /// Retrieves a list of all Role objects
        /// </summary>
        /// <returns>List of Role objects</returns>
        List<Role> SelectAllRoles();

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/02/11
        /// 
        /// Takes a usersId and returns a List of Role objects
        /// </summary>
        /// <param name="usersId">The userId being retrieved</param>
        /// <returns>List of Role objects</returns>
        List<Role> SelectAllRolesByUserId(int userID);

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/02/11
        /// 
        /// Takes a usersId and a Role obj and updates the UserRole table
        /// </summary>
        /// <param name="usersId">The userId being retrieved</param>
        /// <param name="role">Role object</param>
        /// <returns>int count of records inserted - will be 1 unless error</returns>
        int InsertRoleByUsersId(Role role, int usersId);
    }
}
