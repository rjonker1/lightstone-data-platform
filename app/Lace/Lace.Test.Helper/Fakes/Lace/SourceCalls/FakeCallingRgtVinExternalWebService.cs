using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Core.Models;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.Management;
using Lace.Test.Helper.Builders.Responses;
using Workflow.Lace.Messages.Core;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingRgtVinExternalWebService : ICallTheDataProviderSource
    {

        private IEnumerable<Vin> _vin;

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            _vin = new SourceResponseBuilder().ForRgtVin();
            TransformResponse(response);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformRgtVinResponse(_vin);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
