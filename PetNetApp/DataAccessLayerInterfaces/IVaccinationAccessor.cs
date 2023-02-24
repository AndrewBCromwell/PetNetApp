using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IVaccinationAccessor
    {
        int InsertVaccination(Vaccination vaccination, int animalId);
        List<Vaccination> SelectVaccinationsByAnimalId(int animalId);
        int UpdateVaccination(Vaccination oldVaccination, Vaccination newVaccination);
    }
}
