﻿using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Ivid.Infrastructure;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.Ivid
{
    public class IvidDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private ILogComandTypes _logComand;
        private IAmDataProvider _dataProvider;

        public IvidDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource, IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.Ivid, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.Ivid);
                _logComand = new LogCommandTypes(_command, DataProviderCommandSource.Ivid, _dataProvider);

                _logComand.LogBegin(new {_dataProvider});

                var consumer = new ConsumeSource(new HandleIvidSourceCall(), new CallIvidDataProvider(_dataProvider, _logComand));
                consumer.ConsumeDataProvider(response);

                _logComand.LogEnd(new {response});

                if (!response.OfType<IProvideDataFromIvid>().Any() || response.OfType<IProvideDataFromIvid>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }
        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var ividResponse = new IvidResponse();
            ividResponse.HasNotBeenHandled();
            response.Add(ividResponse);
        }
    }
}