/// <summary>
/// Oleksiy Fedchuk
/// Created: 2023/02/24
/// 
/// 
/// Logic Layer for Volunteer
/// </summary>
/// 
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
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
    public class VolunteerManager : IVolunteerManager
    {
        private IVolunteerAccessor _volunteerAccessor = null;

        public VolunteerManager()
        {
            _volunteerAccessor = new VolunteerAccessor();
        }

        public VolunteerManager(IVolunteerAccessor volunteerAccessor)
        {
            _volunteerAccessor = volunteerAccessor;
        }
        public List<VolunteerVM> RetrieveVolunteersbyFundraisingEventId(int fundraisingEventId)
        {
            List<VolunteerVM> volunteers = null;

            try
            {
                volunteers = _volunteerAccessor.SelectVolunteersbyFundraisingEventId(fundraisingEventId);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not found.", ex);
            }

            return volunteers;
        }
    }
}
