namespace Lace.Source.Anpr.Definitions
{
    public class ProximityDefinition : IDefineTheProximity
    {
        public ProximityDefinition()
        {
        }

        public ProximityDefinition(double latitude, double longitude, double radius)
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
