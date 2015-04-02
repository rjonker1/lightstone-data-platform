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
                var ividTitleHolderWebService = new ConfigureIvidTitleHolderSource();

                using (
                    var scope = new OperationContextScope(ividTitleHolderWebService.IvidTitleHolderProxy.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ividTitleHolderWebService.IvidTitleHolderRequestMessageProperty;

                    var request = new IvidTitleHolderRequestMessage(_request.GetFromRequest<IPointToVehicleRequest>().User, response)
                        .TitleholderQueryRequest;

                    command.Monitoring.Send(CommandType.Configuration, request, null);

                    command.Monitoring.StartCall(request, _stopWatch);

                    _response = ividTitleHolderWebService
                        .IvidTitleHolderProxy
                        .TitleholderQuery(request);

                    ividTitleHolderWebService
                        .CloseWebService();

                    command.Monitoring.EndCall(_response ?? new TitleholderQueryResponse(), _stopWatch);

                    if (_response == null)
                        command.Monitoring.Send(CommandType.Fault, _request,
                            new {NoRequestReceived = "No response received from Ivid Title Holder Data Provider"});

                    TransformResponse(response, command);
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Ivid Title Holder Data Provider {0}", ex.Message);
                command.Monitoring.Send(CommandType.Fault, ex.Message,
                    new {ErrorMessage = "Error calling Ivid Title Holder Data Provider"});
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

            command.Monitoring.Send(CommandType.Transformation, transformer.Result, transformer);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
