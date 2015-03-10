using System;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Infrastructure;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Factory;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Management;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure
{
    public class CallLightstoneDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly ILaceRequest _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.Lightstone;
        private IRetrieveValuationFromMetrics _metrics;
        private IRetrieveCarInformation _carInformation;

        private readonly ISetupRepository _repositories;
        private readonly ISetupCarRepository _carRepository;

        public CallLightstoneDataProvider(ILaceRequest request, ISetupRepository repositories, ISetupCarRepository carRepository)
        {
            _log = LogManager.GetLogger(GetType());
            _request = request;
            _repositories = repositories;
            _carRepository = carRepository;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response,
            ISendMonitoringCommandsToBus monitoring)
        {
            try
            {
                ValidateVehicleDetail(response);

                monitoring.StartCall(new { _request.User, _request.Vehicle, _request.Context }, _stopWatch);

                GetCarInformation();
                GetMetrics();
                Dispose();

                monitoring.EndCall(response, _stopWatch);

                TransformResponse(response, monitoring);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Data Provider {0}", ex.Message);
                monitoring.Send(CommandType.Fault, ex.Message,
                    new { ErrorMessage = "Error calling Lightstone Data Provider"});
                LightstoneResponseFailed(response);
            }
        }

        private void Dispose()
        {
            _carRepository.Dispose();
            _repositories.Dispose();
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendMonitoringCommandsToBus monitoring)
        {
            var transformer = new TransformLightstoneResponse(_metrics, _carInformation);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            monitoring.Send(CommandType.Transformation, transformer.Result,transformer);

            response.LightstoneResponse = transformer.Result;
            response.LightstoneResponseHandled = new LightstoneResponseHandled();
            response.LightstoneResponseHandled.HasBeenHandled();
        }

        private static void LightstoneResponseFailed(IProvideResponseFromLaceDataProviders response)
        {
            response.LightstoneResponse = null;
            response.LightstoneResponseHandled = new LightstoneResponseHandled();
            response.LightstoneResponseHandled.HasBeenHandled();
        }

        private void GetCarInformation()
        {
            _carInformation =
                new RetrieveCarInformationDetail(_request, _carRepository)
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

        private void ValidateVehicleDetail(IProvideResponseFromLaceDataProviders response)
        {
            if (_request.Vehicle != null && !string.IsNullOrEmpty(_request.Vehicle.Vin) &&
                _request.Vehicle.Vin.Equals(response.IvidResponse.Vin, StringComparison.CurrentCultureIgnoreCase))
                return;

            _request.Vehicle.SetVinNumber(response.IvidResponse.Vin);
        }

    }
}
