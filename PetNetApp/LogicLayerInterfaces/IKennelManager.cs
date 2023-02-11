using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IKennelManager
    {
        List<KennelVM> RetrieveKennels(int ShelterId);
        List<string> RetrieveAnimalTypes();
        bool AddKennel(Kennel kennel);
        bool EditKennelStatusByKennelId(int KennelId);
        bool RemoveAnimalKennlingByKennelId(int KennelId);
    }
}
