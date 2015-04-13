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
using Lace.Shared.Extensions;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;
using DataSet = System.Data.DataSet;

namespace Lace.Domain.DataProviders.Lightstone.Business.Infrastructure
{
    public class CallLightstoneBusinessDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.LightstoneBusiness;
        private DataSet _result;

        private readonly string _username = Credentials.LightstoneBusinessApiEmail();
        private readonly string _password = Credentials.LightstoneBusinessApiPassword();

        //public readonly string UserToken;

        public CallLightstoneBusinessDataProvider(ICollection<IPointToLaceRequest> request)
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
                var webService = new ConfigureSource();
                if (webService.Client.State == CommunicationState.Closed)
                    webService.Client.Open();

                // authenticate
                // call authenticateUser to get the UserToke by email and password


                var token = webService.Client.authenticateUser(_username, _password);

                var request = new GetBusinessRequest(_request.GetFromRequest<IHaveBusiness>())
                    .Map()
                    .Validate();

                command.Workflow.Send(CommandType.Configuration, request, null, Provider);


                if (!request.RequestIsValid)
                    throw new Exception(
                        string.Format(
                            "Minimum requirements for Lightstone Business request has not been met with user_token {0} ",
                            request.UserToken));

                command.Workflow.DataProviderRequest(Provider,
                    "API", webService.Client.Endpoint.Address.ToString(), DataProviderAction.Request,
                    DataProviderState.Successful, new {request},
                    _stopWatch, _request.GetFromRequest<IAmDataProvider>().CostPrice, _request.GetFromRequest<IAmDataProvider>().RecommendedPrice);

                _result = webService.Client.returnCompanies(token.ToString(), request.CompanyName, request.CompanyRegnum,
                    request.CompanyVatnumber);

                webService.CloseSource();

                command.Workflow.DataProviderResponse(Provider,
                    "API", webService.Client.Endpoint.Address.ToString(), DataProviderAction.Response,
                    _result != null ? DataProviderState.Successful : DataProviderState.Failed, new {_result},
                    _stopWatch, _request.GetFromRequest<IAmDataProvider>().CostPrice, _request.GetFromRequest<IAmDataProvider>().RecommendedPrice);

                TransformResponse(response, command);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Business Data Provider {0}", ex.Message);
                command.Workflow.Send(CommandType.Fault, ex.Message,
                    new {ErrorMessage = "Error calling Lightstone Business Data Provider"}, Provider);
                LightstoneBusinessResponseFailed(response);
            }
        }

        private static void LightstoneBusinessResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var lightstoneBusinessResponse = new LightstoneBusinessResponse();
            lightstoneBusinessResponse.HasBeenHandled();
            response.Add(lightstoneBusinessResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response,
            ISendCommandToBus command)
        {
            var transformer = new TransformLightstoneBusinessResponse(_result);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            command.Workflow.Send(CommandType.Transformation,
                transformer.Result ?? new LightstoneBusinessResponse(new List<IRespondWithBusiness>()), transformer,Provider);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
