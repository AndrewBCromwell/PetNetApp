using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IFosterManager
    {
        int RetrieveNumberOfAnimalsApprovedByUsersId(int usersId);
        int RetrieveNumberOfAnimalsFostererHasByUsersId(int usersId);
        int EditCurrentlyAcceptingAnimalsByUsersId(int usersId, bool onOff);
        bool RetrieveCurrentlyAcceptingAnimalsByUsersId(int usersId);

    }
}
