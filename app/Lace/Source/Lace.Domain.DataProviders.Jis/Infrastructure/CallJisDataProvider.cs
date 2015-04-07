using System;
using System.Collections.Generic;
using System.ServiceModel;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.CrossCutting.DataProvider.Certificate.Core.Contracts;
using Lace.CrossCutting.DataProvider.Certificate.Infrastructure.Dto;
using Lace.CrossCutting.DataProvider.Certificate.Infrastructure.Factory;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Jis.Infrastructure.Dto;
using Lace.Domain.DataProviders.Jis.Infrastructure.Management;
using Lace.Domain.DataProviders.Jis.JisServiceReference;
using Lace.Shared.Extensions;
using Workflow.Lace.Messages.Core;


namespace Lace.Domain.DataProviders.Jis.Infrastructure
{
    public class CallJisDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.Jis;

        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISetupCertificateRepository _repository;
        private IProvideCertificate _certificate;
        private DataStoreResult _jisResponse;
        private SightingUpdateResult _sightingUpdate;

        public CallJisDataProvider(ICollection<IPointToLaceRequest> request, ISetupCertificateRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _request = request;
            _repository = repository;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response, ISendCommandToBus command)
        {
            try
            {
                _certificate =
                    new CoOrdinateCertificateFactory(
                        new CoOrdinateCertificateRequest(_request.GetFromRequest<IAmJisRequest>().Jis.Latitude, _request.GetFromRequest<IAmJisRequest>().Jis.Longitude),
                        _repository);

                if (!_certificate.IsSuccessfull || _certificate.Certificate == null ||
                    string.IsNullOrEmpty(_certificate.Certificate.Endpoint))
                    JisResponseFailed(response);

                var proxy = new JisWsInterfaceSoapClient(_certificate.Certificate.Endpoint);
                if (proxy.State == CommunicationState.Closed)
                    proxy.Open();

                proxy.Connect();

                var session = new SessionManager(proxy, _log, _request.GetFromRequest<IHaveUser>()).Build().SessionManagement;

                _jisResponse = proxy.DataStoreQuery(session.Id, new BuildJisRequest(_request.GetFromRequest<IHaveJisInformation>()).JisRequest,
                    _request.GetFromRequest<IHaveUser>().UserName);

                if (_jisResponse.IsHot)
                {
                    _sightingUpdate =
                        new SightingUpdate(_request.GetFromRequest<IHaveUser>(), _jisResponse).BuildRequest()
                            .Update(proxy, session)
                            .SightingUpdateResult;
                }

                proxy.Close();

                TransformResponse(response, command);

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Jis Web Service {0}", ex.Message);
               // command.Monitoring.PublishFailedSourceCallMessage(Source);
                JisResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response, ISendCommandToBus command)
        {
            var transformer = new TransformJisResponse(_jisResponse,_sightingUpdate);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private static void JisResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var jisResponse = new JisResponse();
            jisResponse.HasBeenHandled();
            response.Add(jisResponse);
        }
    }
}
