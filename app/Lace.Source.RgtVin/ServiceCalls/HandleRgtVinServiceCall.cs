using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Response;
using Lace.Source.Enums;

namespace Lace.Source.RgtVin.ServiceCalls
{
    public class HandleRgtVinServiceCall : IHandleServiceCall
    {
        public Services Service
        {
            get
            {
                return Services.RgtVin;
            }
        }

        public bool CanHandle(Request.ILaceRequest request)
        {
            return request.Sources.Contains(Service.ToString());
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
