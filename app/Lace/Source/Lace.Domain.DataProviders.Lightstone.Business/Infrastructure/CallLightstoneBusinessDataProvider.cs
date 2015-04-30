using System;
using System.Collections.Generic;
using System.ServiceModel;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Lightstone.Business.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Lightstone.Business.Infrastructure.Dto;
using Lace.Domain.DataProviders.Lightstone.Business.Infrastructure.Management;
using Workflow.Lace.Identifiers;
using DataSet = System.Data.DataSet;

namespace Lace.Domain.DataProviders.Lightstone.Business.Infrastructure
{
    public class CallLightstoneBusinessDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogComandTypes _logComand;


        private DataSet _result;

        private readonly string _username = Credentials.LightstoneBusinessApiEmail();
        private readonly string _password = Credentials.LightstoneBusinessApiPassword();

        public CallLightstoneBusinessDataProvider(IAmDataProvider dataProvider, ILogComandTypes logComand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _logComand = logComand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                var webService = new ConfigureSource();
                if (webService.Client.State == CommunicationState.Closed)
                    webService.Client.Open();

                // authenticate
                // call authenticateUser to get the UserToke by email and password

                var token = webService.Client.authenticateUser(_username, _password);

                var request =
                    new GetBusinessRequest()
                        //TODO: uncomment after updating package builder requests nuget new GetBusinessRequest(_dataProvider.GetRequest<IAmBusinessRequest>)
                        .Map()
                        .Validate();
                _logComand.LogConfiguration(new {request}, null);

                if (!request.RequestIsValid)
                    throw new Exception(
                        string.Format(
                            "Minimum requirements for Lightstone Business request has not been met with user_token {0} ",
                            request.UserToken));

                _logComand.LogRequest(new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString()).ForWebApiType(), new {request});

                _result = webService.Client.returnCompanies(token.ToString(), request.CompanyName, request.CompanyRegnum,
                    request.CompanyVatnumber);

                webService.CloseSource();
                _logComand.LogResponse(_result != null ? DataProviderState.Successful : DataProviderState.Failed,
                    new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString()).ForWebApiType(), new {_result});

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Business Data Provider {0}", ex.Message);
                _logComand.LogFault(ex.Message, new {ErrorMessage = "Error calling Lightstone Business Data Provider"});
                LightstoneBusinessResponseFailed(response);
            }
        }

        private static void LightstoneBusinessResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var lightstoneBusinessResponse = new LightstoneBusinessResponse();
            lightstoneBusinessResponse.HasBeenHandled();
            response.Add(lightstoneBusinessResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformLightstoneBusinessResponse(_result);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logComand.LogTransformation(transformer.Result ?? new LightstoneBusinessResponse(new List<IRespondWithBusiness>()), null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
