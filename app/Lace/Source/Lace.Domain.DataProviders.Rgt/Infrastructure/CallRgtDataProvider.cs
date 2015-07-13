using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Infrastructure.Management;
using Lace.Domain.DataProviders.Rgt.UnitOfWork;
using Lace.Shared.DataProvider.Models;
using Lace.Shared.DataProvider.Repositories;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure
{
    public class CallRgtDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;

        private readonly IReadOnlyRepository _repository;
        private readonly IReadOnlyRepository _carRepository;

        private IRetrieveCarInformation _carInformation;
        private IList<CarSpecification> _carSpecifications;

        public CallRgtDataProvider(IAmDataProvider dataProvider, IReadOnlyRepository repository,
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
                _logCommand.LogRequest(new ConnectionTypeIdentifier(ConnectionFactoryManager.AutocarStatsConnection.ConnectionString)
                    .ForDatabaseType(), new {_dataProvider});

                GetCar.WithCarId(response, _dataProvider.GetRequest<IAmRgtRequest>(), _carRepository, ref _carInformation,
                    GetCar.WithVin(response, _dataProvider.GetRequest<IAmRgtRequest>(), _carRepository, ref _carInformation));

                GetSpecifications.ForCar(_repository, _carInformation.CarInformationRequest, out _carSpecifications);

                _logCommand.LogResponse(_carSpecifications.Any() ? DataProviderState.Successful : DataProviderState.Failed,
                    new ConnectionTypeIdentifier(ConnectionFactoryManager.AutocarStatsConnection.ConnectionString)
                        .ForDatabaseType(), new {_carSpecifications});

                if (_carInformation == null || _carInformation.CarInformationRequest == null)
                {
                    _logCommand.LogFault(new {_dataProvider}, new {NoRequestReceived = "No car specifications received from RGT Data Provider"});
                    RgtResponseFailed(response);
                }

                if (!_carSpecifications.Any())
                    _logCommand.LogFault(new {_dataProvider},
                        new
                        {
                            NoRequestReceived =
                                string.Format("Could not get car information for Car id {0} Vin {1}", _carInformation.CarInformationRequest.CarId,
                                    _carInformation.CarInformationRequest.Vin)
                        });


                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling RGT Data Provider because of {0}", ex, ex.Message);
                _logCommand.LogFault(new {ex}, new {ErrorMessage = "Error calling RGT Data Provider"});
                RgtResponseFailed(response);
            }
        }


        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformRgtResponse(_carSpecifications);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logCommand.LogTransformation(transformer.Result, null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private static void RgtResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var rgtResponse = new RgtResponse();
            rgtResponse.HasBeenHandled();
            response.Add(rgtResponse);
        }
    }
}