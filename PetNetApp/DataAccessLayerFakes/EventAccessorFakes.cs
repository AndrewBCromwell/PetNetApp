using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class EventAccessorFakes : IEventAccessor
    {
        public List<Event> fakeEvents = new List<Event>();

        public EventAccessorFakes()
        {
            fakeEvents.Add(new Event()
            {
                Eventid = 10000,
                EventTypeid = "good",
                Shelterid =1,
                EventTitle ="happy dogs",
                EventVisible=true
            });
        }
        public List<Event> SelectAllEvent()
        {
            return fakeEvents;
            //return fakeEvents.Where(e => e.EventVisible == true).ToList();
        }
    }
}
