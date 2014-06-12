using Lace.Events;
using Lace.Models.RgtVin;
using Lace.Response;
using Lace.Source;
using Lace.Source.RgtVin.Transform;
using Lace.Test.Helper.Builders.Responses;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingRgtVinExternalWebService : ICallTheExternalSource
    {

        private System.Data.DataSet _rgtVinResponse;

        public void CallTheExternalWebService(ILaceResponse response, ILaceEvent laceEvent)
        {
            _rgtVinResponse = new SourceResponseBuilder().ForRgtVin();
            TransformWebResponse(response);
        }

        public void TransformWebResponse(ILaceResponse response)
        {
            var transformer = new TransformRgtVinResponse(_rgtVinResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.RgtVinResponse = transformer.Result;
            response.RgtVinResponseHandled = new RgtVinResponseHandled();
            response.RgtVinResponseHandled.HasBeenHandled();
        }
    }
}
