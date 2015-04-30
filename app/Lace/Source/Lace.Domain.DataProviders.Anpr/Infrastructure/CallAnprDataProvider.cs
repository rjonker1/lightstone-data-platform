using System;
using System.Collections.Generic;
using System.ServiceModel;
using Common.Logging;
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
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Anpr.Infrastructure
{
    public class CallAnprDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogComandTypes _logComand;
        private readonly ISetupCertificateRepository _repository;
        private IProvideCertificate _certificate;
        private AnprResComplexType _anprResponse;

        public CallAnprDataProvider(IAmDataProvider dataProvider, ISetupCertificateRepository repository, ILogComandTypes logComand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _repository = repository;
            _logComand = logComand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                //TODO: Need to update the data provider
                //_certificate =
                //    new CoOrdinateCertificateFactory(
                //        new CoOrdinateCertificateRequest(_dataProvider.GetRequest<IAmAnprRequest>().Latitude, _dataProvider.GetRequest<IAmAnprRequest>().Longitude),
                //        _repository);

                //TODO: Remove and implement above
                _certificate =
                    new CoOrdinateCertificateFactory(
                        new CoOrdinateCertificateRequest(0, 0),
                        _repository);

                if (!_certificate.IsSuccessfull || _certificate.Certificate == null ||
                    string.IsNullOrEmpty(_certificate.Certificate.Endpoint))
                    AnprResponseFailed(response);

                var proxy = new AnprServiceSoapClient(_certificate.Certificate.Endpoint);
                if (proxy.State == CommunicationState.Closed)
                    proxy.Open();

                var builder = new BuildAnprRequest(_dataProvider.GetRequest<IAmAnprRequest>()).Build();
                _anprResponse = proxy.AnprProcessRecognition(builder.AnprRequest);

                proxy.Close();

                TransformResponse(response);

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Anpr Web Service {0}", ex.Message);
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

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private static void AnprResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var anprResponse = new AnprResponse();
            anprResponse.HasBeenHandled();
            response.Add(anprResponse);
        }
    }
}
