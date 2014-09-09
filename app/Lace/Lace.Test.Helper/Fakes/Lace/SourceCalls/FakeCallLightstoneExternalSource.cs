using System;
using Lace.Events;
using Lace.Models.Lightstone;
using Lace.Request;
using Lace.Response;
using Lace.Source;
using Lace.Source.Lightstone.Cars;
using Lace.Source.Lightstone.Metrics;
using Lace.Source.Lightstone.Transform;
using Lace.Test.Helper.Fakes.Responses;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallLightstoneExternalSource : ICallTheSource
    {
        private IRetrieveValuationFromMetrics _lightstoneMetrics;
        private IRetrieveCarInformation _lightstoneCarInformation;

        private readonly ILaceRequest _request;

        public FakeCallLightstoneExternalSource(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            _lightstoneCarInformation = FakeLighstoneRetrievalData.GetCarInformation(_request);
            _lightstoneMetrics =
                FakeLighstoneRetrievalData.GetValuationFromMetrics(_lightstoneCarInformation.CarInformationRequest);

            TransformResponse(response);
        }

        public void TransformResponse(ILaceResponse response)
        {
            var transformer = new TransformLightstoneResponse(_lightstoneMetrics, _lightstoneCarInformation);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.LightstoneResponse = transformer.Result;
            response.LightstoneResponseHandled = new LightstoneResponseHandled();
            response.LightstoneResponseHandled.HasBeenHandled();
        }
    }
}
