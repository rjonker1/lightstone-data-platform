using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Management;
using Lace.Test.Helper.Builders.Responses;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingLightstoneBusinessDirectorExternalWebService : ICallTheDataProviderSource
    {
        private System.Data.DataSet _returnDirectorReport;

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            _returnDirectorReport = new SourceResponseBuilder().ForLightstoneDirectorResponse();
            TransformResponse(response);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformLightstoneDirectorResponse(_returnDirectorReport);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
