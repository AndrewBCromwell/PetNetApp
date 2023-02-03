using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayerInterfaces;
using DataObjects;

namespace LogicLayer
{
    public class MasterManager
    {
        public IUserManager UserManager { get; set; }

        public MasterManager()
        {
            UserManager = new UserManager();
        }
    }
}
