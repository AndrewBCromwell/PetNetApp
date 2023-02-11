using DataAccessLayer;
using DataAccessLayerInterfaces;
using DataObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                throw new ApplicationException("Kennel failed to be removed", ex);
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
                throw new ApplicationException("Failed to remove an from kennel", ex);
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

        /// <summary>
        /// Gwen Arman
        /// Created: 2023/02/01
        /// 
        /// Methods rewraps SelectKennels method
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="ShelterId">A description of the parameter that this method takes</param>
        /// <exception cref="ApplicationException"></exception>
        /// <returns>List<KennelVM></returns>
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
    }
}
