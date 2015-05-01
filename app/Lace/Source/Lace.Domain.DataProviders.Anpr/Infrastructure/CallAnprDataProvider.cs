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
using Lace.Domain.DataProviders.Anpr.AnprServiceReference;
using Lace.Domain.DataProviders.Anpr.Infrastructure.Dto;
using Lace.Domain.DataProviders.Anpr.Infrastructure.Management;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Anpr.Infrastructure
{
    public class CallAnprDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;
        private readonly ISetupCertificateRepository _repository;
        private IProvideCertificate _certificate;
        private AnprResComplexType _anprResponse;

        public CallAnprDataProvider(IAmDataProvider dataProvider, ISetupCertificateRepository repository, ILogCommandTypes logCommand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _repository = repository;
            _logCommand = logCommand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {

                _certificate =
                    new CoOrdinateCertificateFactory(
                        new CoOrdinateCertificateRequest(GetValidLatitudeCoordinate(_dataProvider.GetRequest<IAmAnprRequest>().Latitude),
                            GetValidLongitudeCoordinate(_dataProvider.GetRequest<IAmAnprRequest>().Latitude)),
                        _repository);

                _logCommand.LogConfiguration(new {Certficate = _certificate}, null);

                if (!_certificate.IsSuccessfull || _certificate.Certificate == null || string.IsNullOrEmpty(_certificate.Certificate.Endpoint))
                    throw new Exception("Certificate for ANPR request could not be generated");

                var proxy = new AnprServiceSoapClient(_certificate.Certificate.Endpoint);
                if (proxy.State == CommunicationState.Closed)
                    proxy.Open();

                var builder = new BuildAnprRequest(_dataProvider.GetRequest<IAmAnprRequest>()).Build();

                _logCommand.LogRequest(new ConnectionTypeIdentifier(proxy.Endpoint.Address.Uri.ToString()).ForWebApiType(), new { builder.AnprRequest });

                _anprResponse = proxy.AnprProcessRecognition(builder.AnprRequest);

                proxy.Close();

                _logCommand.LogResponse(_anprResponse != null ? DataProviderState.Successful : DataProviderState.Failed,
                    new ConnectionTypeIdentifier(proxy.Endpoint.Address.Uri.ToString()).ForWebApiType(), new { builder.AnprRequest });

                TransformResponse(response);

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Anpr Web Service {0}", ex.Message);
                _logCommand.LogFault(new {ex.Message}, new {ErrorMessage = "Error calling Anpr Web Service"});
                AnprResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformAnprResponse(_anprResponse, Guid.NewGuid());
            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logCommand.LogTransformation(transformer.Result, null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private static void AnprResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var anprResponse = new AnprResponse();
            anprResponse.HasBeenHandled();
            response.Add(anprResponse);
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
