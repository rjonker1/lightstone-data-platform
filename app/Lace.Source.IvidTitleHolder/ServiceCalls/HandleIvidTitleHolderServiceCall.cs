using System.Collections.Generic;
using System.Linq;
using Lace.Response;
using System;
using Lace.Source.Enums;

namespace Lace.Source.IvidTitleHolder.ServiceCalls
{
    public class HandleIvidTitleHolderServiceCall : IHandleServiceCall
    {
        public Services Service
        {
            get
            {
                return Services.IvidTitleHolder;
            }
        }

        public bool CanHandle(Request.ILaceRequest request)
        {
            return request.Sources.Contains(Service.ToString());
        }

        public ILaceResponse Call(Action<IRequestDataFromService> action)
        {
            return new IvidTitleHolderServiceResponse()
            {
                Handled = true,
                Response = new List<string>() { "Handle Ivid Title Holder Service Call" }
            };
        }
    }
}
