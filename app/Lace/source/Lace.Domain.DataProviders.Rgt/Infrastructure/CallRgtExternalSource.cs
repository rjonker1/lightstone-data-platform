using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Infrastructure;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Models;
using Lace.Domain.DataProviders.Rgt.Infrastructure.Management;
using Lace.Domain.DataProviders.Rgt.UnitOfWork;
using Lace.Shared.Monitoring.Messages.Shared;
using Monitoring.Sources.Lace;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure
{
    public class CallRgtExternalSource : ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ILaceRequest _request;
        private const LaceEventSource Source = LaceEventSource.Rgt;

        private readonly ISetupRepository _repository;
        private readonly ISetupCarRepository _carRepository;
        private IRetrieveCarInformation _carInformation;
        private IEnumerable<CarSpecification> _carSpecifications;

        public CallRgtExternalSource(ILaceRequest request, ISetupRepository repository, ISetupCarRepository carRepository)
        {
            _request = request;
            _repository = repository;
            _carRepository = carRepository;
        }

        public void CallTheExternalSource(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring)
        {
            try
            {
                GetCarInformation();
                _carSpecifications =
                    new CarSpecificationsUnitOfWork(_repository.CarSpecificationRepository()).CarSpecifications;

                if (_carInformation == null || _carInformation.CarInformationRequest == null)
                {
                    Log.ErrorFormat("Could not generate Car information request");
                    RgtResponseFailed(response);
                }

                if (!_carSpecifications.Any())
                    Log.ErrorFormat("Could not get car information for Car id {0} Vin {1}",
                        _carInformation.CarInformationRequest.CarId, _carInformation.CarInformationRequest.Vin);

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling RGT Data Provider {0}", ex.Message);
               // laceEvent.PublishFailedSourceCallMessage(Source);
                RgtResponseFailed(response);
            }
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response)
        {
            var transformer = new TransformRgtResponse(_carSpecifications);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

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
