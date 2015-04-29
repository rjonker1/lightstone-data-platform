using System;

namespace Lace.CrossCutting.DataProvider.Car.Core.Models
{
    public class CarInformation
    {

        public CarInformation()
        {
            
        }

        public CarInformation(int carId, int year, int carTypeId, int manufacturerId, string carFullname, string carModel, string bodyShape, string fuelType, string market, string transmissionType, int modelYear, 
            DateTime introductionDate, string imageUrl, string quarter, int makeId)
        {
            CarId = carId;
            CarTypeId = carTypeId;
            ManufacturerId = manufacturerId;
            BodyShape = bodyShape;
            FuelType = fuelType;
            Market = market;
            TransmissionType = transmissionType;
            ModelYear = modelYear;
            IntroductionDate = introductionDate;
            MakeId = makeId;
            Year = year;
            ImageUrl = imageUrl;
            Quarter = quarter;
            CarFullname = carFullname;
            CarModel = carModel;
        }

        public void IsAVin12Car()
        {
            IsVin12 = true;
        }

        public int CarId { get; set; }
        public int Year { get; set; }
        public int CarTypeId { get; set; }
        public int ManufacturerId { get; set; }
        public string CarFullname { get; set; }
        public string CarModel { get; set; }
        public string BodyShape { get; set; }
        public string FuelType { get; set; }
        public string Market { get; set; }
        public string TransmissionType { get; set; }
        public int ModelYear { get; set; }
        public DateTime IntroductionDate { get; set; }
        public string ImageUrl { get; set; }
        public int MakeId { get; set; }
        public string Quarter { get; set; }

        public bool IsVin12 { get; private set; }

    }
}
