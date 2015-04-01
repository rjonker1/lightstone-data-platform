using System;
using System.Collections.Generic;
using System.Data;
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
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;
using CommandType = Lace.Shared.Monitoring.Messages.Core.CommandType;

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
            ISendMonitoringCommandsToBus monitoring)
        {
            try
            {
                var client = new ConfigureLighstonePropertySource();
                if (client.Proxy.State == CommunicationState.Closed)
                    client.Proxy.Open();

                var request = new GetPropertyRequest(_request.GetFromRequest<IHavePropertyInformation>())
                    .Map()
                    .Validate();

                monitoring.Send(CommandType.Configuration, request, null);


                if (!request.RequestIsValid)
                    throw new Exception(
                        string.Format(
                            "Minimum requirements for Lightstone Property request has not been met with User id {0} and  Id or CK {1} and Max Rows to Return {2} and Tracking Number {3}",
                            request.UserId, request.IdCkOfOwner, request.MaxRowsToReturn, request.TrackingNumber));

                monitoring.StartCall(request, _stopWatch);

                _result = client.Proxy.ReturnProperties(request.UserId, request.Province, request.Municipality,
                    request.DeedTown,
                    request.ErfNumber, request.Portion, request.SectionalTitle, request.Unit, request.Suburb, request.Street,
                    request.StreetNumber, request.OwnerName, request.IdCkOfOwner, request.EstateName, request.FarmName,
                    request.MaxRowsToReturn, request.TrackingNumber);

                client.CloseSource();

                monitoring.EndCall(_result ?? new DataSet(), _stopWatch);

                TransformResponse(response, monitoring);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Property Data Provider {0}", ex.Message);
                monitoring.Send(CommandType.Fault, ex.Message,
                    new {ErrorMessage = "Error calling Lightstone Property Data Provider"});
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
            ISendMonitoringCommandsToBus monitoring)
        {
            var transformer = new TransformLightstonePropertyResponse(_result);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            monitoring.Send(CommandType.Transformation,
                transformer.Result ?? new LightstonePropertyResponse(new List<PropertyModel>()), transformer);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
