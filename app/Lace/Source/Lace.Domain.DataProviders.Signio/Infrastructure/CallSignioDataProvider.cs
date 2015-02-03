using System;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure.Management;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;

namespace Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure
{
    public class CallSignioDataProvider : ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ILaceRequest _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.SignioDecryptDriversLicense;
        private ConfigureSignioClient _client;

        public CallSignioDataProvider(ILaceRequest request)
        {
            _request = request;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response,
            ISendCommandsToBus monitoring)
        {
            try
            {
                _client = new ConfigureSignioClient(_request.DriversLicense.ScanData,_request.DriversLicense.UserId);

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
                Log.ErrorFormat("Error calling Signio Drivers License Data Provider {0}", ex.Message);
                monitoring.Send(CommandType.Fault, ex.Message,
                    new {ErrorMessage = "Error calling Signio Drivers License Decryption"});
                SignioResponseFailed(response);
            }
        }

        private static void SignioResponseFailed(IProvideResponseFromLaceDataProviders response)
        {
            response.SignioDriversLicenseDecryptionResponse = null;
            response.SignioDriversLicenseDecryptionResponseHandled = new SignioDriversLicenseDecryptionResponseHandled();
            response.SignioDriversLicenseDecryptionResponseHandled.HasBeenHandled();
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendCommandsToBus monitoring)
        {
            var transformer = new TransformSignioResponse(_client.Resonse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            monitoring.Send(CommandType.Transformation, transformer.Result, transformer);

            response.SignioDriversLicenseDecryptionResponse = transformer.Result;
            response.SignioDriversLicenseDecryptionResponseHandled = new SignioDriversLicenseDecryptionResponseHandled();
            response.SignioDriversLicenseDecryptionResponseHandled.HasBeenHandled();
        }
    }
}
