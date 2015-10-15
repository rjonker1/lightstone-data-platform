using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Bmw.Finance.Factory;
using Lace.Domain.DataProviders.Bmw.Finance.Infrastructure.Management;
using Lace.Domain.DataProviders.Bmw.Finance.Queries;
using Lace.Domain.DataProviders.Core.Configuration;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Bmw.Finance.Infrastructure
{
    public sealed class CallBmwFinanceDataProvider : ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetLogger<CallBmwFinanceDataProvider>();
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;
        private IList<BmwFinance> _bmwFinances;

        private readonly IReadOnlyRepository _repository;

        public CallBmwFinanceDataProvider(IAmDataProvider dataProvider, IReadOnlyRepository repository, ILogCommandTypes logCommand)
        {
            _dataProvider = dataProvider;
            _repository = repository;
            _logCommand = logCommand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                _logCommand.LogRequest(new ConnectionTypeIdentifier(IntegrationBmwConfiguration.Database)
                    .ForDatabaseType(), new { _dataProvider }, _dataProvider.BillablleState.NoRecordState);

                _bmwFinances =
                    new BmwFinanceDataBasedOnRequestFactory().Get(new BmwFinanceQuery(_repository),
                        _dataProvider.GetRequest<IAmBmwFinanceRequest>(), response).ToList();

                _logCommand.LogResponse(_bmwFinances != null && _bmwFinances.Any() ? DataProviderResponseState.Successful : DataProviderResponseState.NoRecords,
                    new ConnectionTypeIdentifier(IntegrationBmwConfiguration.Database)
                        .ForDatabaseType(), new { _bmwFinances }, _dataProvider.BillablleState.NoRecordState);

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling BMW Financed Interests Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new {ErrorMessage = "Error calling BMW Financed Interests Data Provider"});
                BmwFinacedInterestsResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformBmwFinanceResponse(_bmwFinances);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logCommand.LogTransformation(transformer.Result, null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private static void BmwFinacedInterestsResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var financedInterests = BmwFinanceResponse.WithState(DataProviderResponseState.TechnicalError);
            financedInterests.HasBeenHandled();
            response.Add(financedInterests);
        }
    }
}