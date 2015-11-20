using System;
using System.Collections.Generic;
using Common.Logging;
using DataPlatform.Shared.Enums;
using DataProviders.MMCode.Infrastructure.Management;
using DataProviders.MMCode.Queries;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Configuration;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace DataProviders.MMCode.Infrastructure
{
    public class CallMmCodeDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;
        private readonly IReadOnlyRepository _repository;
        private MmCode _mmCode;
        public CallMmCodeDataProvider(IAmDataProvider dataProvider, IReadOnlyRepository repository, ILogCommandTypes logCommand)
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
                    .ForDatabaseType(), new { _dataProvider },_dataProvider.BillablleState.NoRecordState);

                GetMmCode.ForCar(new MmCodeQuery(_repository), new CarIdQuery().RetrieveCarId(response, _dataProvider.GetRequest<IAmMmCodeRequest>()),
                    out _mmCode);

                _logCommand.LogResponse(_mmCode != null && _mmCode.Car_ID > 0 ? DataProviderResponseState.Successful : DataProviderResponseState.NoRecords,
                    new ConnectionTypeIdentifier(AutoCarstatsConfiguration.Database)
                        .ForDatabaseType(), new { _mmCode },_dataProvider.BillablleState.NoRecordState);

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling MMCode Data Provider because of {0}", ex, ex.Message);
                _logCommand.LogFault(new { ex }, new { ErrorMessage = "Error calling MMCode Data Provider" });
                MmCodeResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformMmCodeResponse(_mmCode);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logCommand.LogTransformation(transformer.Result, null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private static void MmCodeResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var mmCodeResponse = MMCodeResponse.WithState(DataProviderResponseState.TechnicalError);
            mmCodeResponse.HasBeenHandled();
            response.Add(mmCodeResponse);
        }
    }
}