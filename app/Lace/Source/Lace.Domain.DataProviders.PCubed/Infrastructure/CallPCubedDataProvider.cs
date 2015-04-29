using System;
using System.Collections.Generic;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.PCubed.Infrastructure.Management;
using Workflow.Lace.Domain;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Domain.DataProviders.PCubed.Infrastructure
{
    public class CallPCubedDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.PCubedFica;
        private string _response;

        public CallPCubedDataProvider(ICollection<IPointToLaceRequest> request)
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
                //command.Monitoring.Send(CommandType.Configuration,
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
                //    new { ContextMessage = "PCubed Fica Data Provider Configuration" });

                //command.Monitoring.StartCall(_client.Operation, _stopWatch);

                //_client.Run();

                //command.Monitoring.EndCall(_client.IsSuccessful ? _client.Resonse : "No Response Returned", _stopWatch);

                _response = string.Empty;

                if (string.IsNullOrWhiteSpace(_response))
                    command.Workflow.Send(CommandType.Fault, _request,
                        new
                        {
                            NoRequestReceived = "No response received from PCubed Fica Service"
                        }, DataProviderCommandSource.PCubedFica);

                TransformResponse(response, command);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling PCubed Fica Data Provider {0}", ex.Message);
                command.Workflow.Send(CommandType.Fault, ex.Message,
                    new {ErrorMessage = "Error calling PCubed Fica Data Provider"}, DataProviderCommandSource.PCubedFica);
                SignioResponseFailed(response);
            }
        }

        private static void SignioResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var ficaVerficationResponse = new PCubedFicaVerficationResponse();
            ficaVerficationResponse.HasNotBeenHandled();
            response.Add(ficaVerficationResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response, ISendCommandToBus command)
        {
            var transformer = new TransformPCubedResponse(_response);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            command.Workflow.Send(CommandType.Transformation, transformer.Result, null,
                DataProviderCommandSource.PCubedFica);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
