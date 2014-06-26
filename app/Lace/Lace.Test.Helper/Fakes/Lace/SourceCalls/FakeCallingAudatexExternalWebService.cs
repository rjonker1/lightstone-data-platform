using Lace.Events;
using Lace.Models.Audatex;
using Lace.Request;
using Lace.Response;
using Lace.Source;
using Lace.Source.Audatex.AudatexServiceReference;
using Lace.Source.Audatex.Transform;
using Lace.Test.Helper.Builders.Responses;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingAudatexExternalWebService : ICallTheSource
    {
        private GetDataResult _audatexResponse;
        private readonly ILaceRequest _request;

        public FakeCallingAudatexExternalWebService(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            _audatexResponse = new SourceResponseBuilder().ForAudatexWithHuyandaiHistory();
            TransformResponse(response);
        }

        public void TransformResponse(ILaceResponse response)
        {
            var transformer = new TransformAudatexResponse(_audatexResponse, response, _request);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.AudatexResponse = transformer.Result;
            response.AudatexResponseHandled = new AudatexResponseHandled();
            response.AudatexResponseHandled.HasBeenHandled();
        }
    }
}
