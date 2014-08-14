namespace Lace.Source.Lightstone.Models
{
    public class CarInformation
    {
        public CarInformation(int carId, int year, string imageUrl, string quarter, string carFullname, string carModel)
        {
            CarId = carId;
            Year = year;
            ImageUrl = imageUrl;
            Quarter = quarter;
            CarFullname = carFullname;
            CarModel = carModel;
        }

        public int CarId { get; private set; }
        public int Year { get; private set; }
        public string ImageUrl { get; private set; }
        public string Quarter { get; private set; }
        public string CarFullname { get; private set; }
        public string CarModel { get; private set; }
    }
}
