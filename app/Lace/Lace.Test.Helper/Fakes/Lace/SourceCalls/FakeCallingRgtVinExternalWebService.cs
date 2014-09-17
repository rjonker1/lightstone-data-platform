using Lace.Events;
using Lace.Models;
using Lace.Models.RgtVin;
using Lace.Source;
using Lace.Source.RgtVin.Transform;
using Lace.Test.Helper.Builders.Responses;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingRgtVinExternalWebService : ICallTheSource
    {

        private System.Data.DataSet _rgtVinResponse;

        public void CallTheExternalSource(IProvideLaceResponse response, ILaceEvent laceEvent)
        {
            _rgtVinResponse = new SourceResponseBuilder().ForRgtVin();
            TransformResponse(response);
        }

        public void TransformResponse(IProvideLaceResponse response)
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
