using System;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Certificate.Core;
using Lace.CrossCutting.DataProvider.Certificate.Core.Contracts;

namespace Lace.CrossCutting.DataProvider.Certificate.Infrastructure.Factory
{
    public class CoOrdinateCertificateFactory : IProvideCertificate
    {
        private readonly ILog _log;
        private readonly IRequestCoOrdinateCertificate _request;
        private readonly ISetupCertificateRepository _repositories;

        private IImpersonateACertificateUser _impersonator;

        public IDefineTheCertificate Certificate { get; private set; }

        public CoOrdinateCertificateFactory()
        {
            _log = LogManager.GetLogger(GetType());
        }

        private bool CertifcateFound
        {
            get
            {
                return Certificate != null;
            }
        }

        public bool IsSuccessfull { get; private set; }

        public CoOrdinateCertificateFactory(IRequestCoOrdinateCertificate request, ISetupCertificateRepository repositories)
        {
            _request = request;
            _repositories = repositories;
        }

        public void GenerateCertificate()
        {
            FindCertificate();

            if (!CertifcateFound) return;

            ImpersonateUserOnCertificate();
        }

        private void ImpersonateUserOnCertificate()
        {
            _impersonator = new Impersonator();

            IsSuccessfull = _impersonator.ImpersonateAUser(Certificate.Credentials.Username,
                Certificate.Credentials.Domain,
                Certificate.Credentials.Password);

            _impersonator.UndoImpersonation();
        }

        private void FindCertificate()
        {
            _log.InfoFormat("Getting Certificate for Co-Ordinates Lat {0} Long {1}", _request.Latitude,
                _request.Longitude);


            var definition = _repositories.BaseStationRepository()
                .Find(_request.Latitude, _request.Longitude);

            if (definition == null) return;

            _log.InfoFormat("Found Certificate definition for Co-Ordinates Lat {0} Long {1}",
                _request.Latitude,
                _request.Longitude);


            Certificate =
                _repositories.CertifcateRepository()
                    .GetAll()
                    .FirstOrDefault(w => w.Name.Equals(definition.Name, StringComparison.CurrentCultureIgnoreCase));

            if (CertifcateFound)
            {
                _log.InfoFormat("Found Certificate for Co-Ordinates Lat {0} Long {1}. Certificate Name is {2}",
                    _request.Latitude,
                    _request.Longitude, definition.Name);

                return;
            }

            _log.InfoFormat("Could Not find Certificate for Co Ordinates Lat {0} Long {1}. Certificate Name is {2}",
                _request.Latitude,
                _request.Longitude, definition.Name);
        }
    }
}
