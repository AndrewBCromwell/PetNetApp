using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    /// <summary>
    /// Ethan Kline 
    /// Created: 2023/04/7
    /// </summary>
    /// <exception cref="SQLException">Select Fails</exception>
    /// <returns>all Events </returns>
    public interface IEventAccessor
    {
        List<Event> SelectAllEvent();
    }
}
