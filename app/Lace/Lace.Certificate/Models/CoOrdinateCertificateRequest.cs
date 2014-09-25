namespace Lace.Certificate.Models
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
