using System.Collections.Generic;
using System.Data;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Management;
using Lace.Test.Helper.Builders.Responses;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingLightstonePropertyExternalWebService : ICallTheDataProviderSource
    {
        private DataSet _response;

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            _response = new SourceResponseBuilder().ForLightstoneReturnPropertiesResponse();
            TransformResponse(response);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformLightstonePropertyResponse(_response);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
