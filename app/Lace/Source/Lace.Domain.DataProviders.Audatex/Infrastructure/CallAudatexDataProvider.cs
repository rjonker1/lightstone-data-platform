﻿using System;
using System.Collections.Generic;
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

        public CallAudatexDataProvider(ICollection<IPointToLaceRequest> request)
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
                var audatexWebService = new ConfigureAudatexSource()
                    .Create();

                var request = new ConfigureAudatexRequestMessage(response)
                    .Build()
                    .AudatexRequest;

                command.Monitoring.Send(CommandType.Configuration,
                    new
                    {
                        EndPoint =
                            new
                            {
                                audatexWebService.AudatexServiceProxy.Endpoint,
                                audatexWebService.AudatexServiceProxy.State
                            }
                    }, request);

                command.Monitoring.StartCall(request, _stopWatch);

                _response = audatexWebService
                    .AudatexServiceProxy
                    .GetDataEx(GetCredentials(), request.MessageType, request.Message, 0);

                command.Monitoring.EndCall(_response ?? new GetDataResult(), _stopWatch);

                audatexWebService
                    .Close();

                if (_response == null)
                    command.Monitoring.Send(CommandType.Fault, _request,
                        new {NoRequestReceived = "No response received from Audatex Data Provider"});

                TransformResponse(response, command);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Audatex Data Provider {0}", ex.Message);
                command.Monitoring.Send(CommandType.Fault, ex.Message,
                    new {ErrorMessage = "Error calling Audatex Data Provider"});
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

        public void TransformResponse(ICollection<IPointToLaceProvider> response, ISendCommandToBus command)
        {
            var transformer = new TransformAudatexResponse(_response, response, _request.GetFromRequest<IHaveVehicle>());

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
