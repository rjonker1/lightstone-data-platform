using System;
using System.Data;
using Common.Logging;
using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.Configuration;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.Dto;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.Management;
using Lace.Shared.Extensions;
using Monitoring.Sources.Lace;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure
{
    public class CallRgtVinExternalSource : ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private DataSet _rgtVinResponse;
        private readonly ILaceRequest _request;
        private const LaceEventSource Source = LaceEventSource.RgtVin;

        public CallRgtVinExternalSource(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalSource(IProvideResponseFromLaceDataProviders response, ILaceEvent laceEvent)
        {
            try
            {
                laceEvent.PublishStartSourceConfigurationMessage(Source);

                var rgtVinWebService = new ConfigureRgtVinWebSource();
                var rgtVinRequest = new RgtVinRequestMessage(_request, response)
                    .Build()
                    .RgtVinRequest;

                laceEvent.PublishEndSourceConfigurationMessage(Source);

                laceEvent.PublishSourceRequestMessage(Source,
                    rgtVinRequest.ObjectToJson());


                laceEvent.PublishStartSourceCallMessage(Source);

                _rgtVinResponse = rgtVinWebService
                    .RgtVinServiceProxy
                    .VinCheckSpecsFiltered(rgtVinRequest.Vin, string.Empty, rgtVinRequest.SecurityCode);

                laceEvent.PublishEndSourceCallMessage(Source);


                rgtVinWebService.CloseWebService();

                if (_rgtVinResponse == null)
                    laceEvent.PublishNoResponseFromSourceMessage(Source);

                laceEvent.PublishSourceResponseMessage(Source,
                    _rgtVinResponse != null ? _rgtVinResponse.ObjectToJson() : new DataSet().ObjectToJson());

                TransformResponse(response);

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling RGT Vin Data Provider {0}", ex.Message);
                laceEvent.PublishFailedSourceCallMessage(Source);
                RgtVinResponseFailed(response);
            }
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response)
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

        private static void RgtVinResponseFailed(IProvideResponseFromLaceDataProviders response)
        {
            response.RgtVinResponse = null;
            response.RgtVinResponseHandled = new RgtVinResponseHandled();
            response.RgtVinResponseHandled.HasBeenHandled();
        }

    }
}
