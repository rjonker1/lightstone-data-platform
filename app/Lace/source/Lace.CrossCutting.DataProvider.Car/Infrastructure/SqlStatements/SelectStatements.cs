namespace Lace.CrossCutting.DataProvider.Car.Infrastructure.SqlStatements
{
    public class SelectStatements
    {
        public const string GetCarInformation =
            @"SELECT c.Car_ID as CarId, 0 as [Year], c.CarType_ID as CarTypeId, c.Manufacturer_ID as ManufacturerId, c.CarFullName, c.CarModel, c.BodyShape, c.FuelType, c.Market, c.TransmissionType, c.ModelYear, c.IntroductionDate, c.ImageUrl, ct.Make_ID as MakeId, 'Not Available' as [Quarter] FROM Car c INNER JOIN CarType ct ON c.CarType_ID = ct.CarType_ID";

        public const string GetCarInformationWithVin =
            @"SELECT  c.Car_ID AS CarId, c.CarType_ID AS CarTypeId, c.Manufacturer_ID AS ManufacturerId, c.CarFullName, c.CarModel, c.BodyShape, c.FuelType, c.Market, c.TransmissionType, c.ModelYear, c.IntroductionDate, c.ImageUrl, ct.Make_ID AS MakeId, CASE WHEN v.Period = 'First' THEN '1st Quarter' WHEN v.Period = 'Second' THEN '2nd Quarter' WHEN v.Period = 'Third' THEN '3rd Quarter' WHEN v.Period = 'Fourth' THEN '4th Quarter' ELSE 'Not Available' END AS [Quarter], v.Year_ID AS Year FROM Car AS c INNER JOIN CarType AS ct ON c.CarType_ID = ct.CarType_ID INNER JOIN Vin AS v ON c.Car_ID = v.Car_ID where v.VIN = @Vin and c.Car_ID is not null and v.Year_ID is not null";

        public const string GetCarInformationWithVin12 =
            @"SELECT  DISTINCT c.Car_ID as CarId, s.Year_ID as [Year], c.CarType_ID as CarTypeId, c.Manufacturer_ID as ManufacturerId, c.CarFullName, c.CarModel, c.BodyShape, c.FuelType, c.Market, c.TransmissionType, c.ModelYear, c.IntroductionDate, c.ImageUrl, ct.Make_ID as MakeId, 'Not Available' as [Quarter]  from VinShort vs join Car c on c.Car_ID = vs.Car_ID join dbo.[Statistics] s on s.Car_ID = vs.Car_ID join CarType ct ON c.CarType_ID = ct.CarType_ID where  SUBSTRING(vs.VinShortName,0,12) = SUBSTRING(@Vin,0,12) and s.Year_ID is not null";
    }
}
