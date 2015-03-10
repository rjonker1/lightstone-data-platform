using System;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.PCubed.Infrastructure.Management;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;

namespace Lace.Domain.DataProviders.PCubed.Infrastructure
{
    public class CallPCubedDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly ILaceRequest _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.PCubedFica;
        private string _response;

        public CallPCubedDataProvider(ILaceRequest request)
        {
            _log = LogManager.GetLogger(GetType());
            _request = request;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response,
            ISendMonitoringCommandsToBus monitoring)
        {
            try
            {
                //monitoring.Send(CommandType.Configuration,
                //    new
                //    {
                //        Configuration =
                //            new
                //            {
                //                _client.Url,
                //                _client.Username,
                //                _client.Password,
                //                _client.XAuthToken,
                //                _client.Operation
                //            }
                //    },
                //    new {ContextMessage = "PCubed Fica Data Provider Configuration"});

                //monitoring.StartCall(_client.Operation, _stopWatch);

                //_client.Run();

                //monitoring.EndCall(_client.IsSuccessful ? _client.Resonse : "No Response Returned", _stopWatch);

                _response = string.Empty;

                if (string.IsNullOrWhiteSpace(_response))
                    monitoring.Send(CommandType.Fault, _request,
                        new
                        {
                            NoRequestReceived = "No response received from PCubed Fica Service"
                        });

                TransformResponse(response, monitoring);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling PCubed Fica Data Provider {0}", ex.Message);
                monitoring.Send(CommandType.Fault, ex.Message,
                    new {ErrorMessage = "Error calling PCubed Fica Data Provider"});
                SignioResponseFailed(response);
            }
        }

        private static void SignioResponseFailed(IProvideResponseFromLaceDataProviders response)
        {
            response.FicaVerficationResponse = null;
            response.FicaVerficationResponseHandled = new PCubedFicaVerficationResponseHandled();
            response.FicaVerficationResponseHandled.HasBeenHandled();
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendMonitoringCommandsToBus monitoring)
        {
            var transformer = new TransformPCubedResponse(_response);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            monitoring.Send(CommandType.Transformation, transformer.Result, transformer);

            response.FicaVerficationResponse = transformer.Result;
            response.FicaVerficationResponseHandled = new PCubedFicaVerficationResponseHandled();
            response.FicaVerficationResponseHandled.HasBeenHandled();
        }
    }
}
