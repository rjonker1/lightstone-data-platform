using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.Management;
using Lace.Test.Helper.Builders.Responses;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingRgtVinExternalWebService : ICallTheDataProviderSource
    {

        private System.Data.DataSet _rgtVinResponse;

        public void CallTheExternalSource(IProvideResponseFromLaceDataProviders response, ILaceEvent laceEvent)
        {
            _rgtVinResponse = new SourceResponseBuilder().ForRgtVin();
            TransformResponse(response);
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response)
        {
            var transformer = new TransformRgtVinResponse(_rgtVinResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.RgtVinResponse = transformer.Result;
            response.RgtVinResponseHandled = new RgtVinResponseHandled();
            response.RgtVinResponseHandled.HasBeenHandled();
        }
    }
}
