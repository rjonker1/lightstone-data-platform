using Lace.Events;
using Lace.Models.IvidTitleHolder;
using Lace.Request;
using Lace.Response;
using Lace.Source;
using Lace.Source.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Source.IvidTitleHolder.Transform;
using Lace.Test.Helper.Builders.Responses;


namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingIvidTitleHolderExternalWebService : ICallTheSource
    {
        private TitleholderQueryResponse _ividTitleHolderResponse;
        public void CallTheExternalWebService(ILaceResponse response, ILaceEvent laceEvent)
        {
            _ividTitleHolderResponse = new SourceResponseBuilder().ForIvidTitleHolder();
            TransformWebResponse(response);
        }

        public void TransformWebResponse(ILaceResponse response)
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
