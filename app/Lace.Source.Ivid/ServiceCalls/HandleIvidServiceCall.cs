using System;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Lace.Request;
using Lace.Response;
using Lace.Source.Enums;
using Lace.Source.Ivid.ServiceSetup;

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

        private readonly ILaceRequest _request;

        public HandleIvidServiceCall(ILaceRequest request)
        {
            _request = request;
        }


        public bool CanHandle(ILaceRequest request)
        {
            return request.Sources.Contains(Service.ToString());
        }

       
        public void Call(Action<IRequestDataFromService> action)
        {
            action.Invoke(new RequestDataFromIvidService());
        }
    }
}
