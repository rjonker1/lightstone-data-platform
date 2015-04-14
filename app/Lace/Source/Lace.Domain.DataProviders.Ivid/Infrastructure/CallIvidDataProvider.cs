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
using PackageBuilder.Domain.Entities.Enums.DataProviders;
using Workflow.Lace.Identifiers;
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
                var webService = new ConfigureIvid();

                command.Workflow.Send(CommandType.Security,
                    new
                    {
                        Credentials =
                            new
                            {
                                webService.Client.ClientCredentials.UserName.UserName,
                                webService.Client.ClientCredentials.UserName.Password
                            }
                    },
                    new {ContextMessage = "Ivid Data Provider Credentials"}, Provider);

                using (var scope = new OperationContextScope(webService.Client.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        webService.RequestMessageProperty;

                    var request =
                        new IvidRequestMessage(_request.GetFromRequest<IPointToVehicleRequest>().User,
                            _request.GetFromRequest<IPointToVehicleRequest>().Vehicle,
                            _request.GetFromRequest<IPointToVehicleRequest>().Package.Name)
                            .HpiQueryRequest;

                    command.Workflow.Send(CommandType.Configuration, request, null, Provider);

                    command.Workflow.DataProviderRequest(
                        new DataProviderIdentifier(Provider, DataProviderAction.Request, DataProviderState.Successful)
                            .SetPrice(
                                _request.GetFromRequest<IPointToLaceRequest>().Package.DataProviders
                                    .Single(s => s.Name == DataProviderName.Ivid)),
                        new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString())
                            .ForWebApiType(), request, _stopWatch);

                    _response = webService
                        .Client
                        .HpiStandardQuery(request);

                    webService.CloseWebService();

                    command.Workflow.DataProviderResponse(
                        new DataProviderIdentifier(Provider, DataProviderAction.Response, CheckState())
                            .SetPrice(
                                _request.GetFromRequest<IPointToLaceRequest>().Package.DataProviders
                                    .Single(s => s.Name == DataProviderName.Ivid)),
                        new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString())
                            .ForWebApiType(), _response ?? new HpiStandardQueryResponse(), _stopWatch);

                    if (_response == null)
                        command.Workflow.Send(CommandType.Fault, _request,
                            new {NoRequestReceived = "No response received from Ivid Data Provider"}, Provider);

                    TransformResponse(response, command);
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Ivid Data Provider {0}", ex.Message);
                command.Workflow.Send(CommandType.Fault, ex.Message,
                    new {ErrorMessage = "Error calling Ivid Data Provider"}, Provider);
                IvidResponseFailed(response);
            }
        }

        private DataProviderState CheckState()
        {
            return _response == null
                ? DataProviderState.Failed
                : _response.partialResponse ? DataProviderState.PartialFailure : DataProviderState.Successful;
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

            command.Workflow.Send(CommandType.Transformation, transformer.Result, transformer,Provider);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
