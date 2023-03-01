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
        // Created By: Asa Armstrong
        bool RemoveRoleByUsersIdAndRoleId(int usersId, string roleId);
        
        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/02/11
        /// 
        /// Retrieves a List of Role objects
        /// </summary>
        /// <returns>List of Role Objects</returns>
        List<Role> RetrieveAllRoles();

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/02/11
        /// 
        /// Retrieves a List of Role objects for a usersId
        /// </summary>
        /// <param name="usersId"></param>
        /// <returns>List of Role Objects</returns>
        List<Role> RetrieveRoleListByUserId(int usersId);

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/02/11
        /// 
        /// Adds a role for a users.
        /// </summary>
        /// <param name="role">Role object</param>
        /// <param name="usersId">int for usersId</param>
        /// <returns>bool of success of adding the role for a user</returns>
        bool AddRoleByUsersId(Role role, int usersId);
    }
}
