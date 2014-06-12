using Lace.Events;
using Lace.Models.Ivid;
using Lace.Response;
using Lace.Source;
using Lace.Source.Ivid.IvidServiceReference;
using Lace.Source.Ivid.Transform;
using Lace.Test.Helper.Builders.Responses;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingIvidExternalWebService : ICallTheExternalSource
    {
        private HpiStandardQueryResponse _ividResponse;
        public void CallTheExternalWebService(ILaceResponse response, ILaceEvent laceEvent)
        {
            _ividResponse = new SourceResponseBuilder().ForIvid();
            TransformWebResponse(response);
        }

        public void TransformWebResponse(ILaceResponse response)
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
