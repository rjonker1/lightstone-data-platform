using Lace.Events;
using Lace.Models;
using Lace.Models.IvidTitleHolder;
using Lace.Source;
using Lace.Source.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Source.IvidTitleHolder.Transform;
using Lace.Test.Helper.Builders.Responses;


namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingIvidTitleHolderExternalWebService : ICallTheSource
    {
        private TitleholderQueryResponse _ividTitleHolderResponse;
        public void CallTheExternalSource(IProvideLaceResponse response, ILaceEvent laceEvent)
        {
            _ividTitleHolderResponse = new SourceResponseBuilder().ForIvidTitleHolder();
            TransformResponse(response);
        }

        public void TransformResponse(IProvideLaceResponse response)
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
