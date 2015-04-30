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
using Lace.Domain.DataProviders.Rgt.Infrastructure.Management;
using Lace.Domain.DataProviders.Rgt.UnitOfWork;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure
{
    public class CallRgtDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogComandTypes _logComand;
      
        private readonly ISetupRepository _repository;
        private readonly ISetupCarRepository _carRepository;

        private IRetrieveCarInformation _carInformation;
        private IList<CarSpecification> _carSpecifications;

        private string _vinNumber;

        public CallRgtDataProvider(IAmDataProvider dataProvider, ISetupRepository repository,
            ISetupCarRepository carRepository, ILogComandTypes logComand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _repository = repository;
            _carRepository = carRepository;
            _logComand = logComand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {

                _vinNumber = GetVinNumber(response.ToList());

                _logComand.LogRequest(new ConnectionTypeIdentifier(ConnectionFactory.ForAutoCarStatsDatabase().ConnectionString)
                    .ForDatabaseType(), new {_dataProvider});

                GetCarInformation();
                GetCarSpecifics();

                _logComand.LogResponse(_carSpecifications.Any() ? DataProviderState.Successful : DataProviderState.Failed,
                    new ConnectionTypeIdentifier(ConnectionFactory.ForAutoCarStatsDatabase().ConnectionString)
                        .ForDatabaseType(), new {_carSpecifications});

                if (_carInformation == null || _carInformation.CarInformationRequest == null)
                {
                    _logComand.LogFault(new {_dataProvider}, new {NoRequestReceived = "No car specifications received from RGT Data Provider"});
                    RgtResponseFailed(response);
                }

                if (!_carSpecifications.Any())
                    _logComand.LogFault(new {_dataProvider},
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
                _logComand.LogFault(new {ex.Message}, new {ErrorMessage = "Error calling RGT Data Provider"});
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

            _logComand.LogTransformation(transformer.Result, null);

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
            _carInformation =
                new GetCarInformation(_vinNumber,
                    _carRepository)
                    .SetupDataSources()
                    .GenerateData()
                    .BuildCarInformation()
                    .BuildCarInformationRequest();
        }

        private static string GetVinNumber(IList<IPointToLaceProvider> response)
        {
            return CanContinue(response) ? response.OfType<IProvideDataFromIvid>().First().Vin : string.Empty;
        }

        private static bool CanContinue(IList<IPointToLaceProvider> response)
        {
            return response.OfType<IProvideDataFromIvid>().First() != null &&
                       response.OfType<IProvideDataFromIvid>().First().Handled;
        }
    }
}
