﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Audatex.AudatexServiceReference;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Management;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Shared.Extensions;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Domain.DataProviders.Audatex.Infrastructure
{
    public class CallAudatexDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private GetDataResult _response;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.Audatex;

        private readonly ISendCommandToBus command; //TODO:remove

        public CallAudatexDataProvider(ICollection<IPointToLaceRequest> request)
        {
            _log = LogManager.GetLogger(GetType());
            _request = request;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                var webService = new ConfigureAudatex()
                    .Create();

                var request = new ConfigureRequestMessage(response)
                    .Build()
                    .AudatexRequest;

                command.Workflow.Send(CommandType.Configuration,
                    new
                    {
                        EndPoint =
                            new
                            {
                                webService.Client.Endpoint,
                                webService.Client.State
                            }
                    }, request, Provider);

                command.Workflow.DataProviderRequest(new DataProviderIdentifier(Provider, DataProviderAction.Request,
                    DataProviderState.Successful).SetPrice(_request.GetFromRequest<IPointToLaceRequest>().Package.DataProviders
                        .Single(s => s.Name == DataProviderName.Audatex)),
                    new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString()).ForWebApiType(), request,
                    _stopWatch);

                _response = webService
                    .Client
                    .GetDataEx(GetCredentials(), request.MessageType, request.Message, 0);

                command.Workflow.DataProviderResponse(new DataProviderIdentifier(Provider, DataProviderAction.Response,
                    _response != null ? DataProviderState.Successful : DataProviderState.Failed).SetPrice(_request.GetFromRequest<IPointToLaceRequest>().Package.DataProviders
                        .Single(s => s.Name == DataProviderName.Audatex)),
                    new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString()).ForWebApiType(), _response,
                    _stopWatch);

                webService.Close();

                if (_response == null)
                    command.Workflow.Send(CommandType.Fault, _request,
                        new {NoRequestReceived = "No response received from Audatex Data Provider"}, Provider);

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Audatex Data Provider {0}", ex.Message);
                command.Workflow.Send(CommandType.Fault, ex.Message,
                    new {ErrorMessage = "Error calling Audatex Data Provider"}, Provider);
                AudatexResponseFailed(response);
            }
        }

        private static void AudatexResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var audatexResponse = new AudatexResponse();
            audatexResponse.HasBeenHandled();
            response.Add(audatexResponse);
        }

        private static CredentialsInfo GetCredentials()
        {
            return new CredentialsInfo()
            {
                CompanyCode = Credentials.AudatexCompanyCode(),
                Password = Credentials.AudatexPassword(),
                UserId = Credentials.AudatexUserId()
            };
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformAudatexResponse(_response, response, _request.GetFromRequest<IHaveVehicle>());

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            command.Workflow.Send(CommandType.Transformation, transformer.Result, null, Provider);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
