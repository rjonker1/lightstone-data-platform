using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Common.Logging;
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
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure
{
    public class CallRgtVinDataProvider : ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        
        private readonly ILaceRequest _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProvider Provider = DataProvider.RgtVin;

        private readonly ISetupRepository _repository;
        private IEnumerable<Vin> _vins;


        public CallRgtVinDataProvider(ILaceRequest request, ISetupRepository repository)
        {
            _request = request;
            _repository = repository;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response,
            ISendMonitoringMessages monitoring)
        {
            try
            {
                var vin = new RgtVinRequestMessage(response)
                    .Build()
                    .Vin;

                monitoring.DataProviderConfiguration(Provider, vin.ObjectToJson(), string.Empty);

                monitoring.StartCallingDataProvider(Provider, vin.ObjectToJson(), _stopWatch);

                var uow = new VehicleVinUnitOfWork(_repository.VinRepository());
                uow.GetVin(vin);
                _vins = uow.Vins;

                monitoring.EndCallingDataProvider(Provider,
                    _vins != null ? _vins.ObjectToJson() : new List<Vin>().ObjectToJson(), _stopWatch);

                if (_vins == null || !_vins.Any())
                    monitoring.DataProviderFault(Provider, _vins.ObjectToJson(), "No VINs were received");

                TransformResponse(response, monitoring);

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling RGT Vin Data Provider {0}", ex.Message);
                monitoring.DataProviderFault(Provider, ex.Message.ObjectToJson(), "Error calling RGT Vin Data Provider");
                RgtVinResponseFailed(response);
            }
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring)
        {
            var transformer = new TransformRgtVinResponse(_vins);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            monitoring.DataProviderTransformation(Provider, transformer.Result.ObjectToJson(),
                transformer.ObjectToJson());

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
