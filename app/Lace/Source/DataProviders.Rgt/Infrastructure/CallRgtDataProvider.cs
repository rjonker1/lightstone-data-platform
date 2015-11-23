using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Configuration;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Infrastructure.Management;
using Lace.Domain.DataProviders.Rgt.Queries;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Factories;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;
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

        private IRetrieveCarInformation _carInformation;
        private IList<CarSpecification> _carSpecifications;

        public CallRgtDataProvider(IAmDataProvider dataProvider, IReadOnlyRepository repository, ILogCommandTypes logCommand)
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
                    .ForDatabaseType(), new { _dataProvider }, _dataProvider.BillablleState.NoRecordState);

                _carInformation = new RgtVehicleDataFactory().CarInformation(response, _dataProvider.GetRequest<IAmRgtRequest>(),
                   _repository);

                GetSpecifications.ForCar(new CarSpecificationsQuery(_repository), _carInformation.CarInformationRequest, out _carSpecifications);

                _logCommand.LogResponse(_carSpecifications.Any() ? DataProviderResponseState.Successful : DataProviderResponseState.NoRecords,
                    new ConnectionTypeIdentifier(AutoCarstatsConfiguration.Database)
                        .ForDatabaseType(), new { _carSpecifications }, _dataProvider.BillablleState.NoRecordState);

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
            var transformer = new TransformRgtResponse(_carSpecifications.ToList());

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
            var rgtResponse = RgtResponse.WithState(DataProviderResponseState.TechnicalError);
            rgtResponse.HasBeenHandled();
            response.Add(rgtResponse);
        }
    }
}