using System;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Infrastructure;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Factory;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Management;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure
{
    public class CallLightstoneDataProvider : ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ILaceRequest _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProvider Provider = DataProvider.Lightstone;
        private IRetrieveValuationFromMetrics _metrics;
        private IRetrieveCarInformation _carInformation;

        private readonly ISetupRepository _repositories;
        private readonly ISetupCarRepository _carRepository;

        public CallLightstoneDataProvider(ILaceRequest request, ISetupRepository repositories, ISetupCarRepository carRepository)
        {
            _request = request;
            _repositories = repositories;
            _carRepository = carRepository;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response,
            ISendMonitoringMessages monitoring)
        {
            try
            {
                monitoring.StartCallingDataProvider(Provider, _request.ObjectToJson(), _stopWatch);

                GetCarInformation();
                GetMetrics();
                Dispose();

                monitoring.EndCallingDataProvider(Provider, response != null ? response.ObjectToJson() : string.Empty,
                    _stopWatch);

                TransformResponse(response, monitoring);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Lightstone Data Provider {0}", ex.Message);
                monitoring.DataProviderFault(Provider, ex.Message.ObjectToJson(),
                    "Error calling Lightstone Data Provider");
                LightstoneResponseFailed(response);
            }
        }

        private void Dispose()
        {
            _carRepository.Dispose();
            _repositories.Dispose();
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response,ISendMonitoringMessages monitoring)
        {
            var transformer = new TransformLightstoneResponse(_metrics, _carInformation);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            monitoring.DataProviderTransformation(Provider, transformer.Result.ObjectToJson(),
                transformer.ObjectToJson());

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

    }
}
