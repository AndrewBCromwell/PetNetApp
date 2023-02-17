using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IRoleManager
    {
        // created by Barry Mikulas
        List<Role> RetrieveAllRoles();
        List<Role> RetrieveRoleListByUserId(int usersId);
        bool AddRoleByUsersId(Role role, int usersId);
    }
}
