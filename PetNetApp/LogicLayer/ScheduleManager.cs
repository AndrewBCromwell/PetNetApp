﻿/// <summary>
/// Chris Dreismeier
/// Created: 2023/02/09
/// 
/// 
/// Class for interation bewtween Accessor Layer and Presentaion Layer
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
using DataAccessLayerInterfaces;
using DataAccessLayer;
using DataAccessLayerFakes;


namespace LogicLayer
{
    public class ScheduleManager : IScheduleManager
    {
        private IScheduleAccessor _scheduleAccessor = null;
        public ScheduleManager()
        {
            _scheduleAccessor = new ScheduleAccessor();
        }

        public ScheduleManager(IScheduleAccessor scheduleAccessor)
        {
            _scheduleAccessor = scheduleAccessor;
        }

        public bool AddSchedulebyUserId(ScheduleVM scheduleVM)
        {
            bool wasAdded = false;

            try
            {
                wasAdded = 0 < _scheduleAccessor.InsertSchedulebyUserid(scheduleVM);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return wasAdded;
        }
        public List<ScheduleVM> RetrieveScheduleByDate(DateTime selectedDate)
        {
            List<ScheduleVM> schedules = null;
            try
            {
                schedules = _scheduleAccessor.SelectScheduleByDate(selectedDate);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error Retrieving schedule data.", ex);
            }
            return schedules;
        }
        public List<ScheduleVM> RetrieveScheduleByUserId(int userId)
        {
            List<ScheduleVM> schedules = null;
            try
            {
                schedules = _scheduleAccessor.SelectScheduleByUser(userId);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error Retrieving schedule data.", ex);
            }
            return schedules;
        }
    }
}
