using System;
using Common.Logging;
using Lace.Events;
using Lace.Models.Lightstone;
using Lace.Models.Lightstone.Dto;
using Lace.Models.Responses;
using Lace.Request;
using Lace.Source.Lightstone.Cars;
using Lace.Source.Lightstone.Metrics;
using Lace.Source.Lightstone.Repository.Factory;
using Lace.Source.Lightstone.Transform;
using Monitoring.Sources.Lace;

namespace Lace.Source.Lightstone.SourceCalls
{
    public class CallLightstoneExternalSource : ICallTheSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ILaceRequest _request;
        private const LaceEventSource Source = LaceEventSource.Lightstone;
        private IRetrieveValuationFromMetrics _lightstoneMetrics;
        private IRetrieveCarInformation _lightstoneCarInformation;

        private readonly ISetupRepositoryForModels _lightstoneRepositories;

        public CallLightstoneExternalSource(ILaceRequest request, ISetupRepositoryForModels lightstoneRepositories)
        {
            _request = request;
            _lightstoneRepositories = lightstoneRepositories;
        }

        public void CallTheExternalSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            try
            {
                GetCarInformation();
                GetMetrics();

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Lightstone Source {0}", ex.Message);
                laceEvent.PublishFailedSourceCallMessage(Source);
                LightstoneResponseFailed(response);
            }
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

        private static void LightstoneResponseFailed(ILaceResponse response)
        {
            response.LightstoneResponse = null;
            response.LightstoneResponseHandled = new LightstoneResponseHandled();
            response.LightstoneResponseHandled.HasBeenHandled();
        }

        private void GetCarInformation()
        {
            _lightstoneCarInformation =
                new RetrieveCarInformationDetail(_request, _lightstoneRepositories)
                    .SetupDataSources()
                    .GenerateData()
                    .BuildCarInformation()
                    .BuildCarInformationRequest();
        }

        private void GetMetrics()
        {
            _lightstoneMetrics =
                new BaseRetrievalMetric(_lightstoneCarInformation.CarInformationRequest, new Valuation(),
                    _lightstoneRepositories)
                    .SetupDataSources()
                    .GenerateData()
                    .BuildValuation();
        }

    }
}
