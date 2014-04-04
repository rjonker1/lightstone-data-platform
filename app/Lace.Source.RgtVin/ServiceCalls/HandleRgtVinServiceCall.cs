using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Response;

namespace Lace.Source.RgtVin.ServiceCalls
{
    public class HandleRgtVinServiceCall : IHandleServiceCall
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
            return new RgtVinServiceResponse()
            {
                Handled = true,
                Response = new List<string>() {"Handle Rgt Vin Service Call"}
            };
        }


    }
}
