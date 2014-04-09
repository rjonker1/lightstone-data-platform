using Lace.Models.RgtVin;
using Lace.Request;
using Lace.Response;
using Lace.Source.RgtVin.ServiceCalls;

namespace Lace.Source.RgtVin
{
    public class RgtVinConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ILaceRequest _request;

        public RgtVinConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new HandleRgtVinServiceCall();
        }

        public void CallRgtVinService(ILaceResponse response)
        {
            if (!_handleServiceCall.CanHandle(_request, response)) return;

            _handleServiceCall
                .Call(c =>
                    c.FetchDataFromService(_request, response)
                );
            // return Helpers.ConvertFunctions.ConvertObject<RgtVinServiceResponse>(response);
        }
    }
}
