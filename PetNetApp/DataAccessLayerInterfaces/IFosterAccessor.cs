using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces
{
    public interface IFosterAccessor
    {
        int SelectNumberOfAnimalsApprovedByUsersId(int usersId);
        int SelectNumberOfAnimalsFostererHasByUsersId(int usersId);
        int UpdateCurrentlyAcceptingAnimalsByUsersId(int usersId, bool onOff);
        bool SelectCurrentlyAcceptingAnimalsByUsersId(int usersId);
    }
}
