using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.CrossCutting.DataProviderCommandSource.Car.Core.Contracts;
using Lace.CrossCutting.DataProviderCommandSource.Car.Infrastructure;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Models;
using Lace.Domain.DataProviders.Rgt.Infrastructure.Management;
using Lace.Domain.DataProviders.Rgt.UnitOfWork;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure
{
    public class CallRgtDataProvider : ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ILaceRequest _request;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.Rgt;
        private readonly DataProviderStopWatch _stopWatch;
        private readonly ISetupRepository _repository;
        private readonly ISetupCarRepository _carRepository;
        
        private IRetrieveCarInformation _carInformation;
        private IEnumerable<CarSpecification> _carSpecifications;

        public CallRgtDataProvider(ILaceRequest request, ISetupRepository repository, ISetupCarRepository carRepository)
        {
            _request = request;
            _repository = repository;
            _carRepository = carRepository;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring)
        {
            try
            {
                monitoring.StartCallingDataProvider(Provider, _request.ObjectToJson(), _stopWatch);

                GetCarInformation();
                var carUow =
                    new CarSpecificationsUnitOfWork(_repository.CarSpecificationRepository());
                carUow.GetCarSpecifications(
                        _carInformation.CarInformationRequest);
                _carSpecifications = carUow.CarSpecifications;

                monitoring.EndCallingDataProvider(Provider, _carSpecifications.ObjectToJson(), _stopWatch);

                if (_carInformation == null || _carInformation.CarInformationRequest == null)
                {
                    Log.ErrorFormat("Could not generate Car information request");
                    monitoring.DataProviderFault(Provider, _request.ObjectToJson(),
                        "No car specifications received from RGT Data Provider");
                    RgtResponseFailed(response);
                }

                if (!_carSpecifications.Any())
                {
                    Log.ErrorFormat("Could not get car information for Car id {0} Vin {1}",
                        _carInformation.CarInformationRequest.CarId, _carInformation.CarInformationRequest.Vin);

                    monitoring.DataProviderFault(Provider, _request.ObjectToJson(),
                        string.Format("Could not get car information for Car id {0} Vin {1}",
                            _carInformation.CarInformationRequest.CarId, _carInformation.CarInformationRequest.Vin));
                }

                TransformResponse(response, monitoring);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling RGT Data Provider {0}", ex.Message);
                monitoring.DataProviderFault(Provider, ex.Message.ObjectToJson(), "Error calling RGT Data Provider");
                RgtResponseFailed(response);
            }
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring)
        {
            var transformer = new TransformRgtResponse(_carSpecifications);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            monitoring.DataProviderTransformation(Provider, transformer.Result.ObjectToJson(),
                transformer.ObjectToJson());

            response.RgtResponse = transformer.Result;
            response.RgtResponseHandled = new RgtResponseHandled();
            response.RgtResponseHandled.HasBeenHandled();
        }

        private static void RgtResponseFailed(IProvideResponseFromLaceDataProviders response)
        {
            response.RgtResponse = null;
            response.RgtResponseHandled = new RgtResponseHandled();
            response.RgtResponseHandled.HasBeenHandled();
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
    }
}
