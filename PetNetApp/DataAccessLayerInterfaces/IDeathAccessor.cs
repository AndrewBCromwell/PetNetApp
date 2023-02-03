using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IDeathAccessor
    {
        int AddAnimalDOD(Death death);
        int EditAnimalDOD(Death oldDeath, Death newDeath);
    }
}
