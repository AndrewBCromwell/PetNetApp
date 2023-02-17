using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    public class RoleManager : IRoleManager
    {
        private IRoleAccessor _roleAccessor = null;

        public RoleManager()
        {
            _roleAccessor = new RoleAccessor();
        }

        public RoleManager(IRoleAccessor roleAccessor)
        {
            _roleAccessor = roleAccessor;
        }

        // Created By: Asa Armstrong
        public bool RemoveRoleByUsersIdAndRoleId(int usersId, string roleId)
        {
            bool wasRemoved = false;

            try
            {
                int rowsAffected = _roleAccessor.DeleteRoleByUsersIdAndRoleId(usersId, roleId);
                if (rowsAffected > 0)
                {
                    wasRemoved = true;
                }
                else if (rowsAffected == -1)
                {
                    throw new ApplicationException("Cannot remove the last 'Admin' Role.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return wasRemoved;
        }
    }
}
