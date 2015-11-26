using System;
using System.Collections.Generic;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Configuration;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure.Management;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure
{
    public sealed class CallSignioDataProvider : ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetLogger<CallSignioDataProvider>();
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;
        private ConfigureSignioClient _client;

        public CallSignioDataProvider(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
        {
            _dataProvider = dataProvider;
            _logCommand = logCommand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                _client = new ConfigureSignioClient(_dataProvider.GetRequest<IAmSignioDriversLicenseDecryptionRequest>());
                _logCommand.LogConfiguration(new
                {
                    Configuration = new
                    {
                        SignioDriversLicenseConfiguration.Url,
                        SignioDriversLicenseConfiguration.Username,
                        SignioDriversLicenseConfiguration.Password,
                        XAuthToken = SignioDriversLicenseConfiguration.Token,
                        Operation = _client.Suffix
                    }
                },
                    new {ContextMessage = "Signio Data Provider Decrypting Drivers License Configuration"});


                _logCommand.LogRequest(new ConnectionTypeIdentifier(_client.Suffix).ForWebApiType(), _client.Suffix, _dataProvider.BillablleState.NoRecordState);

                _client.Run();

                _logCommand.LogResponse(_client.IsSuccessful ? DataProviderResponseState.Successful : DataProviderResponseState.NoRecords,
                    new ConnectionTypeIdentifier(_client.Suffix).ForWebApiType(), new { _client.Resonse }, _dataProvider.BillablleState.NoRecordState);


                if (string.IsNullOrWhiteSpace(_client.Resonse))
                    _logCommand.LogFault(new {_dataProvider},
                        new {NoRequestReceived = "No response received from Signio's Drivers License Decryptions Service"});

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Signio Drivers License Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(new {ex.Message}, new {ErrorMessage = "Error calling Signio Drivers License Decryption"});
                SignioResponseFailed(response);
            }
        }

        private static void SignioResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var signioDriversLicenseDecryptionResponse = SignioDriversLicenseDecryptionResponse.WithState(DataProviderResponseState.TechnicalError);
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

            _logCommand.LogTransformation(transformer.Result ?? SignioDriversLicenseDecryptionResponse.Empty(), null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
