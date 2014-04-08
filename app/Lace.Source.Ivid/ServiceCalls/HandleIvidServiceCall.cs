using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Response;
using Lace.Source.Enums;
using Lace.Source.Ivid.WebServiceSetup;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class HandleIvidServiceCall : IHandleServiceCall
    {
        public Services Service
        {
            get
            {
                return Services.Ivid;
            }
        }

        public bool CanHandle(Request.ILaceRequest request)
        {
            return request.Sources.Contains(Service.ToString());
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
