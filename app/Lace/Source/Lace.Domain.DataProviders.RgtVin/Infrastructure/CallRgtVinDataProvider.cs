using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.Management;
using Lace.Domain.DataProviders.RgtVin.UnitOfWork;
using Lace.Shared.DataProvider.Models;
using Lace.Shared.DataProvider.Repositories;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure
{
    public class CallRgtVinDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;

        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;

        private readonly IReadOnlyRepository _repository;
        private IList<Vin> _vins;

        public CallRgtVinDataProvider(IAmDataProvider dataProvider, IReadOnlyRepository repository, ILogCommandTypes logCommand)
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
                _logCommand.LogRequest(new ConnectionTypeIdentifier(ConnectionFactoryManager.AutocarStatsConnection.ConnectionString)
                    .ForDatabaseType(), new { _dataProvider });

                GetVin.AsAList(response, _dataProvider.GetRequest<IAmRgtVinRequest>(), new VehicleVinUnitOfWork(_repository), out _vins);

                _logCommand.LogRequest(new ConnectionTypeIdentifier(ConnectionFactoryManager.AutocarStatsConnection.ConnectionString)
                    .ForDatabaseType(), new {_vins});

                if (_vins == null || !_vins.Any())
                    _logCommand.LogFault(new { _dataProvider },
                        new {ErrorMessage = "No VINs were received"});

                _logCommand.LogResponse(_vins != null && _vins.Any() ? DataProviderState.Successful : DataProviderState.Failed,
                    new ConnectionTypeIdentifier(ConnectionFactoryManager.AutocarStatsConnection.ConnectionString)
                        .ForDatabaseType(), new {_vins});

                TransformResponse(response);

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling RGT Vin Data Provider {0}", ex,ex.Message);
                _logCommand.LogFault(new {ex}, new {ErrorMessage = "Error calling RGT Vin Data Provider"});
                RgtVinResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformRgtVinResponse(_vins);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logCommand.LogTransformation(transformer.Result, null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private static void RgtVinResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var rgtVinResponse = new RgtVinResponse();
            rgtVinResponse.HasBeenHandled();
            response.Add(rgtVinResponse);
        }
    }
}