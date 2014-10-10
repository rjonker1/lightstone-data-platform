using System.Collections;
using System.Collections.Generic;
using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Core.Models;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.Management;
using Lace.Test.Helper.Builders.Responses;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingRgtVinExternalWebService : ICallTheDataProviderSource
    {

        private IEnumerable<Vin> _vin;

        public void CallTheExternalSource(IProvideResponseFromLaceDataProviders response, ILaceEvent laceEvent)
        {
            _vin = new SourceResponseBuilder().ForRgtVin();
            TransformResponse(response);
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response)
        {
            var transformer = new TransformRgtVinResponse(_vin);

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
