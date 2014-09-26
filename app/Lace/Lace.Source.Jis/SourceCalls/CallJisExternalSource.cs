using System;
using System.ServiceModel;
using Common.Logging;
using Lace.Certificate;
using Lace.Certificate.Factory;
using Lace.Certificate.Models;
using Lace.Certificate.Repository.Factory;
using Lace.Events;
using Lace.Models;
using Lace.Models.Jis;
using Lace.Request;
using Lace.Source.Jis.Builder;
using Lace.Source.Jis.Configuration;
using Lace.Source.Jis.JisServiceReference;
using Lace.Source.Jis.Transform;
using Monitoring.Sources.Lace;

namespace Lace.Source.Jis.SourceCalls
{
    public class CallJisExternalSource : ICallTheSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private const LaceEventSource Source = LaceEventSource.Jis;

        private readonly ILaceRequest _request;
        private readonly ISetupCertificateRepository _repository;
        private IProvideCertificate _certificate;
        private DataStoreResult _jisResponse;
        private SightingUpdateResult _sightingUpdate;

        public CallJisExternalSource(ILaceRequest request, ISetupCertificateRepository repository)
        {
            _request = request;
            _repository = repository;
        }

        public void CallTheExternalSource(IProvideLaceResponse response, ILaceEvent laceEvent)
        {
            try
            {
                _certificate =
                    new CoOrdinateCertificateFactory(
                        new CoOrdinateCertificateRequest(_request.CoOrdinates.Latitude, _request.CoOrdinates.Longitude),
                        _repository);

                if (!_certificate.IsSuccessfull || _certificate.Certificate == null ||
                    string.IsNullOrEmpty(_certificate.Certificate.Endpoint))
                    JisResponseFailed(response);

                var proxy = new JisWsInterfaceSoapClient(_certificate.Certificate.Endpoint);
                if (proxy.State == CommunicationState.Closed)
                    proxy.Open();

                proxy.Connect();

                var session = new SessionManager(proxy, Log, _request).Build().SessionManagement;

                _jisResponse = proxy.DataStoreQuery(session.Id, new BuildJisRequest(_request).JisRequest,
                    _request.User.UserName);

                if (_jisResponse.IsHot)
                {
                    _sightingUpdate =
                        new SightingUpdate(_request, _jisResponse).BuildRequest()
                            .Update(proxy, session)
                            .SightingUpdateResult;
                }

                proxy.Close();

                TransformResponse(response);

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Jis Web Service {0}", ex.Message);
                laceEvent.PublishFailedSourceCallMessage(Source);
                JisResponseFailed(response);
            }
        }

        public void TransformResponse(IProvideLaceResponse response)
        {
            var transformer = new TransformJisResponse(_jisResponse,_sightingUpdate);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.JisResponse = transformer.Result;
            response.JisResponseHandled = new JisResponseHandled();
            response.JisResponseHandled.HasBeenHandled();
        }

        private static void JisResponseFailed(IProvideLaceResponse response)
        {
            response.JisResponse = null;
            response.JisResponseHandled = new JisResponseHandled();
            response.JisResponseHandled.HasBeenHandled();
        }
    }
}
