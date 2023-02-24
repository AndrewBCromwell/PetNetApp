using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IScheduleAccessor
    {
        List<ScheduleVM> SelectScheduleByDate(DateTime selectedDate);
        List<ScheduleVM> SelectScheduleByUser(int userId);
    }
}
