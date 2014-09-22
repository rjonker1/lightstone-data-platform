using System;
using System.ServiceModel;
using Common.Logging;
using Lace.Events;
using Lace.Models;
using Lace.Models.Anpr;
using Lace.Request;
using Lace.Source.Anpr.AnprWebService;
using Lace.Source.Anpr.Configuration;
using Lace.Source.Anpr.Factory;
using Lace.Source.Anpr.Repository.Factory;
using Lace.Source.Anpr.Transform;
using Monitoring.Sources.Lace;

namespace Lace.Source.Anpr.SourceCalls
{
    public class CallAnprExternalSource : ICallTheSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private const LaceEventSource Source = LaceEventSource.Anpr;

        private readonly ILaceRequest _request;
        private readonly ISetupRepository _repository;
        private IProvideCertificate _certificate;
        private AnprResComplexType _anprResponse;
        
        public CallAnprExternalSource(ILaceRequest request,ISetupRepository repository)
        {
            _request = request;
            _repository = repository;
        }

        public void CallTheExternalSource(IProvideLaceResponse response, ILaceEvent laceEvent)
        {
            try
            {
                _certificate = new CertificateFactory(_request, _repository);

                if (!_certificate.IsSuccessfull || _certificate.Certificate == null)
                    AnprResponseFailed(response);
                
                var proxy = new AnprServiceSoapClient(_certificate.Certificate.Endpoint);
                if(proxy.State == CommunicationState.Closed)
                    proxy.Open();

                var builder = new BuildAnprRequest(_request).Build();
                _anprResponse = proxy.AnprProcessRecognition(builder.AnprRequest);

                TransformResponse(response);

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Anpr Web Service {0}", ex.Message);
                laceEvent.PublishFailedSourceCallMessage(Source);
                AnprResponseFailed(response);
            }
        }

        public void TransformResponse(IProvideLaceResponse response)
        {
            var transformer = new TransformAnprResponse(_anprResponse, _request.RequestAggregation.AggregateId);
            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.AnprResponse = transformer.Result;
            response.AnprResponseHandled = new AnprResponseHandled();
            response.AnprResponseHandled.HasBeenHandled();
        }

        private static void AnprResponseFailed(IProvideLaceResponse response)
        {
            response.AnprResponse = null;
            response.AnprResponseHandled = new AnprResponseHandled();
            response.AnprResponseHandled.HasBeenHandled();
        }
    }
}
