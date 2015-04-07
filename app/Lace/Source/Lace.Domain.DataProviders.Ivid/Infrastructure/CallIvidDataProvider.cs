using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Dto;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Extensions;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure
{
    public class CallIvidDataProvider : ICallTheDataProviderSource
    {
        private HpiStandardQueryResponse _response;
        private readonly ILog _log;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.Ivid;

        public CallIvidDataProvider(ICollection<IPointToLaceRequest> request)
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
                var ividWebService = new ConfigureIvidSource();

                command.Monitoring.Send(CommandType.Security,
                    new
                    {
                        Credentials =
                            new
                            {
                                ividWebService.IvidServiceProxy.ClientCredentials.UserName.UserName,
                                ividWebService.IvidServiceProxy.ClientCredentials.UserName.Password
                            }
                    },
                    new {ContextMessage = "Ivid Data Provider Credentials"});

                using (var scope = new OperationContextScope(ividWebService.IvidServiceProxy.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ividWebService.IvidRequestMessageProperty;

                    var request = new IvidRequestMessage(_request.GetFromRequest<IPointToVehicleRequest>().User, _request.GetFromRequest<IPointToVehicleRequest>().Vehicle, _request.GetFromRequest<IPointToVehicleRequest>().Package.Name)
                        .HpiQueryRequest;

                    command.Monitoring.Send(CommandType.Configuration, request, null);

                    command.Monitoring.StartCall(request, _stopWatch);

                    _response = ividWebService
                        .IvidServiceProxy
                        .HpiStandardQuery(request);

                    ividWebService.CloseWebService();

                    command.Monitoring.EndCall(_response ?? new HpiStandardQueryResponse(), _stopWatch);

                    if (_response == null)
                        command.Monitoring.Send(CommandType.Fault, _request,
                            new {NoRequestReceived = "No response received from Ivid Data Provider"});

                    TransformResponse(response, command);
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Ivid Data Provider {0}", ex.Message);
                command.Monitoring.Send(CommandType.Fault, ex.Message, new {ErrorMessage = "Error calling Ivid Data Provider"});
                IvidResponseFailed(response);
            }
        }

        private static void IvidResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var ividResponse = new IvidResponse();
            ividResponse.HasBeenHandled();
            response.Add(ividResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response,
            ISendCommandToBus command)
        {
            var transformer = new TransformIvidResponse(_response);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            command.Monitoring.Send(CommandType.Transformation, transformer.Result, transformer);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
