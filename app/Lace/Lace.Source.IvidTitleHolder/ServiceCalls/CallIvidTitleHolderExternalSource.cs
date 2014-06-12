using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Common.Logging;
using Lace.Events;
using Lace.Functions.Json;
using Lace.Models.IvidTitleHolder;
using Lace.Request;
using Lace.Response;
using Lace.Source.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Source.IvidTitleHolder.ServiceConfig;
using Lace.Source.IvidTitleHolder.Transform;
using Monitoring.Sources;
using Monitoring.Sources.Lace;

namespace Lace.Source.IvidTitleHolder.ServiceCalls
{
    public class CallIvidTitleHolderExternalSource : ICallTheExternalSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private TitleholderQueryResponse _ividTitleHolderResponse;
        private readonly ILaceRequest _request;
        private const ExternalSource Source = ExternalSource.IvitTitleHolderSource;

        public CallIvidTitleHolderExternalSource(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalWebService(ILaceResponse response, ILaceEvent laceEvent)
        {
            try
            {
                laceEvent.PublishStartServiceConfigurationMessage(_request.RequestAggregation.AggregateId, Source);

                var ividTitleHolderWebService = new ConfigureIvidTitleHolderSource();

                ividTitleHolderWebService.ConfigureIvidTitleHolderServiceCredentials();
                ividTitleHolderWebService.ConfigureIvidTitleHolderWebServiceRequestMessageProperty();

                using (var scope = new OperationContextScope(ividTitleHolderWebService.IvidTitleHolderProxy.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ividTitleHolderWebService.IvidTitleHolderRequestMessageProperty;

                    laceEvent.PublishEndServiceConfigurationMessage(_request.RequestAggregation.AggregateId, Source);

                    var ividTitleHolderRequest = new ConfigureIvidTitleHolderRequestMessage(_request)
                        .TitleholderQueryRequest;

                    laceEvent.PublishServiceRequestMessage(_request.RequestAggregation.AggregateId, Source,
                        JsonFunctions.JsonFunction.ObjectToJson(ividTitleHolderRequest));

                    laceEvent.PublishStartServiceCallMessage(_request.RequestAggregation.AggregateId, Source);

                    _ividTitleHolderResponse = ividTitleHolderWebService
                        .IvidTitleHolderProxy
                        .TitleholderQuery(ividTitleHolderRequest);

                    laceEvent.PublishEndServiceCallMessage(_request.RequestAggregation.AggregateId, Source);

                    ividTitleHolderWebService
                        .CloseWebService();

                    if (_ividTitleHolderResponse == null)
                        laceEvent.PublishNoResponseFromServiceMessage(_request.RequestAggregation.AggregateId, Source);


                    laceEvent.PublishServiceResponseMessage(_request.RequestAggregation.AggregateId, Source,
                      JsonFunctions.JsonFunction.ObjectToJson(_ividTitleHolderResponse ?? new TitleholderQueryResponse()));

                    TransformWebResponse(response);
                }

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Ivid Title Holder Web Service {0}", ex.Message);
                laceEvent.PublishFailedServiceCallMessaage(_request.RequestAggregation.AggregateId, Source);
                IvidTitleHolderResponseFailed(response);
            }
        }

        private static void IvidTitleHolderResponseFailed(ILaceResponse response)
        {
            response.IvidTitleHolderResponse = null;
            response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            response.IvidTitleHolderResponseHandled.HasBeenHandled();
        }
        
        public void TransformWebResponse(ILaceResponse response)
        {
            var transformer = new TransformIvidTitleHolderResponse(_ividTitleHolderResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.IvidTitleHolderResponse = transformer.Result;
            response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            response.IvidTitleHolderResponseHandled.HasBeenHandled();
        }
    }
}
