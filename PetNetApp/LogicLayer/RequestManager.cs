using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayerInterfaces;
using LogicLayerInterfaces;
using DataObjects;

namespace LogicLayer
{
    public class RequestManager : IRequestManager
    {
        private IRequestAccessor _requestAccessor = null;

        public RequestManager()
        {
            _requestAccessor = new RequestAccessor();
        }

        public RequestManager(IRequestAccessor requestAccessor)
        {
            _requestAccessor = requestAccessor;
        }

        public List<RequestVM> RetrieveRequestsByShelterId(int shelterId)
        {
            List<RequestVM> requests = null;
            try
            {
                requests = _requestAccessor.SelectRequestsByShelterSentTo(shelterId);
                foreach(RequestVM request in requests)
                {
                    _requestAccessor.SelectRequestResourceLinesByRequestId(request);
                }
            }catch(Exception ex)
            {
                throw new ApplicationException("Could not retreive request records.", ex);
            }
            return requests;
        }
    }
}
