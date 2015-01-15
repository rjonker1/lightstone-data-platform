using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Management;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Test.Helper.Builders.Responses;


namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingIvidTitleHolderExternalWebService : ICallTheDataProviderSource
    {
        private TitleholderQueryResponse _ividTitleHolderResponse;
        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response, ISendCommandsToBus monitoring)
        {
            _ividTitleHolderResponse = new SourceResponseBuilder().ForIvidTitleHolder();
            TransformResponse(response, monitoring);
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendCommandsToBus monitoring)
        {
            var transformer = new TransformIvidTitleHolderResponse(_ividTitleHolderResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.IvidTitleHolderResponse = transformer.Result;
            response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            response.IvidTitleHolderResponseHandled.HasBeenHandled();
        }
    }
}
