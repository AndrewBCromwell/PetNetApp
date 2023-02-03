using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;
using DataAccessLayer;
using LogicLayerInterfaces;

namespace LogicLayer
{
    public class DeathManager : IDeathManager
    {
        private IDeathAccessor _deathAccessor = null;

        public DeathManager()
        {
            _deathAccessor = new DeathAccessor();
        }

        public DeathManager(IDeathAccessor deathAccessor)
        {
            _deathAccessor = deathAccessor;
        }

        public bool AddAnimalDOD(Death death)
        {
            bool wasAdded = false;

            try
            {
                wasAdded = (0 < _deathAccessor.AddAnimalDOD(death));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return wasAdded;
        }

        public bool EditAnimalDOD(Death oldDeath, Death newDeath)
        {
            throw new NotImplementedException();
        }
    }
}
