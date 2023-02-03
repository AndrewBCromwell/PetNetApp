using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayerInterfaces;

namespace LogicLayer
{
    public class MasterManager
    {
        public IUsersManager UsersManager { get; set; }
        public MasterManager()
        {
            UsersManager = new UsersManager();
        }
    }
}
