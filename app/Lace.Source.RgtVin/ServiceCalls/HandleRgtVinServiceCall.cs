using System;
using System.Linq;
using Lace.Response;

namespace Lace.Source.RgtVin.ServiceCalls
{
    class HandleRgtVinServiceCall : IHandleServiceCall
    {

        public string ServiceName
        {
            get
            {
                return GetType().Name;
            }
        }

        public bool CanHandle(Request.ILaceRequest request)
        {
            return request.Sources.Contains(ServiceName);
        }

        public ILaceResponse Call(Action<IRequestDataFromService> action)
        {
            throw new NotImplementedException();
        }

        
    }
}
