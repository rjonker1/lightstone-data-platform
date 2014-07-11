namespace Lace.Models.Lightstone.Dto
{
    public class LightstoneResponse : IResponseFromLightstone
    {

        public LightstoneResponse(int carId, int year, string vin, string imageUrl, string quarter, string carFullName, string model)
        {
            CarId = carId;
            Year = year;
            Vin = vin;
            ImageUrl = imageUrl;
            Quarter = quarter;
            CarFullname = carFullName;
            Model = model;
        }

        public int? CarId { get; private set; }

        public int? Year { get; private set; }

        public string Vin { get; private set; }

        public string ImageUrl { get; private set; }

        public string Quarter { get; private set; }

        public string CarFullname { get; private set; }

        public string Model { get; private set; }
       
    }
}
