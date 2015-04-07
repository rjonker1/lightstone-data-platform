using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Management;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Test.Helper.Builders.Responses;
using Workflow.Lace.Messages.Core;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingIvidTitleHolderExternalWebService : ICallTheDataProviderSource
    {
        private TitleholderQueryResponse _ividTitleHolderResponse;
        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response, ISendCommandToBus command)
        {
            _ividTitleHolderResponse = new SourceResponseBuilder().ForIvidTitleHolder();
            TransformResponse(response, command);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response, ISendCommandToBus command)
        {
            var transformer = new TransformIvidTitleHolderResponse(_ividTitleHolderResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
