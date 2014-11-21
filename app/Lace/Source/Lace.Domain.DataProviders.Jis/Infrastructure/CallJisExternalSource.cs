using System;
using System.ServiceModel;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Certificate.Core.Contracts;
using Lace.CrossCutting.DataProvider.Certificate.Infrastructure.Dto;
using Lace.CrossCutting.DataProvider.Certificate.Infrastructure.Factory;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Jis.Infrastructure.Dto;
using Lace.Domain.DataProviders.Jis.Infrastructure.Management;
using Lace.Domain.DataProviders.Jis.JisServiceReference;
using Lace.Shared.Monitoring.Messages.Shared;
using Monitoring.Sources.Lace;

namespace Lace.Domain.DataProviders.Jis.Infrastructure
{
    public class CallJisExternalSource : ICallTheDataProviderSource
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

        public void CallTheExternalSource(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring)
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
               // monitoring.PublishFailedSourceCallMessage(Source);
                JisResponseFailed(response);
            }
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response)
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

        private static void JisResponseFailed(IProvideResponseFromLaceDataProviders response)
        {
            response.JisResponse = null;
            response.JisResponseHandled = new JisResponseHandled();
            response.JisResponseHandled.HasBeenHandled();
        }
    }
}
