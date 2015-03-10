using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Core.Models;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.Dto;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.Management;
using Lace.Domain.DataProviders.RgtVin.UnitOfWork;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure
{
    public class CallRgtVinDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;

        private readonly ILaceRequest _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.RgtVin;

        private readonly ISetupRepository _repository;
        private IEnumerable<Vin> _vins;


        public CallRgtVinDataProvider(ILaceRequest request, ISetupRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _request = request;
            _repository = repository;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response,
            ISendMonitoringCommandsToBus monitoring)
        {
            try
            {
                var vin = new RgtVinRequestMessage(response)
                    .Build()
                    .Vin;

                monitoring.Send(CommandType.Configuration, new { VinNumber = vin}, null);

                monitoring.StartCall(vin, _stopWatch);

                var uow = new VehicleVinUnitOfWork(_repository.VinRepository());
                uow.GetVin(vin);
                _vins = uow.Vins;

                monitoring.EndCall(_vins ?? new List<Vin>(), _stopWatch);

                if (_vins == null || !_vins.Any())
                    monitoring.Send(CommandType.Fault, new {VinNumber = vin},
                        new {ErrorMessage = "No VINs were received"});

                TransformResponse(response, monitoring);

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling RGT Vin Data Provider {0}", ex.Message);
                monitoring.Send(CommandType.Fault, ex.Message,
                    new {ErrorMessage = "Error calling RGT Vin Data Provider"});
                RgtVinResponseFailed(response);
            }
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendMonitoringCommandsToBus monitoring)
        {
            var transformer = new TransformRgtVinResponse(_vins);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            monitoring.Send(CommandType.Transformation, transformer.Result, transformer);

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
