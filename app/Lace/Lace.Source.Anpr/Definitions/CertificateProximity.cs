namespace Lace.Source.Anpr.Definitions
{
    public class CertificateProximity : IDefineTheProximity
    {
        public CertificateProximity()
        {
        }

        public CertificateProximity(double latitude, double longitude, double radius)
        {
            Latitude = latitude;
            Longitude = longitude;
            Radius = radius;
        }


        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public double Radius { get; private set; }
    }
}
