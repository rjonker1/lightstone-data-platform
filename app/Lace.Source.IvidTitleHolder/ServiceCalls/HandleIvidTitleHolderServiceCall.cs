using System.Linq;
using Lace.Response;
using System;

namespace Lace.Source.IvidTitleHolder.ServiceCalls
{
    public class HandleIvidTitleHolderServiceCall : IHandleServiceCall
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
