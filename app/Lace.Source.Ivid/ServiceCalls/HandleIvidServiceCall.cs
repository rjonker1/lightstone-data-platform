using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Response;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class HandleIvidServiceCall : IHandleServiceCall
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
            return new IvidServiceResponse()
            {
                Handled = true,
                Response = new List<string>() { "Handle Ivid Service Call" }
            };
        }




        
    }
}
