﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IRoleAccessor
    {
        // Created By: Asa Armstrong
        int DeleteRoleByUsersIdAndRoleId(int usersId, string roleId);
    }
}
