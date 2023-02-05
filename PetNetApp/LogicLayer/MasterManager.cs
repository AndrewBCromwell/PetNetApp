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
        public IAnimalManager AnimalManager { get; set; }
        public MasterManager()
        {
            AnimalManager = new AnimalManager();
        }
    }
}
