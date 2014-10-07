using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Management;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Test.Helper.Builders.Responses;


namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingIvidTitleHolderExternalWebService : ICallTheDataProviderSource
    {
        private TitleholderQueryResponse _ividTitleHolderResponse;
        public void CallTheExternalSource(IProvideResponseFromLaceDataProviders response, ILaceEvent laceEvent)
        {
            _ividTitleHolderResponse = new SourceResponseBuilder().ForIvidTitleHolder();
            TransformResponse(response);
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response)
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
