using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Common.Logging;
using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Core.Models;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.Dto;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.Management;
using Lace.Domain.DataProviders.RgtVin.UnitOfWork;
using Lace.Shared.Extensions;
using Monitoring.Sources.Lace;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure
{
    public class CallRgtVinExternalSource : ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        
        private readonly ILaceRequest _request;
        private const LaceEventSource Source = LaceEventSource.RgtVin;

        private readonly ISetupRepository _repository;
        private IEnumerable<Vin> _vins;


        public CallRgtVinExternalSource(ILaceRequest request, ISetupRepository repository)
        {
            _request = request;
            _repository = repository;
        }

        public void CallTheExternalSource(IProvideResponseFromLaceDataProviders response, ILaceEvent laceEvent)
        {
            try
            {
                laceEvent.PublishStartSourceConfigurationMessage(Source);

                var vin = new RgtVinRequestMessage(response)
                    .Build()
                    .Vin;

                laceEvent.PublishEndSourceConfigurationMessage(Source);

                laceEvent.PublishSourceRequestMessage(Source,
                    vin.ObjectToJson());

                laceEvent.PublishStartSourceCallMessage(Source);

                _vins = new VehicleVinUnitOfWork(_repository.VinRepository()).Vins;

                laceEvent.PublishEndSourceCallMessage(Source);

                if (_vins == null || !_vins.Any())
                    laceEvent.PublishNoResponseFromSourceMessage(Source);

                laceEvent.PublishSourceResponseMessage(Source,
                    _vins != null && _vins.Any() ? _vins.ObjectToJson() : new List<Vin>().ObjectToJson());

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
            var transformer = new TransformRgtVinResponse(_vins);

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
