﻿using Lace.Domain.Core.Contracts.Caching;

namespace Lace.Toolbox.Database.Dtos
{
    public class CarInformationDto : IAmCachable
    {
        public const string SelectAllWithCarId =
            @"SELECT c.Car_ID as CarId, 0 as [Year], c.CarType_ID as CarTypeId, c.Manufacturer_ID as ManufacturerId, c.CarFullName, c.CarModel, c.BodyShape, c.FuelType, c.Market, c.TransmissionType, c.ModelYear, c.IntroductionDate, c.ImageUrl, ct.Make_ID as MakeId,m.MakeName, 'Not Available' as [Quarter] FROM Car c INNER JOIN CarType ct ON c.CarType_ID = ct.CarType_ID INNER JOIN Make m ON ct.Make_ID = m.Make_ID";

        public const string SelectWithCarId =
            @"SELECT c.Car_ID as CarId, 0 as [Year], c.CarType_ID as CarTypeId, c.Manufacturer_ID as ManufacturerId, c.CarFullName, c.CarModel, c.BodyShape, c.FuelType, c.Market, c.TransmissionType, c.ModelYear, c.IntroductionDate, c.ImageUrl, ct.Make_ID as MakeId,m.MakeName, 'Not Available' as [Quarter] FROM Car c INNER JOIN CarType ct ON c.CarType_ID = ct.CarType_ID INNER JOIN Make m ON ct.Make_ID = m.Make_ID where c.Car_ID = @CarId";

        //public const string SelectAllWithValidCarIdAndYear =
        //    @"SELECT v.Vin, c.Car_ID AS CarId, c.CarType_ID AS CarTypeId, c.Manufacturer_ID AS ManufacturerId, c.CarFullName, c.CarModel, c.BodyShape, c.FuelType, c.Market, c.TransmissionType, c.ModelYear, c.IntroductionDate, c.ImageUrl, ct.Make_ID AS MakeId, v.MakeName, v.CarTypeName, v.Month,v.Colour,v.Source,  CASE WHEN v.Period = 'First' THEN '1st Quarter' WHEN v.Period = 'Second' THEN '2nd Quarter' WHEN v.Period = 'Third' THEN '3rd Quarter' WHEN v.Period = 'Fourth' THEN '4th Quarter' ELSE 'Not Available' END AS [Quarter], v.Year_ID AS Year FROM Car AS c INNER JOIN CarType AS ct ON c.CarType_ID = ct.CarType_ID INNER JOIN Vin AS v ON c.Car_ID = v.Car_ID where c.Car_ID is not null and v.Year_ID is not null and v.Year_ID > DATEPART(YEAR, DATEADD(YEAR,-6,GETDATE()))";

        public const string SelectWithVin =
            @"SELECT v.Vin, c.Car_ID AS CarId, c.CarType_ID AS CarTypeId, c.Manufacturer_ID AS ManufacturerId, c.CarFullName, c.CarModel, c.BodyShape, c.FuelType, c.Market, c.TransmissionType, c.ModelYear, c.IntroductionDate, c.ImageUrl, ct.Make_ID AS MakeId, v.MakeName, v.CarTypeName, v.Month,v.Colour,v.Source, CASE WHEN v.Period = 'First' THEN '1st Quarter' WHEN v.Period = 'Second' THEN '2nd Quarter' WHEN v.Period = 'Third' THEN '3rd Quarter' WHEN v.Period = 'Fourth' THEN '4th Quarter' ELSE 'Not Available' END AS [Quarter], v.Year_ID AS Year FROM Car AS c INNER JOIN CarType AS ct ON c.CarType_ID = ct.CarType_ID INNER JOIN Vin AS v ON c.Car_ID = v.Car_ID where v.VIN = @Vin and c.Car_ID is not null and v.Year_ID is not null";

        //public const string SelectWithVin12 =
        //    @"SELECT  DISTINCT vs.VinShortName as Vin, c.Car_ID as CarId, s.Year_ID as [Year], c.CarType_ID as CarTypeId, c.Manufacturer_ID as ManufacturerId, c.CarFullName, c.CarModel, c.BodyShape, c.FuelType, c.Market, c.TransmissionType, c.ModelYear, c.IntroductionDate, c.ImageUrl, ct.Make_ID as MakeId, 'Not Available' as [Quarter]  from VinShort vs join Car c on c.Car_ID = vs.Car_ID join dbo.[Statistics] s on s.Car_ID = vs.Car_ID join CarType ct ON c.CarType_ID = ct.CarType_ID where  SUBSTRING(vs.VinShortName,0,12) = SUBSTRING(@Vin,0,12) and s.Year_ID is not null";

        public CarInformationDto()
        {

        }

        public CarInformationDto(int carId, int year, int carTypeId, int manufacturerId, string carFullname, string carModel, string bodyShape,
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

        public CarInformationDto(string vin, int carId, int year, int carTypeId, int manufacturerId, string carFullname, string carModel, string bodyShape,
           string fuelType, string market, string transmissionType, int modelYear,
           string introductionDate, string imageUrl, string quarter, int makeId)
        {
            Vin = vin;
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
            repository.AddItems<CarInformationDto>(SelectAllWithCarId);
           // repository.AddItemsForEach<CarInformationDto>(SelectAllWithValidCarIdAndYear);
        }

        public void IsAVin12Car()
        {
            IsVin12 = true;
        }

        public CarInformationDto SetYear(int year)
        {
            if (year == 0) return this;
            Year = year;
            return this;
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
        public string MakeName { get; set; }
        public string CarTypeName { get; set; }
        public int Month { get; set; }
        public string Colour { get; set; }
        public string Source { get; set; }

        public bool IsVin12 { get; set; }
    }
}