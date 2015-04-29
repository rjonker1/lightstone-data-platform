using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure.Management;
using Lace.Shared.Extensions;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure
{
    public class CallSignioDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.SignioDecryptDriversLicense;
        private ConfigureSignioClient _client;

        public CallSignioDataProvider(ICollection<IPointToLaceRequest> request)
        {
            _log = LogManager.GetLogger(GetType());
            _request = request;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response,
            ISendCommandToBus command)
        {
            try
            {
                _client = new ConfigureSignioClient(_request.GetFromRequest<IHaveDriversLicense>());

                command.Workflow.Send(CommandType.Configuration,
                    new
                    {
                        Configuration =
                            new
                            {
                                _client.Url,
                                _client.Username,
                                _client.Password,
                                _client.XAuthToken,
                                _client.Operation
                            }
                    },
                    new {ContextMessage = "Signio Data Provider Decrypting Drivers License Configuration"},
                    Provider);


                command.Workflow.DataProviderRequest(
                   new DataProviderIdentifier(Provider, DataProviderAction.Request, DataProviderState.Successful)
                       .SetPrice(_request.GetFromRequest<IPointToLaceRequest>().Package.DataProviders.Single(s => s.Name == DataProviderName.SignioDecryptDriversLicense)),
                   new ConnectionTypeIdentifier(_client.Operation)
                       .ForWebApiType(), _client.Operation, _stopWatch);

                _client.Run();

                command.Workflow.DataProviderResponse(
                   new DataProviderIdentifier(Provider, DataProviderAction.Request, _client.IsSuccessful ? DataProviderState.Successful : DataProviderState.Failed)
                       .SetPrice(_request.GetFromRequest<IPointToLaceRequest>().Package.DataProviders.Single(s => s.Name == DataProviderName.SignioDecryptDriversLicense)),
                   new ConnectionTypeIdentifier(_client.Operation)
                       .ForWebApiType(),  _client.Resonse, _stopWatch);

                if (string.IsNullOrWhiteSpace(_client.Resonse))
                    command.Workflow.Send(CommandType.Fault, _request,
                        new
                        {
                            NoRequestReceived = "No response received from Signio's Drivers License Decryptions Service"
                        }, Provider);

                TransformResponse(response, command);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Signio Drivers License Data Provider {0}", ex.Message);
                command.Workflow.Send(CommandType.Fault, ex.Message,
                    new {ErrorMessage = "Error calling Signio Drivers License Decryption"}, Provider);
                SignioResponseFailed(response);
            }
        }

        private static void SignioResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var signioDriversLicenseDecryptionResponse = new SignioDriversLicenseDecryptionResponse();
            signioDriversLicenseDecryptionResponse.HasBeenHandled();
            response.Add(signioDriversLicenseDecryptionResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response,
            ISendCommandToBus command)
        {
            var transformer = new TransformSignioResponse(_client.Resonse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            command.Workflow.Send(CommandType.Transformation,
                transformer.Result ?? new SignioDriversLicenseDecryptionResponse(null, null), null, Provider);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
