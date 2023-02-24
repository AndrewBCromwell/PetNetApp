using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IVaccinationManager
    {
        bool AddVaccination(Vaccination vaccine, int animalId);
        List<Vaccination> RetrieveVaccinationsByAnimalId(int animalId);
        bool EditVaccination(Vaccination oldVaccine, Vaccination newVaccine);
    }
}
