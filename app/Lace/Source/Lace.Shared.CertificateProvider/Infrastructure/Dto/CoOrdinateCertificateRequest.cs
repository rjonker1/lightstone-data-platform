using Lace.Shared.CertificateProvider.Core.Contracts;

namespace Lace.Shared.CertificateProvider.Infrastructure.Dto
{
    public class CoOrdinateCertificateRequest : IRequestCoOrdinateCertificate
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public CoOrdinateCertificateRequest(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
