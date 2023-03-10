/// <summary>
/// Zaid Rachman
/// Created: 2023/02/09
/// 
/// Logic layer for VaccinationManager.
/// Methods:
/// AddVaccination
/// EditVaccination
/// RetrieveVaccinationsByAnimalId
/// </summary>
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayer;
using DataAccessLayerInterfaces;

namespace LogicLayer
{
    public class VaccinationManager : IVaccinationManager
    {
        private IVaccinationAccessor vaccinationAccessor = null;
        public VaccinationManager()
        {
            vaccinationAccessor = new VaccinationAccessor();
        }
        public VaccinationManager(IVaccinationAccessor vaccineAccessor)
        {
            vaccinationAccessor = vaccineAccessor;
        }
        /// <summary>
        /// Zaid Rachman
        /// 2023/02/11
        /// 
        /// Logic for AddVaccination.
        /// </summary>
        /// <param name="vaccine"></param>
        /// <param name="animalId"></param>
        /// <returns></returns>
        public bool AddVaccination(Vaccination vaccine, int animalId)
        {
            bool result = false;
            try
            {
                result = (1 == vaccinationAccessor.InsertVaccination(vaccine, animalId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// Zaid Rachman
        /// 2023/02/11
        /// 
        /// Logic for EditVaccination
        /// </summary>
        /// <param name="oldVaccine"></param>
        /// <param name="newVaccine"></param>
        /// <returns></returns>
        public bool EditVaccination(Vaccination oldVaccine, Vaccination newVaccine)
        {
            bool result = false;
            try
            {
                result = (1 == vaccinationAccessor.UpdateVaccination(oldVaccine, newVaccine));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public VaccinationVM RetrieveVaccinationByMedicalRecordId(int medicalRecordId)
        {
            VaccinationVM vaccination = null;
            try
            {
                vaccination = vaccinationAccessor.SelectVaccinationByMedicalRecordId(medicalRecordId);
            }
            catch (Exception up)
            {
                throw new ApplicationException("Data not found.", up);
            }
            return vaccination;
        }

        /// <summary>
        /// Zaid Rachman
        /// 2023/02/11
        /// 
        /// Logic for RetrieveVaccinationsByAnimalId
        /// </summary>
        /// <param name="animalId"></param>
        /// <returns></returns>
        public List<Vaccination> RetrieveVaccinationsByAnimalId(int animalId)
        {
            List<Vaccination> vaccinations = null;
            try
            {
                vaccinations = vaccinationAccessor.SelectVaccinationsByAnimalId(animalId);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not found", ex);
            }
            return vaccinations;
        }
    }
}
