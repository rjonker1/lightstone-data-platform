using System;
using System.Linq;
using Lace.Models.RgtVin;
using Lace.Request;
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
            action(new RequestDataFromRgtVinService());
        }

        private static void NotHandledResponse(ILaceResponse response)
        {
            response.RgtVinResponse = null;
            response.RgtVinResponseHandled = new RgtVinResponseHandled();
            response.RgtVinResponseHandled.HasNotBeenHandled();
        }

    }
}
