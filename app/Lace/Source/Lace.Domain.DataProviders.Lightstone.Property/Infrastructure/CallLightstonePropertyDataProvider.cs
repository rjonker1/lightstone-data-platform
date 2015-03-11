using System;
using System.Data;
using System.ServiceModel;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Dto;
using Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Management;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;
using CommandType = Lace.Shared.Monitoring.Messages.Core.CommandType;

namespace Lace.Domain.DataProviders.Lightstone.Property.Infrastructure
{
    public class CallLightstonePropertyDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly ILaceRequest _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.LightstoneProperty;
        private DataSet _result;

        public CallLightstonePropertyDataProvider(ILaceRequest request)
        {
            _log = LogManager.GetLogger(GetType());
            _request = request;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response,
            ISendMonitoringCommandsToBus monitoring)
        {
            try
            {

                var client = new ConfigureLighstonePropertySource();
                if(client.Proxy.State == CommunicationState.Closed)
                    client.Proxy.Open();

                var request = new GetPropertiesRequest(_request)
                    .Map()
                    .Validate();

                if (!request.RequestIsValid)
                    throw new Exception(
                        string.Format(
                            "Minimum requirements for Lightstone Property request has not been met with User id {0} and  Id or CK {1} and Max Rows to Return {2} and Tracking Number {3}",
                            request.UserId, request.IdCkOfOwner, request.MaxRowsToReturn, request.TrackingNumber));


                _result = client.Proxy.ReturnProperties(request.UserId, request.Province, request.Municipality, request.DeedTown,
                    request.Erf, request.Portion, request.SectionalTitle, request.Unit, request.Suburb, request.Street,
                    request.StreetNumber, request.OwnerName, request.IdCkOfOwner, request.EstateName, request.FarmName,
                    request.MaxRowsToReturn, request.TrackingNumber);
              


                //_client = new ConfigureLightstonePropertyClient(content, _request.User.UserId);

                //monitoring.Send(CommandType.Configuration,
                //    new
                //    {
                //        Configuration =
                //            new
                //            {
                //                _client.Url,
                //                _client.Username,
                //                _client.Password,
                //                _client.XAuthToken,
                //                _client.Operation
                //            }
                //    },
                //    new { ContextMessage = "Lightstone Property Data Provider Decrypting Configuration" });

                //monitoring.StartCall(_client.Operation, _stopWatch);

                //monitoring.EndCall(_client.IsSuccessful ? _client.Resonse : "No Response Returned", _stopWatch);

                //if (string.IsNullOrWhiteSpace(_client.Resonse))
                //    monitoring.Send(CommandType.Fault, _request,
                //        new
                //        {
                //            NoRequestReceived = "No response received from Lightstone Property Service"
                //        });

                TransformResponse(response, monitoring);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Property Data Provider {0}", ex.Message);
                monitoring.Send(CommandType.Fault, ex.Message,
                    new { ErrorMessage = "Error calling Lightstone Property Data Provider" });
                LightstonePropertyResponseFailed(response);
            }
        }

        private static void LightstonePropertyResponseFailed(IProvideResponseFromLaceDataProviders response)
        {
            response.LightstonePropertyResponse = null;
            response.LightstonePropertyResponseHandled = new LightstonePropertyResponseHandled();
            response.LightstonePropertyResponseHandled.HasBeenHandled();
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendMonitoringCommandsToBus monitoring)
        {
            var transformer = new TransformLightstonePropertyResponse(_result);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            monitoring.Send(CommandType.Transformation,
                transformer.Result ?? new LightstonePropertyResponse(null), transformer);

            response.LightstonePropertyResponse = transformer.Result;
            response.LightstonePropertyResponseHandled = new LightstonePropertyResponseHandled();
            response.LightstonePropertyResponseHandled.HasBeenHandled();
        }
    }
}
