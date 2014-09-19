using System;
using System.Linq;
using Common.Logging;
using Lace.Request;
using Lace.Source.Anpr.Definitions;
using Lace.Source.Anpr.Repository.Factory;

namespace Lace.Source.Anpr.Factory
{
    public class CertificateFactory : IProvideCertificate
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ILaceRequest _request;
        private readonly ISetupRepository _repositories;

        private IImpersonateACertificateUser _impersonator;

        public Certificate Certificate { get; private set; }

        private bool CertifcateFound
        {
            get
            {
                return Certificate != null;
            }
        }

        public bool IsSuccessfull { get; private set; }

        public CertificateFactory(ILaceRequest request, ISetupRepository repositories)
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

        public void UndoCertificateImpersonation()
        {
            _impersonator.UndoImpersonation();
        }

        private void ImpersonateUserOnCertificate()
        {
            _impersonator = new Impersonation();

            IsSuccessfull = _impersonator.ImpersonateAUser(Certificate.Credentials.Username,
                Certificate.Credentials.Domain,
                Certificate.Credentials.Password);
        }

        private void FindCertificate()
        {
            Log.InfoFormat("Getting Certificate for Co Ordinates Lat {0} Long {1}", _request.CoOrdinates.Latitude,
               _request.CoOrdinates.Longitude);


            var definition = _repositories.BaseStationRepository()
                .Find(_request.CoOrdinates.Latitude, _request.CoOrdinates.Longitude);

            if (definition == null) return;

            Log.InfoFormat("Found Certificate definition for Co Ordinates Lat {0} Long {1}",
                _request.CoOrdinates.Latitude,
                _request.CoOrdinates.Longitude);


            Certificate =
                _repositories.CertifcateRepository()
                    .GetAll()
                    .FirstOrDefault(w => w.Name.Equals(definition.Name, StringComparison.CurrentCultureIgnoreCase));

            if (CertifcateFound)
            {
                Log.InfoFormat("Found Certificate for Co Ordinates Lat {0} Long {1}. Certificate Name is {3}",
                    _request.CoOrdinates.Latitude,
                    _request.CoOrdinates.Longitude, definition.Name);

                return;
            }

            Log.InfoFormat("Could Not find Certificate for Co Ordinates Lat {0} Long {1}. Certificate Name is {3}",
                _request.CoOrdinates.Latitude,
                _request.CoOrdinates.Longitude, definition.Name);
        }
    }
}
