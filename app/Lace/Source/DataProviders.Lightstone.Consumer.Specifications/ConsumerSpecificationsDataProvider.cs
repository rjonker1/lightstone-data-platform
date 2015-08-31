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
using Lace.Domain.DataProviders.Lightstone.Consumer.Specifications.Infrastructure;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.Lightstone.Consumer.Specifications
{
    public class ConsumerSpecificationsDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private ILogCommandTypes _logCommand;
        private IAmDataProvider _dataProvider;

        public ConsumerSpecificationsDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }
        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.LightstoneConsumerSpecifications, _request);
            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.LightstoneConsumerSpecifications);
                _logCommand = LogCommandTypes.ForDataProvider(_command, DataProviderCommandSource.LightstoneConsumerSpecifications, _dataProvider);

                _logCommand.LogBegin(new { _request });

                var consumer = new ConsumeSource(new HandleConsumerSpecificationsSourceCall(), new CallConsumerSpecificationsDataProvider(_dataProvider, _logCommand));
                consumer.ConsumeDataProvider(response);

                _logCommand.LogBegin(new { response });

                if (!response.OfType<IProvideDataFromLightstoneConsumerSpecifications>().Any() ||
                    response.OfType<IProvideDataFromLightstoneConsumerSpecifications>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var specificationsResponse = new LightstoneConsumerSpecificationsResponse();
            specificationsResponse.HasNotBeenHandled();
            response.Add(specificationsResponse);
        }
    }
}