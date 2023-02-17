using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class RoleAccessorFakes : IRoleAccessor
    {
        List<UserRoles> _userRoles = new List<UserRoles>();
        
        public RoleAccessorFakes()
        {
            _userRoles.Add(new UserRoles(){ UsersId = 100000, RoleId = "Admin" });
            _userRoles.Add(new UserRoles(){ UsersId = 100001, RoleId = "Admin" });
            _userRoles.Add(new UserRoles(){ UsersId = 100000, RoleId = "Vet" });
        }

        // Created By: Asa Armstrong
        public int DeleteRoleByUsersIdAndRoleId(int usersId, string roleId)
        {
            int rowsAffected = 0;

            try
            {
                if ( !roleId.Equals("Admin") || ("Admin".Equals(roleId) && _userRoles.FindAll(ur => ur.RoleId == "Admin").Count > 1))
                {
                    if (_userRoles.Remove(_userRoles.FirstOrDefault(ur => ur.RoleId == roleId && ur.UsersId == usersId)))
                    {
                        rowsAffected++;
                    }
                }
                else
                {
                    rowsAffected = -1; // there is only one admin and won't delete
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowsAffected;
        }
    }
}
