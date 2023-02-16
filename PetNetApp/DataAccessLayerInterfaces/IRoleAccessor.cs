using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayerInterfaces
{
    public interface IRoleAccessor
    {
        List<Role> SelectAllRoles();
        List<Role> SelectAllRolesByUserId(int userID);
        int InsertRoleByUsersId(Role role, int usersId);
    }
}
