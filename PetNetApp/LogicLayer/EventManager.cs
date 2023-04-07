using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using DataAccessLayer;
using DataObjects;

namespace LogicLayer
{
    public class EventManager:IEventManager
    {
        private IEventAccessor _eventAccessor = null;

        public EventManager()
        {
            _eventAccessor = new EventAccessor();
        }

        public EventManager(IEventAccessor eventAccessor)
        {
            _eventAccessor = eventAccessor;
        }
        public List<Event> SelectAllEvent()
        {
            List<Event> events = new List<Event>();

            try
            {
                events = _eventAccessor.SelectAllEvent();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

            return events;
        }
    }
}
