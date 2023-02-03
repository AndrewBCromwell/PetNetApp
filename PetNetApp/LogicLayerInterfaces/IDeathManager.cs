using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IDeathManager
    {
        bool AddAnimalDOD(Death death);
        bool EditAnimalDOD(Death oldDeath, Death newDeath);
    }
}
