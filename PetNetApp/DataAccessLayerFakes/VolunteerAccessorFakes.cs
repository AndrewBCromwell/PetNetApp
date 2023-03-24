/// <summary>
/// Oleksiy Fedchuk
/// Created: 2023/02/24
/// 
/// 
/// Class for the creation of Volunteer Accessor Fakes
/// </summary>
/// 
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
using DataAccessLayerInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerFakes
{
    public class VolunteerAccessorFakes : IVolunteerAccessor
    {
        List<VolunteerVM> volunteers = new List<VolunteerVM>();
        List<VolunteerVM> fakeVolunteers = new List<VolunteerVM>();

        public VolunteerAccessorFakes()
        {
            fakeVolunteers.Add(new VolunteerVM
            {
                UsersId = 100000,
                FundraisingEventId = 100000
            });
            fakeVolunteers.Add(new VolunteerVM
            {
                UsersId = 100001,
                FundraisingEventId = 100000
            });
            fakeVolunteers.Add(new VolunteerVM
            {
                UsersId = 100002,
                FundraisingEventId = 100000
            });
            fakeVolunteers.Add(new VolunteerVM
            {
                UsersId = 100002,
                FundraisingEventId = 100001
            });
            fakeVolunteers.Add(new VolunteerVM
            {
                UsersId = 100003,
                FundraisingEventId = 100001
            });
        }

        public List<VolunteerVM> SelectVolunteersbyFundraisingEventId(int fundraisingEventId)
        {
            return fakeVolunteers.Where(v => v.FundraisingEventId == fundraisingEventId).ToList();
        }
    }
}
