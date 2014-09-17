using Lace.Events;
using Lace.Models;
using Lace.Models.Ivid;
using Lace.Source;
using Lace.Source.Ivid.IvidServiceReference;
using Lace.Source.Ivid.Transform;
using Lace.Test.Helper.Builders.Responses;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingIvidExternalWebService : ICallTheSource
    {
        private HpiStandardQueryResponse _ividResponse;
        public void CallTheExternalSource(IProvideLaceResponse response, ILaceEvent laceEvent)
        {
            _ividResponse = new SourceResponseBuilder().ForIvid();
            TransformResponse(response);
        }

        public void TransformResponse(IProvideLaceResponse response)
        {
            var transformer = new TransformIvidResponse(_ividResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.IvidResponse = transformer.Result;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasBeenHandled();
        }
    }
}
