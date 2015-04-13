using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Configuration;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Dto;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Management;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Shared.Extensions;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure
{
    public class CallIvidTitleHolderDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private TitleholderQueryResponse _response;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.IvidTitleHolder;

        public CallIvidTitleHolderDataProvider(ICollection<IPointToLaceRequest> request)
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
                var webService = new ConfigureIvidTitleHolder();

                using (
                    var scope = new OperationContextScope(webService.Client.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        webService.RequestMessageProperty;

                    var request =
                        new IvidTitleHolderRequestMessage(_request.GetFromRequest<IPointToVehicleRequest>().User,
                            response)
                            .TitleholderQueryRequest;

                    command.Workflow.Send(CommandType.Configuration, request, null, Provider);

                    command.Workflow.DataProviderRequest(Provider, "API",
                        webService.Client.Endpoint.Address.ToString(), DataProviderAction.Request,
                        DataProviderState.Successful, _request, _stopWatch, _request.GetFromRequest<IAmDataProvider>().CostPrice, _request.GetFromRequest<IAmDataProvider>().RecommendedPrice);

                    _response = webService
                        .Client
                        .TitleholderQuery(request);

                    webService
                        .CloseWebService();

                    command.Workflow.DataProviderResponse(Provider, "API",
                        webService.Client.Endpoint.Address.ToString(), DataProviderAction.Response,
                        _response == null ? DataProviderState.Failed : DataProviderState.Successful,
                        _response ?? new TitleholderQueryResponse(), _stopWatch, _request.GetFromRequest<IAmDataProvider>().CostPrice, _request.GetFromRequest<IAmDataProvider>().RecommendedPrice);

                    if (_response == null)
                        command.Workflow.Send(CommandType.Fault, _request,
                            new {NoRequestReceived = "No response received from Ivid Title Holder Data Provider"},
                            Provider);

                    TransformResponse(response, command);
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Ivid Title Holder Data Provider {0}", ex.Message);
                command.Workflow.Send(CommandType.Fault, ex.Message,
                    new { ErrorMessage = "Error calling Ivid Title Holder Data Provider" }, Provider);
                IvidTitleHolderResponseFailed(response);
            }
        }

        private static void IvidTitleHolderResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var ividTitleHolderResponse = new IvidTitleHolderResponse();
            ividTitleHolderResponse.HasBeenHandled();
            response.Add(ividTitleHolderResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response,
            ISendCommandToBus command)
        {
            var transformer = new TransformIvidTitleHolderResponse(_response);

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
