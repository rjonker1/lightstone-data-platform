using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Infrastructure;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Models;
using Lace.Domain.DataProviders.Rgt.Infrastructure.Dto;
using Lace.Domain.DataProviders.Rgt.Infrastructure.Management;
using Lace.Domain.DataProviders.Rgt.UnitOfWork;
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
      
        private readonly ISetupRepository _repository;
        private readonly ISetupCarRepository _carRepository;

        private IRetrieveCarInformation _carInformation;
        private IList<CarSpecification> _carSpecifications;

        public CallRgtDataProvider(IAmDataProvider dataProvider, ISetupRepository repository,
            ISetupCarRepository carRepository, ILogCommandTypes logCommand)
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
                var request = new RgtRequest(_dataProvider.GetRequest<IAmRgtRequest>(), response, _carRepository);
                if (!request.IsValid)
                {
                    _logCommand.LogFault(new { _dataProvider, response }, new { InvalidRequest = "Cannot continue with RGT as the request is invalid" });
                    throw new Exception("Cannot continue with RGT as the request is invalid");
                }

                _logCommand.LogRequest(new ConnectionTypeIdentifier(ConnectionFactory.ForAutoCarStatsDatabase().ConnectionString)
                    .ForDatabaseType(), new {_dataProvider});

                _carInformation = request.CarInformation;

                GetCarInformation();
                GetCarSpecifics();

                _logCommand.LogResponse(_carSpecifications.Any() ? DataProviderState.Successful : DataProviderState.Failed,
                    new ConnectionTypeIdentifier(ConnectionFactory.ForAutoCarStatsDatabase().ConnectionString)
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
                _log.ErrorFormat("Error calling RGT Data Provider {0}", ex.Message);
                _logCommand.LogFault(new {ex.Message}, new {ErrorMessage = "Error calling RGT Data Provider"});
                RgtResponseFailed(response);
            }
        }

        private void GetCarSpecifics()
        {
            var carUow = new CarSpecificationsUnitOfWork(_repository.CarSpecificationRepository());
            carUow.GetCarSpecifications(_carInformation.CarInformationRequest);
            _carSpecifications = carUow.CarSpecifications != null
                ? carUow.CarSpecifications.ToList()
                : new List<CarSpecification>();
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

        private void GetCarInformation()
        {
            _carInformation
                .SetupDataSources()
                .GenerateData()
                .BuildCarInformation()
                .BuildCarInformationRequest();
        }


    }
}
