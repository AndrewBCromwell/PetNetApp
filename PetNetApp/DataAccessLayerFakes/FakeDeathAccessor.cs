using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class FakeDeathAccessor : IDeathAccessor
    {
        private List<Death> _deaths;

        public FakeDeathAccessor()
        {
            _deaths = new List<Death>();
        }

        public int AddAnimalDOD(Death death)
        {
            int result = _deaths.Count;

            try
            {
                _deaths.Add(death);
                result = _deaths.Count - result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public int EditAnimalDOD(Death oldDeath, Death newDeath)
        {
            throw new NotImplementedException();
        }
    }
}
