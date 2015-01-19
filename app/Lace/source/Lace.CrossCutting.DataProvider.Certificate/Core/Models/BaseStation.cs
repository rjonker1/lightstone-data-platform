namespace Lace.CrossCutting.DataProviderCommandSource.Certificate.Core.Models
{
    public class BaseStation
    {
        public BaseStation()
        {
            
        }

        public BaseStation(string name, double x, double y, double distance)
        {
            Name = name;
            X = x;
            Y = y;
            Distance = distance;
        }

        public string Name { get; set; }
        public double X { get; set; } //lat
        public double Y { get; set; } //long
        public double Distance { get; set; }
    }
}
