namespace Lace.Domain.DataProviders.Lightstone.Core.Models
{
    public class Car
    {
        public Car()
        {

        }

        public Car(int carId, int carTypeId, string carFullName, string carModel, string bodyShape, string fuelType,
            string market, string gearType, bool isDiscontinued, string imageUrl, string imageUrlSmall,
            string imageSource)
        {
            Car_ID = carId;
            CarType_ID = carTypeId;
            CarFullName = carFullName;
            CarModel = carModel;
            BodyShape = bodyShape;
            FuelType = fuelType;
            Market = market;
            GearType = gearType;
            IsDiscontinued = isDiscontinued;
            ImageUrl = imageUrl;
            ImageUrlSmall = imageUrlSmall;
            ImageSource = imageSource;
        }

        public int Car_ID { get; set; }
        public int CarType_ID { get; set; }
        // public virtual CarType CarType { get; set; }
        public string CarFullName { get; set; }
        public string CarModel { get; set; }
        public string BodyShape { get; set; }
        public string FuelType { get; set; }

        public string Market { get; set; }
        public string GearType { get; set; }
        public bool IsDiscontinued { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrlSmall { get; set; }
        public string ImageSource { get; set; }
    }
}
