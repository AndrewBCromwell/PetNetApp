using DataAccessLayer;
using DataAccessLayerInterfaces;
using DataObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerFakes;

namespace LogicLayer
{
    public class KennelManager : IKennelManager
    {
        private IKennelAccessor kennelAccessor = null;

        public KennelManager()
        {
            kennelAccessor = new KennelAccessor();
        }

        public KennelManager(IKennelAccessor ka)
        {
            kennelAccessor = ka;
        }

        public bool AddKennel(Kennel kennel)
        {
            int result = 0;
            try
            {
                result = kennelAccessor.InsertKennel(kennel);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Kennel failed to be added", ex);
            }
            return result == 1;
        }

        public bool EditKennelStatusByKennelId(int KennelId)
        {
            int result = 0;
            try
            {
                result = kennelAccessor.UpdateKennelStatusByKennelId(KennelId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Kennel failed to be edited", ex);
            }
            return result == 1;
        }

        public bool RemoveAnimalKennlingByKennelId(int KennelId)
        {
            int result = 0;
            try
            {
                result = kennelAccessor.DeleteAnimalKennelingByKennelId(KennelId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to remove animal from kennel", ex);
            }
            return result == 1;
        }

        public List<string> RetrieveAnimalTypes()
        {
            try
            {
                return kennelAccessor.SelectAnimalTypes();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Failed to retrieve animal types", e);
            }
        }

        public List<KennelVM> RetrieveKennels(int ShelterId)
        {
            try
            {
                return kennelAccessor.SelectKennels(ShelterId);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Failed to retrieve kennels", e);
            }
                      
        }

        public Kennel RetrieveKennelIdByAnimalId(int AnimalId)
        {
            try
            {
                return kennelAccessor.SelectKennelIdByAnimalId(AnimalId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve kennel", ex);
            }
        }

        public bool AddAnimalIntoKennelByAnimalId(int KennelId, int AnimalId)
        {
            try
            {
                return 0 < kennelAccessor.InsertAnimalIntoKennelByAnimalId(KennelId, AnimalId);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to insert animal into kennel", ex);
            }
        }

        public List<Animal> RetrieveAllAnimalsForKennel(int ShelterId)
        {
            try
            {
                return kennelAccessor.SelectAllAnimalsForKennel(ShelterId);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to retrieve animals.", ex);
            }
        }

        // Created By: Asa Armstrong
        public bool RemoveAnimalKennelingByKennelIdAndAnimalId(int kennelId, int animalId)
        {
            try
            {
                return (0 < kennelAccessor.DeleteAnimalKennelingByKennelIdAndAnimalId(kennelId, animalId));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could not delete animal kenneling.", ex);
            }
        }
    }
}
