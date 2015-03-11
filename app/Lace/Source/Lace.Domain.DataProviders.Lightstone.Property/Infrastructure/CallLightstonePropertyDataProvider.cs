using System;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Management;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;

namespace Lace.Domain.DataProviders.Lightstone.Property.Infrastructure
{
    public class CallLightstonePropertyDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly ILaceRequest _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.Lsp;
        private ConfigureLightstonePropertyClient _client;

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

                var prop = _request.Property;

                //var content =
                //    string.Format(
                //        "User_ID={0}&Province={1}&Municipality={2}&DeedTown={3}&Erf={4}&Portion={5}&Sectional_Title=s{6}&Unit={7}&Suburb={8}&Street={9}&StreetNumber={10}&Owner_Name={11}&ID_CK={12}&Estate_Name={13}&FARM_NAME={14}&MaxRowsToReturn={15}&TrackingNumber={16}",
                //        _request.User.UserId.ToString(),
                //        prop.Municipality,
                //        prop.DeedTown,
                //        prop.Erf,
                //        prop.Portion,
                //        prop.SectionalTitle,
                //        prop.Unit,
                //        prop.Suburb,
                //        prop.Street,
                //        prop.StreetNumber,
                //        prop.OwnerName,
                //        prop.IdCkOfOwner,
                //        prop.EstateName,
                //        prop.FARM_NAME,
                //        prop.MaxRowsToReturn,
                //        prop.TrackingNumber
                //        );


                //_client = new ConfigureLightstonePropertyClient(content, _request.User.UserId);

                monitoring.Send(CommandType.Configuration,
                    new
                    {
                        Configuration =
                            new
                            {
                                _client.Url,
                                _client.Username,
                                _client.Password,
                                _client.XAuthToken,
                                _client.Operation
                            }
                    },
                    new { ContextMessage = "Lightstone Property Data Provider Decrypting Configuration" });

                monitoring.StartCall(_client.Operation, _stopWatch);

                _client.Run();

                monitoring.EndCall(_client.IsSuccessful ? _client.Resonse : "No Response Returned", _stopWatch);

                if (string.IsNullOrWhiteSpace(_client.Resonse))
                    monitoring.Send(CommandType.Fault, _request,
                        new
                        {
                            NoRequestReceived = "No response received from Lightstone Property Service"
                        });

                TransformResponse(response, monitoring);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Property Data Provider {0}", ex.Message);
                monitoring.Send(CommandType.Fault, ex.Message,
                    new { ErrorMessage = "Error calling Lightstone Property" });
                LightstonePropertyResponseFailed(response);
            }
        }

        private static void LightstonePropertyResponseFailed(IProvideResponseFromLaceDataProviders response)
        {
            response.LightstonePropertyResponse = null;
            response.LighttonePropertyResponseHandled = new LightstonePropertyResponseHandled();
            response.LighttonePropertyResponseHandled.HasBeenHandled();
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendMonitoringCommandsToBus monitoring)
        {
            var transformer = new TransformLightstonePropertyResponse(_client.Resonse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            monitoring.Send(CommandType.Transformation,
                transformer.Result ?? new LightstonePropertyResponse(null, null), transformer);

            response.LightstonePropertyResponse = transformer.Result;
            response.LighttonePropertyResponseHandled = new LightstonePropertyResponseHandled();
            response.LighttonePropertyResponseHandled.HasBeenHandled();
        }
    }
}
