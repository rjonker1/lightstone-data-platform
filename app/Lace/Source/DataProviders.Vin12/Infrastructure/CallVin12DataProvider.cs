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
using Lace.Domain.DataProviders.Vin12.Infrastructure.Management;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Factories;
using Lace.Toolbox.Database.Repositories;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Vin12.Infrastructure
{
    public class CallVin12DataProvider : ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetLogger<CallVin12DataProvider>();
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;
        private readonly IReadOnlyRepository _repository;
        private List<Vin12CarinformationDto> _carInformation;

        public CallVin12DataProvider(IAmDataProvider dataProvider, IReadOnlyRepository repository, ILogCommandTypes logCommand)
        {
            _dataProvider = dataProvider;
            _repository = repository;
            _logCommand = logCommand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                _logCommand.LogRequest(new ConnectionTypeIdentifier(AutoCarstatsConfiguration.Database)
                    .ForDatabaseType(), new { _dataProvider }, _dataProvider.BillablleState.NoRecordState, string.Empty);

                _carInformation = new Vin12VehicleDataFactory().Vin12CarInformation(response, _dataProvider.GetRequest<IAmVin12Request>().VinNumber,
                    _repository);

                _logCommand.LogResponse(_carInformation != null && _carInformation.Any() ? DataProviderResponseState.Successful : DataProviderResponseState.NoRecords,
                    new ConnectionTypeIdentifier(AutoCarstatsConfiguration.Database)
                        .ForDatabaseType(), new { }, _dataProvider.BillablleState.NoRecordState, string.Empty);

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling VIN12 Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new { ErrorMessage = "Error calling VIN12 Data Provider" });
                LightstoneResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformVin12Response(_carInformation);

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
            var vin12Response = Vin12Response.WithState(DataProviderResponseState.TechnicalError);
            vin12Response.HasBeenHandled();
            response.Add(vin12Response);
        }
    }
}
