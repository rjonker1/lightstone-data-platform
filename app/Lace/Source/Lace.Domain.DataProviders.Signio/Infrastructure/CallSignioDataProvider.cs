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
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;

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
            ISendMonitoringCommandsToBus monitoring)
        {
            try
            {
                _client = new ConfigureSignioClient(_request.GetFromRequest<IHaveDriversLicenseInformation>());

                monitoring.Send(CommandType.Configuration,
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
                    new {ContextMessage = "Signio Data Provider Decrypting Drivers License Configuration"});

                monitoring.StartCall(_client.Operation, _stopWatch);

                _client.Run();

                monitoring.EndCall(_client.IsSuccessful ? _client.Resonse : "No Response Returned", _stopWatch);

                if (string.IsNullOrWhiteSpace(_client.Resonse))
                    monitoring.Send(CommandType.Fault, _request,
                        new
                        {
                            NoRequestReceived = "No response received from Signio's Drivers License Decryptions Service"
                        });

                TransformResponse(response, monitoring);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Signio Drivers License Data Provider {0}", ex.Message);
                monitoring.Send(CommandType.Fault, ex.Message,
                    new {ErrorMessage = "Error calling Signio Drivers License Decryption"});
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
            ISendMonitoringCommandsToBus monitoring)
        {
            var transformer = new TransformSignioResponse(_client.Resonse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            monitoring.Send(CommandType.Transformation,
                transformer.Result ?? new SignioDriversLicenseDecryptionResponse(null, null), transformer);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
