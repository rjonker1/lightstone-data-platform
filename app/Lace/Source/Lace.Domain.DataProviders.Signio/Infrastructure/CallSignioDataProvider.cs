using System;
using System.Collections.Generic;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure.Management;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure
{
    public class CallSignioDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogComandTypes _logComand;
        private ConfigureSignioClient _client;

        public CallSignioDataProvider(IAmDataProvider dataProvider, ILogComandTypes logComand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _logComand = logComand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                _client = new ConfigureSignioClient(_dataProvider.GetRequest<IAmSignioDriversLicenseDecryptionRequest>());
                _logComand.LogConfiguration(new
                {
                    Configuration = new
                    {
                        _client.Url,
                        _client.Username,
                        _client.Password,
                        _client.XAuthToken,
                        _client.Operation
                    }
                },
                    new {ContextMessage = "Signio Data Provider Decrypting Drivers License Configuration"});


                _logComand.LogRequest(new ConnectionTypeIdentifier(_client.Operation).ForWebApiType(), _client.Operation);

                _client.Run();

                _logComand.LogResponse(_client.IsSuccessful ? DataProviderState.Successful : DataProviderState.Failed,
                    new ConnectionTypeIdentifier(_client.Operation).ForWebApiType(), new {_client.Resonse});


                if (string.IsNullOrWhiteSpace(_client.Resonse))
                    _logComand.LogFault(new {_dataProvider},
                        new {NoRequestReceived = "No response received from Signio's Drivers License Decryptions Service"});

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Signio Drivers License Data Provider {0}", ex.Message);
                _logComand.LogFault(new {ex.Message}, new {ErrorMessage = "Error calling Signio Drivers License Decryption"});
                SignioResponseFailed(response);
            }
        }

        private static void SignioResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var signioDriversLicenseDecryptionResponse = new SignioDriversLicenseDecryptionResponse();
            signioDriversLicenseDecryptionResponse.HasBeenHandled();
            response.Add(signioDriversLicenseDecryptionResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformSignioResponse(_client.Resonse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logComand.LogTransformation(transformer.Result ?? new SignioDriversLicenseDecryptionResponse(null, null), null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
