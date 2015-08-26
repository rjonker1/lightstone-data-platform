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
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;


namespace Lace.Domain.DataProviders.Jis.Infrastructure
{
    public class CallJisDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;

       
        private readonly ISetupCertificateRepository _repository;
        private IProvideCertificate _certificate;
        private DataStoreResult _jisResponse;
        private SightingUpdateResult _sightingUpdate;

        public CallJisDataProvider(IAmDataProvider dataProvider, ISetupCertificateRepository repository, ILogCommandTypes logCommand)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
            _dataProvider = dataProvider;
            _logCommand = logCommand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                _certificate =
                    new CoOrdinateCertificateFactory(
                        new CoOrdinateCertificateRequest(GetValidLatitudeCoordinate(_dataProvider.GetRequest<IAmJisRequest>().Latitude),
                            GetValidLongitudeCoordinate(_dataProvider.GetRequest<IAmJisRequest>().Latitude)),
                        _repository);

                _logCommand.LogConfiguration(new {Certficate = _certificate}, null);

                if (!_certificate.IsSuccessfull || _certificate.Certificate == null || string.IsNullOrEmpty(_certificate.Certificate.Endpoint))
                    throw new Exception("Certificate for JIS request could not be generated");

                var proxy = new JisWsInterfaceSoapClient(_certificate.Certificate.Endpoint);
                if (proxy.State == CommunicationState.Closed)
                    proxy.Open();

                proxy.Connect();

                var session = new SessionManager(proxy, _log, _dataProvider.GetRequest<IAmJisRequest>()).Build().SessionManagement;
                var request = new BuildJisRequest(_dataProvider.GetRequest<IAmJisRequest>()).JisRequest;

                _logCommand.LogRequest(new ConnectionTypeIdentifier(proxy.Endpoint.Address.Uri.ToString()).ForWebApiType(), new {request, session});

                _jisResponse = proxy.DataStoreQuery(session.Id, request, _dataProvider.GetRequest<IAmJisRequest>().UserName.Field);

                if (_jisResponse.IsHot)
                {
                    _sightingUpdate =
                        new SightingUpdate(_dataProvider.GetRequest<IAmJisRequest>(), _jisResponse).BuildRequest()
                            .Update(proxy, session)
                            .SightingUpdateResult;
                }

                proxy.Close();

                _logCommand.LogResponse(_jisResponse != null ? DataProviderState.Successful : DataProviderState.Failed,
                    new ConnectionTypeIdentifier(proxy.Endpoint.Address.Uri.ToString()).ForWebApiType(), new {_jisResponse});

                TransformResponse(response);

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Jis Web Service {0}",ex, ex.Message);
                _logCommand.LogFault(new {ex.Message}, new {ErrorMessage = "Error calling JIS Web Service"});
                JisResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformJisResponse(_jisResponse,_sightingUpdate);

            if (transformer.Continue)
            {
                transformer.Transform();
            }
            _logCommand.LogTransformation(transformer.Result, null);
            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private static void JisResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var jisResponse = new JisResponse();
            jisResponse.HasBeenHandled();
            response.Add(jisResponse);
        }

        private static double GetValidLatitudeCoordinate(IAmRequestField coordinate)
        {
            if (coordinate == null || string.IsNullOrEmpty(coordinate.Field))
                return 0;

            double latitude;

            double.TryParse(coordinate.Field, out latitude);

            return 90 >= latitude && latitude >= -90 ? latitude : 0;

        }

        private static double GetValidLongitudeCoordinate(IAmRequestField coordinate)
        {
            if (coordinate == null || string.IsNullOrEmpty(coordinate.Field))
                return 0;

            double longitude;

            double.TryParse(coordinate.Field, out longitude);

            return 180 >= longitude && longitude >= -180 ? longitude : 0;

        }
    }
}
