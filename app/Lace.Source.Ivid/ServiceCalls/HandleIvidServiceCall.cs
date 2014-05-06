using System;
using System.Linq;
using Lace.Models.Ivid;
using Lace.Request;
using Lace.Response;
using Lace.Source.Enums;

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
       
        private bool _canHandle;
        public bool CanHandle(ILaceRequest request, ILaceResponse response)
        {
            _canHandle = request.Sources.Contains(Service.ToString());

            if (!_canHandle)
            {
                NotHandledResponse(response);
            }

            return _canHandle;
        }
        
        public void Request(Action<IRequestDataFromService> action)
        {
            action(new RequestDataFromIvidService());
        }


        private static void NotHandledResponse(ILaceResponse response)
        {
            response.IvidResponse = null;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasNotBeenHandled();
        }
    }
}
