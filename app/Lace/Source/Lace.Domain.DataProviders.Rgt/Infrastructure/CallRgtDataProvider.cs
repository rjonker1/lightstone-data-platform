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
using Lace.Domain.DataProviders.Rgt.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Models;
using Lace.Domain.DataProviders.Rgt.Infrastructure.Management;
using Lace.Domain.DataProviders.Rgt.UnitOfWork;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure
{
    public class CallRgtDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly ILaceRequest _request;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.Rgt;
        private readonly DataProviderStopWatch _stopWatch;
        private readonly ISetupRepository _repository;
        private readonly ISetupCarRepository _carRepository;
        
        private IRetrieveCarInformation _carInformation;
        private IEnumerable<CarSpecification> _carSpecifications;

        public CallRgtDataProvider(ILaceRequest request, ISetupRepository repository, ISetupCarRepository carRepository)
        {
            _log = LogManager.GetLogger(GetType());
            _request = request;
            _repository = repository;
            _carRepository = carRepository;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response, ISendMonitoringCommandsToBus monitoring)
        {
            try
            {
                
                ValidateVehicleDetail(response);

                monitoring.StartCall(_request.Vehicle, _stopWatch);

                GetCarInformation();
                var carUow =
                    new CarSpecificationsUnitOfWork(_repository.CarSpecificationRepository());
                carUow.GetCarSpecifications(
                        _carInformation.CarInformationRequest);
                _carSpecifications = carUow.CarSpecifications;

                 monitoring.EndCall(_carSpecifications, _stopWatch);

                if (_carInformation == null || _carInformation.CarInformationRequest == null)
                {
                    _log.ErrorFormat("Could not generate Car information request");
                    monitoring.Send(CommandType.Fault, _request,
                        new {NoRequestReceived = "No car specifications received from RGT Data Provider"});
                    RgtResponseFailed(response);
                }

                if (!_carSpecifications.Any())
                {
                    _log.ErrorFormat("Could not get car information for Car id {0} Vin {1}",
                        _carInformation.CarInformationRequest.CarId, _carInformation.CarInformationRequest.Vin);

                    monitoring.Send(CommandType.Fault, _request,
                        new
                        {
                            NoRequestReceived = string.Format("Could not get car information for Car id {0} Vin {1}",
                                _carInformation.CarInformationRequest.CarId, _carInformation.CarInformationRequest.Vin)
                        });
                }

                TransformResponse(response, monitoring);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling RGT Data Provider {0}", ex.Message);
                monitoring.Send(CommandType.Fault, ex.Message, new {ErrorMessage = "Error calling RGT Data Provider"});
                RgtResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response, ISendMonitoringCommandsToBus monitoring)
        {
            var transformer = new TransformRgtResponse(_carSpecifications);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            monitoring.Send(CommandType.Transformation, transformer.Result, transformer);

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
                new RetrieveCarInformationDetail(_request, _carRepository)
                    .SetupDataSources()
                    .GenerateData()
                    .BuildCarInformation()
                    .BuildCarInformationRequest();
        }

        private void ValidateVehicleDetail(IEnumerable<IPointToLaceProvider> response)
        {
            var ividResponse = response.OfType<IProvideDataFromIvid>().First();
            if (ividResponse == null)
                return;


            if (_request.Vehicle != null && !string.IsNullOrEmpty(_request.Vehicle.Vin) &&
                _request.Vehicle.Vin.Equals(ividResponse.Vin, StringComparison.CurrentCultureIgnoreCase))
                return;

            _request.Vehicle.SetVinNumber(ividResponse.Vin);
        }
    }
}
