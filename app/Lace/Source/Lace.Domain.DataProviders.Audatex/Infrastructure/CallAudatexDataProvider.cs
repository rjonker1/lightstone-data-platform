using System;
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
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Audatex.Infrastructure
{
    public class CallAudatexDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private GetDataResult _response;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;

        public CallAudatexDataProvider(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _logCommand = logCommand;
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

                _logCommand.LogConfiguration(new { EndPoint = new { webService.Client.Endpoint, webService.Client.State }}, request);

                _logCommand.LogRequest(new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString()).ForWebApiType(), request);

                _response = webService
                    .Client
                    .GetDataEx(GetCredentials(), request.MessageType, request.Message, 0);

                _logCommand.LogResponse(_response != null ? DataProviderState.Successful : DataProviderState.Failed, new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString()).ForWebApiType(),response);
                
                webService.Close();

                if (_response == null)
                    _logCommand.LogFault(_dataProvider,  new {NoRequestReceived = "No response received from Audatex Data Provider"});

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Audatex Data Provider {0}", ex.Message);
                _logCommand.LogFault(ex.Message, new {ErrorMessage = "Error calling Audatex Data Provider"});
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
            var transformer = new TransformAudatexResponse(); //new TransformAudatexResponse(_response, response, _dataProvider.GetRequest<IAmAudatexRequest>());

            if (transformer.Continue)
            {
                transformer.Transform();
            }
            _logCommand.LogTransformation(transformer.Result, null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
