using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Mothers.Packages;
using Workflow.Lace.Messages.Core;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingIvidExternalWebService : ICallTheDataProviderSource
    {
        private HpiStandardQueryResponse _ividResponse;
        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            _ividResponse = new SourceResponseBuilder().ForIvid();
            TransformResponse(response);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformIvidResponse(_ividResponse, new CriticalFailure(true,"this cannot fail"));

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
