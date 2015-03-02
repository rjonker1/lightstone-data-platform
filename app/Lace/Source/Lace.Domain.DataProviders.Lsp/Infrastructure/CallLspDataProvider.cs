using System;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lsp.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Lsp.Infrastructure.Management;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;

namespace Lace.Domain.DataProviders.Lsp.Infrastructure
{
    public class CallLspDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly ILaceRequest _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.Lsp;
        private ConfigureLspClient _client;

        public CallLspDataProvider(ILaceRequest request)
        {
            _log = LogManager.GetLogger(GetType());
            _request = request;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response,
            ISendCommandsToBus monitoring)
        {
            try
            {
                _client = new ConfigureLspClient(_request.DriversLicense.ScanData, _request.DriversLicense.UserId);

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
                    new {ContextMessage = "Lsp Data Provider Decrypting Configuration"});

                monitoring.StartCall(_client.Operation, _stopWatch);

                _client.Run();

                monitoring.EndCall(_client.IsSuccessful ? _client.Resonse : "No Response Returned", _stopWatch);

                if (string.IsNullOrWhiteSpace(_client.Resonse))
                    monitoring.Send(CommandType.Fault, _request,
                        new
                        {
                            NoRequestReceived = "No response received from Lsp Service"
                        });

                TransformResponse(response, monitoring);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lsp Data Provider {0}", ex.Message);
                monitoring.Send(CommandType.Fault, ex.Message,
                    new {ErrorMessage = "Error calling Lsp"});
                LspResponseFailed(response);
            }
        }

        private static void LspResponseFailed(IProvideResponseFromLaceDataProviders response)
        {
            response.LspResponse = null;
            response.LspResponseHandled = new LspResponseHandled();
            response.LspResponseHandled.HasBeenHandled();
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendCommandsToBus monitoring)
        {
            var transformer = new TransformLspResponse(_client.Resonse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            monitoring.Send(CommandType.Transformation,
                transformer.Result ?? new LspResponse(null, null), transformer);

            response.LspResponse = transformer.Result;
            response.LspResponseHandled = new LspResponseHandled();
            response.LspResponseHandled.HasBeenHandled();
        }
    }
}
