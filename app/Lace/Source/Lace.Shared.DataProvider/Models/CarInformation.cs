using Lace.Shared.DataProvider.Contracts;

namespace Lace.Shared.DataProvider.Models
{
    public class CarInformation : IAmCachable
    {
        public const string SelectAllWithCarId =
            @"SELECT c.Car_ID as CarId, 0 as [Year], c.CarType_ID as CarTypeId, c.Manufacturer_ID as ManufacturerId, c.CarFullName, c.CarModel, c.BodyShape, c.FuelType, c.Market, c.TransmissionType, c.ModelYear, c.IntroductionDate, c.ImageUrl, ct.Make_ID as MakeId, 'Not Available' as [Quarter] FROM Car c INNER JOIN CarType ct ON c.CarType_ID = ct.CarType_ID";

        public const string SelectWithCarId =
            @"SELECT c.Car_ID as CarId, 0 as [Year], c.CarType_ID as CarTypeId, c.Manufacturer_ID as ManufacturerId, c.CarFullName, c.CarModel, c.BodyShape, c.FuelType, c.Market, c.TransmissionType, c.ModelYear, c.IntroductionDate, c.ImageUrl, ct.Make_ID as MakeId, 'Not Available' as [Quarter] FROM Car c INNER JOIN CarType ct ON c.CarType_ID = ct.CarType_ID where c.Car_ID = @CarId";

        public const string SelectAllWithValidCarIdAndYear =
            @"SELECT v.Vin, c.Car_ID AS CarId, c.CarType_ID AS CarTypeId, c.Manufacturer_ID AS ManufacturerId, c.CarFullName, c.CarModel, c.BodyShape, c.FuelType, c.Market, c.TransmissionType, c.ModelYear, c.IntroductionDate, c.ImageUrl, ct.Make_ID AS MakeId, CASE WHEN v.Period = 'First' THEN '1st Quarter' WHEN v.Period = 'Second' THEN '2nd Quarter' WHEN v.Period = 'Third' THEN '3rd Quarter' WHEN v.Period = 'Fourth' THEN '4th Quarter' ELSE 'Not Available' END AS [Quarter], v.Year_ID AS Year FROM Car AS c INNER JOIN CarType AS ct ON c.CarType_ID = ct.CarType_ID INNER JOIN Vin AS v ON c.Car_ID = v.Car_ID where c.Car_ID is not null and v.Year_ID is not null";

        public const string SelectWithVin =
            @"SELECT v.Vin, c.Car_ID AS CarId, c.CarType_ID AS CarTypeId, c.Manufacturer_ID AS ManufacturerId, c.CarFullName, c.CarModel, c.BodyShape, c.FuelType, c.Market, c.TransmissionType, c.ModelYear, c.IntroductionDate, c.ImageUrl, ct.Make_ID AS MakeId, CASE WHEN v.Period = 'First' THEN '1st Quarter' WHEN v.Period = 'Second' THEN '2nd Quarter' WHEN v.Period = 'Third' THEN '3rd Quarter' WHEN v.Period = 'Fourth' THEN '4th Quarter' ELSE 'Not Available' END AS [Quarter], v.Year_ID AS Year FROM Car AS c INNER JOIN CarType AS ct ON c.CarType_ID = ct.CarType_ID INNER JOIN Vin AS v ON c.Car_ID = v.Car_ID where v.VIN = @Vin and c.Car_ID is not null and v.Year_ID is not null";

        public const string SelectWithVin12 =
            @"SELECT  DISTINCT vs.VinShortName as Vin, c.Car_ID as CarId, s.Year_ID as [Year], c.CarType_ID as CarTypeId, c.Manufacturer_ID as ManufacturerId, c.CarFullName, c.CarModel, c.BodyShape, c.FuelType, c.Market, c.TransmissionType, c.ModelYear, c.IntroductionDate, c.ImageUrl, ct.Make_ID as MakeId, 'Not Available' as [Quarter]  from VinShort vs join Car c on c.Car_ID = vs.Car_ID join dbo.[Statistics] s on s.Car_ID = vs.Car_ID join CarType ct ON c.CarType_ID = ct.CarType_ID where  SUBSTRING(vs.VinShortName,0,12) = SUBSTRING(@Vin,0,12) and s.Year_ID is not null";

        public const string CacheAllWithCarIdKey = "urn:Auto_Carstats:CarInformation:Vin";
        public const string CacheAllWithValidCarIdAndYearKey = "urn:Auto_Carstats:CarInformation:Vin";
        public const string CacheWithCarIdKey = "urn:Auto_Carstats:CarInformation:Vin:{0}";
        public const string CacheWithVinKey = "urn:Auto_Carstats:CarInformation:Vin:{0}";
        public const string CacheWithVin12Key = "urn:Auto_Carstats:CarInformation:Vin:{0}";

        public CarInformation()
        {

        }

        public CarInformation(int carId, int year, int carTypeId, int manufacturerId, string carFullname, string carModel, string bodyShape,
            string fuelType, string market, string transmissionType, int modelYear,
            string introductionDate, string imageUrl, string quarter, int makeId)
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

        public void AddToCache(ICacheRepository repository)
        {
            repository.AddItems<CarInformation>(SelectAllWithCarId, CacheAllWithCarIdKey);
            repository.AddItems<CarInformation>(SelectAllWithValidCarIdAndYear, CacheAllWithValidCarIdAndYearKey);
        }

        public void IsAVin12Car()
        {
            IsVin12 = true;
        }

        public string Vin { get; set; }
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
        public string IntroductionDate { get; set; }
        public string ImageUrl { get; set; }
        public int MakeId { get; set; }
        public string Quarter { get; set; }

        public bool IsVin12 { get; set; }
    }
}