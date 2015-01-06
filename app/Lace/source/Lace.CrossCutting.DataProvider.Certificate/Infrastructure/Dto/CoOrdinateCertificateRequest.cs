using Lace.CrossCutting.DataProviderCommandSource.Certificate.Core.Contracts;

namespace Lace.CrossCutting.DataProviderCommandSource.Certificate.Infrastructure.Dto
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
