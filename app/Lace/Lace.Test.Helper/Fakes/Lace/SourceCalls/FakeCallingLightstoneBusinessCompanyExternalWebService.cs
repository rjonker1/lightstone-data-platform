using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Management;
using Lace.Test.Helper.Builders.Responses;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingLightstoneBusinessCompanyExternalWebService : ICallTheDataProviderSource
    {
        private System.Data.DataSet _returnCompanyReport;

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            _returnCompanyReport = new SourceResponseBuilder().ForLightstoneBusinessCompanyResponse();
            TransformResponse(response);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformLightstoneCompanyResponse(_returnCompanyReport);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
