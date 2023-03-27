/// <summary>
/// Barry Mikulas
/// Created: 2023/03/01
/// 
/// Methods for Institutional Entity 
/// </summary>
///
/// <remarks>
/// Updater
/// Updated: 
/// Comments:
/// </remarks>
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
    public class InstitutionalEntityManager : IInstitutionalEntityManager
    {

        private IInstitutionalEntityAccessor _institutionalEntityAccessor = null;


        public InstitutionalEntityManager()
        {
            _institutionalEntityAccessor = new InstitutionalEntityAccessor();
        }
        public InstitutionalEntityManager(IInstitutionalEntityAccessor institutionalEntityAccessor)
        {
            _institutionalEntityAccessor = institutionalEntityAccessor;
        }

        public List<InstitutionalEntity> RetrieveAllInstitutionalEntitiesByShelterIdAndContactType(int shelterId, string contactType)
        {
            List<InstitutionalEntity> institutionalEntities = new List<InstitutionalEntity>();
            try
            {
                institutionalEntities = _institutionalEntityAccessor.SelectAllInstitutionalEntitiesByShelterIdAndContactType(shelterId, contactType);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return institutionalEntities;
        }

        public InstitutionalEntity RetrieveInstitutionalEntityByInstitutionalEntityId(int institutionalEntityId)
        {
            throw new NotImplementedException();
        }
    }
}