using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer;
using DataObjects;
using DataAccessLayerInterfaces;
using LogicLayerInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    public class FundraisingEventManager : IFundraisingEventManager
    {
        private IFundraisingEventAccessor _fundraisingEventAccessor = null;
        
        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// <returns>FundraisingEventManager</returns>
        public FundraisingEventManager()
        {
            _fundraisingEventAccessor = new FundraisingEventAccessor();
        }

        /// <summary>
        /// Barry Mikulas
        /// Created: 2023/03/05
        /// 
        /// Constructor for fake data and testing
        /// </summary>
        /// <param name="fundraisingEventAccessor">the fake data access object</param>
        /// <returns>FundRaisingEventManager</returns>
        public FundraisingEventManager(IFundraisingEventAccessor fundraisingEventAccessor)
        {
            _fundraisingEventAccessor = fundraisingEventAccessor;
        }

        public bool EditFundraisingEventResults(FundraisingEventVM oldFundraisingEventVM, FundraisingEventVM newFundraisingEventVM)
        {
            //throw new NotImplementedException();


            bool success = false;
            try
            {
                success = 1 == _fundraisingEventAccessor.UpdateFundraisingEventResults(oldFundraisingEventVM, newFundraisingEventVM);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to update event results", ex);
            }
            return success;
        }

        public List<FundraisingEventVM> RetrieveAllFundraisingEventsByShelterId(int shelterId)
        {
            //throw new NotImplementedException();

            List<FundraisingEventVM> events = null;
            try
            {
                events = _fundraisingEventAccessor.SelectAllFundraisingEventsByShelterId(shelterId);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to load Events " + ex.Message, ex);
            }
            return events;
        }

        public FundraisingEventVM RetrieveFundraisingEventByFundraisingEventId(int fundraisingEventId)
        {
            //throw new NotImplementedException();
            FundraisingEventVM fundraisingEvent = null;
            try
            {
                fundraisingEvent = _fundraisingEventAccessor.SelectFundraisingEventByFundraisingEventId(fundraisingEventId);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to load Fundraising Event", ex);
            }
            return fundraisingEvent;
        }
    }
}
