using System;
using Common.Logging;
using Lace.Events;
using Lace.Models.Lightstone;
using Lace.Models.Lightstone.Dto;
using Lace.Request;
using Lace.Response;
using Lace.Source.Lightstone.DataObjects;
using Lace.Source.Lightstone.Transform;
using Monitoring.Sources.Lace;

namespace Lace.Source.Lightstone.SourceCalls
{
    public class CallLightstoneExternalSource : ICallTheSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ILaceRequest _request;
        private const LaceEventSource Source = LaceEventSource.Lightstone;
        private IHaveBaseLevelMetrics _responseFromLightstone;

        public CallLightstoneExternalSource(ILaceRequest request)
        {
            _request = request;
        }


        public void CallTheExternalSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            try
            {
                var statsData = new StatisticsData();
                statsData.GetStatistics(_request.CarInformation);

                _responseFromLightstone = new BaseLevelMetrics();
                _responseFromLightstone.BuildStatisticsData(statsData.Statistics);

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Lightstone Source {0}", ex.Message);
                laceEvent.PublishFailedSourceCallMessaage(Source);
                LightstoneResponseFailed(response);
            }
        }

        public void TransformResponse(ILaceResponse response)
        {
            var transformer = new TransformLightstoneResponse(_responseFromLightstone);

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

    }
}
