using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Configuration;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Consumer.Specifications.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Lightstone.Consumer.Specifications.Infrastructure.Management;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Lightstone.Consumer.Specifications.Infrastructure
{
    public sealed class CallConsumerSpecificationsDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;
        private string _jsonRepairHistory;

        public CallConsumerSpecificationsDataProvider(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _logCommand = logCommand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                var api = new ConfigureSource();

                _logCommand.LogRequest(new ConnectionTypeIdentifier(api.Client.Endpoint.Address.Uri.AbsoluteUri)
                    .ForWebApiType(), new {_dataProvider});

                _jsonRepairHistory =
                    api.Client.getRepairHistory(
                        Guid.Parse(ValidateAccessKey(_dataProvider.GetRequest<IAmLightstoneConsumerSpecificationsRequest>().AccessKey.GetValue())),
                        _dataProvider.GetRequest<IAmLightstoneConsumerSpecificationsRequest>().VinNumber.GetValue());

                _logCommand.LogResponse(response != null && response.Any() ? DataProviderState.Successful : DataProviderState.Failed,
                    new ConnectionTypeIdentifier(api.Client.Endpoint.Address.Uri.AbsoluteUri)
                        .ForDatabaseType(), new {_jsonRepairHistory});

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Consumer Specifications Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new {ErrorMessage = "Error calling Lightstone Consumer Specifications Data Provider"});
                PCubedEzScoreResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformConsumerSpecificationsResponse(_jsonRepairHistory, _dataProvider.Critical);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logCommand.LogTransformation(transformer.Result, null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private void PCubedEzScoreResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var specificationsResponse = _dataProvider.IsCritical()
                ? LightstoneConsumerSpecificationsResponse.Failure(_dataProvider.Message())
                : LightstoneConsumerSpecificationsResponse.Empty();
            specificationsResponse.HasBeenHandled();
            response.Add(specificationsResponse);
        }

        private static string ValidateAccessKey(string key)
        {
            return !string.IsNullOrEmpty(key) ? key : LightstoneConsumerConfiguration.Accesskey;
        }
    }
}
