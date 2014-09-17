using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Common.Logging;
using Lace.Events;
using Lace.Extensions;
using Lace.Models;
using Lace.Models.Ivid;
using Lace.Request;
using Lace.Source.Ivid.IvidServiceReference;
using Lace.Source.Ivid.ServiceConfig;
using Lace.Source.Ivid.Transform;
using Monitoring.Sources.Lace;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class CallIvidExternalSource : ICallTheSource
    {
        private HpiStandardQueryResponse _ividResponse;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ILaceRequest _request;
        private const LaceEventSource Source = LaceEventSource.Ivid;

        public CallIvidExternalSource(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalSource(IProvideLaceResponse response, ILaceEvent laceEvent)
        {
            try
            {
                laceEvent.PublishStartSourceConfigurationMessage(Source);

                var ividWebService = new ConfigureIvidSource();

                ividWebService.ConfigureIvidWebServiceCredentials();
                ividWebService.ConfigureIvidWebServiceRequestMessageProperty();


                using (var scope = new OperationContextScope(ividWebService.IvidServiceProxy.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ividWebService.IvidRequestMessageProperty;

                    var ividRequest = new ConfigureIvidRequestMessage(_request)
                    .Build()
                    .HpiQueryRequest;

                    laceEvent.PublishEndSourceConfigurationMessage(Source);

                    laceEvent.PublishSourceRequestMessage(Source,
                        ividRequest.ObjectToJson());

                    laceEvent.PublishStartSourceCallMessage(Source);

                    _ividResponse = ividWebService
                        .IvidServiceProxy
                        .HpiStandardQuery(ividRequest);

                    laceEvent.PublishEndSourceCallMessage(Source);

                    ividWebService.CloseWebService();

                    if (_ividResponse == null)
                        laceEvent.PublishNoResponseFromSourceMessage(Source);

                    laceEvent.PublishSourceResponseMessage(Source,
                        _ividResponse != null ? _ividResponse.ObjectToJson() : new HpiStandardQueryResponse().ObjectToJson());

                    TransformResponse(response);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Ivid Web Service {0}", ex.Message);
                laceEvent.PublishFailedSourceCallMessage(Source);
                IvidResponseFailed(response);
            }
        }

        private static void IvidResponseFailed(IProvideLaceResponse response)
        {
            response.IvidResponse = null;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasBeenHandled();
        }

        public void TransformResponse(IProvideLaceResponse response)
        {
            var transformer = new TransformIvidResponse(_ividResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.IvidResponse = transformer.Result;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasBeenHandled();
        }
    }
}
