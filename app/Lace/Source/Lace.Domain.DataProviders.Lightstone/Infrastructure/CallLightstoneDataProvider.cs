using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Infrastructure;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Factory;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Management;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Shared.Extensions;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure
{
    public class CallLightstoneDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.LightstoneAuto;
        private IRetrieveValuationFromMetrics _metrics;
        private IRetrieveCarInformation _carInformation;

        private readonly ISetupRepository _repositories;
        private readonly ISetupCarRepository _carRepository;

        public CallLightstoneDataProvider(ICollection<IPointToLaceRequest> request, ISetupRepository repositories,
            ISetupCarRepository carRepository)
        {
            _log = LogManager.GetLogger(GetType());
            _request = request;
            _repositories = repositories;
            _carRepository = carRepository;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response,
            ISendCommandToBus command)
        {
            try
            {
                ValidateVehicleDetail(response);

                command.Monitoring.StartCall(new {_request}, _stopWatch);

                GetCarInformation();
                GetMetrics();
                Dispose();

                command.Monitoring.EndCall(response, _stopWatch);

                TransformResponse(response, command);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Data Provider {0}", ex.Message);
                command.Monitoring.Send(CommandType.Fault, ex.Message,
                    new {ErrorMessage = "Error calling Lightstone Data Provider"});
                LightstoneResponseFailed(response);
            }
        }

        private void Dispose()
        {
            _carRepository.Dispose();
            _repositories.Dispose();
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response,
            ISendCommandToBus command)
        {
            var transformer = new TransformLightstoneResponse(_metrics, _carInformation);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            command.Monitoring.Send(CommandType.Transformation, transformer.Result, transformer);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private static void LightstoneResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var lightstoneResponse = new LightstoneAutoResponse();
            lightstoneResponse.HasBeenHandled();
            response.Add(lightstoneResponse);
        }

        private void GetCarInformation()
        {
            _carInformation =
                new RetrieveCarInformationDetail(_request.GetFromRequest<IPointToVehicleRequest>().Vehicle,
                    _carRepository)
                    .SetupDataSources()
                    .GenerateData()
                    .BuildCarInformation()
                    .BuildCarInformationRequest();
        }

        private void GetMetrics()
        {
            _metrics =
                new BaseRetrievalMetric(_carInformation.CarInformationRequest, new Valuation(),
                    _repositories)
                    .SetupDataSources()
                    .GenerateData()
                    .BuildValuation();
        }

        private void ValidateVehicleDetail(IEnumerable<IPointToLaceProvider> response)
        {
            var ividResponse = response.OfType<IProvideDataFromIvid>().First();
            if (ividResponse == null)
                return;

            if (_request.GetFromRequest<IPointToVehicleRequest>().Vehicle != null &&
                !string.IsNullOrEmpty(_request.GetFromRequest<IPointToVehicleRequest>().Vehicle.Vin) &&
                _request.GetFromRequest<IPointToVehicleRequest>()
                    .Vehicle.Vin.Equals(ividResponse.Vin, StringComparison.CurrentCultureIgnoreCase))
                return;

            _request.GetFromRequest<IPointToVehicleRequest>().Vehicle.SetVinNumber(ividResponse.Vin);
        }

    }
}
