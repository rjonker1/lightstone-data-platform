using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Infrastructure;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Management;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Shared.DataProvider.Repositories;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure
{
    public class CallLightstoneAutoDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;
        private IRetrieveValuationFromMetrics _metrics;
        private IRetrieveCarInformation _carInformation;

        private readonly IReadOnlyRepository _repository;
        private readonly IReadOnlyRepository _carRepository;

        private string _vinNumber;

        public CallLightstoneAutoDataProvider(IAmDataProvider dataProvider, IReadOnlyRepository repository,
            IReadOnlyRepository carRepository, ILogCommandTypes logCommand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _repository = repository;
            _carRepository = carRepository;
            _logCommand = logCommand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                _vinNumber = HandleRequest.GetVinNumber(response.ToList(), _dataProvider.GetRequest<IAmLightstoneAutoRequest>());

                _logCommand.LogRequest(new ConnectionTypeIdentifier(ConnectionFactory.ForAutoCarStatsDatabase().ConnectionString)
                    .ForDatabaseType(), new { _dataProvider });

                GetCarInformation();
                GetMetrics();

                _logCommand.LogResponse(response != null && response.Any() ? DataProviderState.Successful : DataProviderState.Failed,new ConnectionTypeIdentifier(ConnectionFactory.ForAutoCarStatsDatabase().ConnectionString)
                        .ForDatabaseType(), new { _carInformation, _metrics });

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Data Provider {0}", ex,ex.Message);
                _logCommand.LogFault(ex, new { ErrorMessage = "Error calling Lightstone Data Provider" });
                LightstoneResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformLightstoneResponse(_metrics, _carInformation);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logCommand.LogTransformation(transformer.Result, null);

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
                new GetCarInformation(_vinNumber,
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
                    _repository)
                    .SetupDataSources()
                    .GenerateData()
                    .BuildValuation();
        }

        

    }
}
