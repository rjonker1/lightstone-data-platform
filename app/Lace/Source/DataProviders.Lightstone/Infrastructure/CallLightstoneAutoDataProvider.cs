using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Configuration;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Management;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Repositories;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure
{
    public sealed class CallLightstoneAutoDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;
        private IRetrieveValuationFromMetrics _metrics;
        private IRetrieveCarInformation _carInformation;

        private readonly IReadOnlyRepository _repository;

        public CallLightstoneAutoDataProvider(IAmDataProvider dataProvider, IReadOnlyRepository repository,ILogCommandTypes logCommand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _repository = repository;
            _logCommand = logCommand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                _logCommand.LogRequest(new ConnectionTypeIdentifier(AutoCarstatsConfiguration.Database)
                    .ForDatabaseType(), new {_dataProvider});

                GetCar.WithCarId(response, _dataProvider.GetRequest<IAmLightstoneAutoRequest>(), _repository, ref _carInformation,
                    GetCar.WithVin(response, _dataProvider.GetRequest<IAmLightstoneAutoRequest>(), _repository, ref _carInformation));

                GetMetricType.OfBaseRetrievalMetric(_carInformation.CarInformationRequest, _repository, out _metrics);

                _logCommand.LogResponse(response != null && response.Any() ? DataProviderState.Successful : DataProviderState.Failed,
                    new ConnectionTypeIdentifier(AutoCarstatsConfiguration.Database)
                        .ForDatabaseType(), new {_carInformation, _metrics});

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new {ErrorMessage = "Error calling Lightstone Data Provider"});
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
            var lightstoneResponse = LightstoneAutoResponse.Empty();
            lightstoneResponse.HasBeenHandled();
            response.Add(lightstoneResponse);
        }
    }
}