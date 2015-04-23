using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Dto;
using Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Management;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Entities.Enums.DataProviders;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Domain.DataProviders.Lightstone.Property.Infrastructure
{
    public class CallLightstonePropertyDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.LightstoneProperty;
        private DataSet _result;

        public CallLightstonePropertyDataProvider(ICollection<IPointToLaceRequest> request)
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

                var request = new GetPropertyRequest(_request.GetFromRequest<IHaveProperty>())
                    .Map()
                    .Validate();

                command.Workflow.Send(Workflow.Lace.Messages.Core.CommandType.Configuration, request, null, Provider);


                if (!request.RequestIsValid)
                    throw new Exception(
                        string.Format(
                            "Minimum requirements for Lightstone Property request has not been met with User id {0} and  Id or CK {1} and Max Rows to Return {2} and Tracking Number {3}",
                            request.UserId, request.IdCkOfOwner, request.MaxRowsToReturn, request.TrackingNumber));

                command.Workflow.DataProviderRequest(new DataProviderIdentifier(Provider, DataProviderAction.Request,
                    DataProviderState.Successful).SetPrice(_request.GetFromRequest<IPointToLaceRequest>().Package.DataProviders
                        .Single(s => s.Name == DataProviderName.LightstoneProperty)),
                    new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString()).ForWebApiType(),
                    new {request},
                    _stopWatch);

                _result = webService.Client.ReturnProperties(request.UserId, request.Province, request.Municipality,
                    request.DeedTown,
                    request.ErfNumber, request.Portion, request.SectionalTitle, request.Unit, request.Suburb,
                    request.Street,
                    request.StreetNumber, request.OwnerName, request.IdCkOfOwner, request.EstateName, request.FarmName,
                    request.MaxRowsToReturn, request.TrackingNumber);

                webService.CloseSource();

                command.Workflow.DataProviderResponse(new DataProviderIdentifier(Provider, DataProviderAction.Response,
                     _result != null ? DataProviderState.Successful : DataProviderState.Failed)
                    .SetPrice(_request.GetFromRequest<IPointToLaceRequest>().Package.DataProviders
                        .Single(s => s.Name == DataProviderName.LightstoneProperty)),
                    new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString())
                        .ForWebApiType(), new {_result},
                    _stopWatch);

                TransformResponse(response, command);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Property Data Provider {0}", ex.Message);
                command.Workflow.Send(Workflow.Lace.Messages.Core.CommandType.Fault, ex.Message,
                    new {ErrorMessage = "Error calling Lightstone Property Data Provider"}, Provider);
                LightstonePropertyResponseFailed(response);
            }
        }

        private static void LightstonePropertyResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var lightstonePropertyResponse = new LightstonePropertyResponse();
            lightstonePropertyResponse.HasBeenHandled();
            response.Add(lightstonePropertyResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response,
            ISendCommandToBus command)
        {
            var transformer = new TransformLightstonePropertyResponse(_result);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            command.Workflow.Send(Workflow.Lace.Messages.Core.CommandType.Transformation,
                transformer.Result ?? new LightstonePropertyResponse(new List<PropertyModel>()), null,Provider);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
