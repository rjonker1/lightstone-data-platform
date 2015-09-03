﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Bmw.Finance.Infrastructure.Management;
using Lace.Domain.DataProviders.Bmw.Finance.UnitOfWork;
using Lace.Domain.DataProviders.Core.Configuration;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Bmw.Finance.Infrastructure
{
    public sealed class CallBmwFinancedInterestsDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;
        private IList<BmwFinance> _bmwFinances;

        private readonly IReadOnlyRepository _repository;

        public CallBmwFinancedInterestsDataProvider(IAmDataProvider dataProvider, IReadOnlyRepository repository, ILogCommandTypes logCommand)
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
                _logCommand.LogRequest(new ConnectionTypeIdentifier(FinancedInterestsConfiguration.Database)
                    .ForDatabaseType(), new { _dataProvider });
              
                _bmwFinances = BmwFinanceUnitOfWork.Get(_repository, _dataProvider.GetRequest<IAmBmwFinanceRequest>()).ToList();

                _logCommand.LogResponse(_bmwFinances != null && _bmwFinances.Any() ? DataProviderState.Successful : DataProviderState.Failed,
                    new ConnectionTypeIdentifier(FinancedInterestsConfiguration.Database)
                        .ForDatabaseType(), new { _bmwFinances });

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling BMW Financed Interests Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new {ErrorMessage = "Error calling BMW Financed Interests Data Provider" });
                BmwFinacedInterestsResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformBmwFinancedInterestsResponse(_bmwFinances);

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
            var financedInterests = BmwFinanceResponse.Empty();
            financedInterests.HasBeenHandled();
            response.Add(financedInterests);
        }
    }
}