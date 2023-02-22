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
        // created by Barry Mikulas
        List<Role> RetrieveAllRoles();
        List<Role> RetrieveRoleListByUserId(int usersId);
        bool AddRoleByUsersId(Role role, int usersId);
    }
}
