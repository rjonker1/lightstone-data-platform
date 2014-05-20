﻿using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Common.Logging;
using EventTracking.Sources;
using Lace.Events;
using Lace.Functions.Json;
using Lace.Models.Ivid;
using Lace.Request;
using Lace.Response;
using Lace.Source.Ivid.IvidServiceReference;
using Lace.Source.Ivid.ServiceConfig;
using Lace.Source.Ivid.Transform;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class CallIvidExternalWebService : ICallTheExternalWebService
    {
        private HpiStandardQueryResponse _ividResponse;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ILaceRequest _request;
        private const FromSource Source = FromSource.IvidSource;

        public CallIvidExternalWebService(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalWebService(ILaceResponse response, ILaceEvent laceEvent)
        {
            try
            {
                laceEvent.PublishStartServiceConfigurationMessage(_request.Token, Source);

                var ividWebService = new ConfigureIvidWebService();

                ividWebService.ConfigureIvidWebServiceCredentials();
                ividWebService.ConfigureIvidWebServiceRequestMessageProperty();


                using (var scope = new OperationContextScope(ividWebService.IvidServiceProxy.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ividWebService.IvidRequestMessageProperty;

                    var ividRequest = new ConfigureIvidRequestMessage(_request)
                        .HpiQueryRequest;

                    laceEvent.PublishEndServiceConfigurationMessage(_request.Token, Source);

                    laceEvent.PublishServiceRequestMessage(_request.Token, Source,
                        JsonFunctions.JsonFunction.ObjectToJson(ividRequest));

                    laceEvent.PublishStartServiceCallMessage(_request.Token, Source);

                    _ividResponse = ividWebService
                        .IvidServiceProxy
                        .HpiStandardQuery(ividRequest);

                    laceEvent.PublishEndServiceCallMessage(_request.Token, Source);

                    ividWebService.CloseWebService();

                    if (_ividResponse == null)
                        laceEvent.PublishNoResponseFromServiceMessage(_request.Token, Source);

                    laceEvent.PublishServiceResponseMessage(_request.Token, Source,
                        JsonFunctions.JsonFunction.ObjectToJson(_ividResponse ?? new HpiStandardQueryResponse()));

                    TransformWebResponse(response);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Ivid Web Service {0}", ex.Message);
                laceEvent.PublishFailedServiceCallMessaage(_request.Token, Source);
                IvidResponseFailed(response);
            }
        }

        private static void IvidResponseFailed(ILaceResponse response)
        {
            response.IvidResponse = null;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasBeenHandled();
        }

        public void TransformWebResponse(ILaceResponse response)
        {
            var transformer = new TransformIvidWebResponse(_ividResponse);

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