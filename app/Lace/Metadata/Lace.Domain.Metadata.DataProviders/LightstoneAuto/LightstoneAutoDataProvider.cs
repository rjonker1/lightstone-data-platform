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
using Lace.Domain.DataProviders.Lightstone.Infrastructure;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.Metadata.DataProviders.LightstoneAuto
{
    public class LightstoneAutoDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private ILogCommandTypes _logCommand;
        private IAmDataProvider _dataProvider;

        public LightstoneAutoDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.LSAutoCarStats_I_DB, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.LSAutoCarStats_I_DB);
                _logCommand = LogCommandTypes.ForDataProvider(_command, DataProviderCommandSource.LSAutoCarStats_I_DB, _dataProvider,_dataProvider.BillablleState.NoRecordState);

                var consumer = new ConsumeSource(new HandleLightstoneAutoSourceCall(),
                    new CallLightstoneAutoDataProvider(_dataProvider, new FakeCarInfoRepository(), _logCommand));

                consumer.ConsumeDataProvider(response);

                if (!response.OfType<IProvideDataFromLightstoneAuto>().Any() || response.OfType<IProvideDataFromLightstoneAuto>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var lightstoneResponse = new LightstoneAutoResponse();
            lightstoneResponse.HasNotBeenHandled();
            response.Add(lightstoneResponse);
        }
    }
}