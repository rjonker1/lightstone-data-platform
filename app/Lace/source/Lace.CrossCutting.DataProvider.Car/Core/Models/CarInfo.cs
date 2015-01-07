namespace Lace.CrossCutting.DataProviderCommandSource.Car.Core.Models
{
    public class CarInfo
    {

        public CarInfo()
        {
            
        }

        public CarInfo(int carId, int year, string imageUrl, string quarter, string carFullname, string carModel)
        {
            CarId = carId;
            Year = year;
            ImageUrl = imageUrl;
            Quarter = quarter;
            CarFullname = carFullname;
            CarModel = carModel;
        }

        public int CarId { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
        public string Quarter { get; set; }
        public string CarFullname { get; set; }
        public string CarModel { get; set; }
    }
}
