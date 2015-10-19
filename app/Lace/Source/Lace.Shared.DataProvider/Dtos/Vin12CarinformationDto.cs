namespace Lace.Toolbox.Database.Dtos
{
    public class Vin12CarinformationDto
    {
        public const string Select =
           @"SELECT  vs.VinShortName AS Vin, c.Car_ID AS CarId, c.CarType_ID AS CarTypeId, c.Manufacturer_ID AS ManufacturerId, c.CarFullName, c.CarModel, c.BodyShape, c.FuelType, c.Market, c.TransmissionType, c.ModelYear, (cast(SUBSTRING(c.IntroductionDate,7,4) as int)) as IntroductionYear, c.ImageUrl, ct.Make_ID AS MakeId, vs.Probability, (cast((substring(isnull(DiscontinuedDate, datepart(year,getdate())),7,4) + 1) as int)) as DiscontinuedYear, (cast((substring(isnull(DiscontinuedDate, datepart(year,getdate())),7,4) + 1) as int) - (cast(SUBSTRING(c.IntroductionDate,7,4) as int))) as YearCounter FROM dbo.VinShort AS vs INNER JOIN dbo.Car AS c ON c.Car_ID = vs.Car_ID INNER JOIN dbo.CarType AS ct ON c.CarType_ID = ct.CarType_ID WHERE (SUBSTRING(vs.VinShortName, 0, 12) = SUBSTRING(@Vin, 0, 12)) ORDER BY vs.Probability DESC";

        public Vin12CarinformationDto()
        {
            
        }

        public string Vin { get; set; }
        public int CarId { get; set; }
        public int YearCounter { get; set; }
        public int CarTypeId { get; set; }
        public int ManufacturerId { get; set; }
        public string CarFullName { get; set; }
        public string CarModel { get; set; }
        public string BodyShape { get; set; }
        public string FuelType { get; set; }
        public string Market { get; set; }
        public string TransmissionType { get; set; }
        public int ModelYear { get; set; }
        public int IntroductionYear { get; set; }
        public string ImageUrl { get; set; }
        public int MakeId { get; set; }
        public decimal Probability { get; set; }
        public int DiscontinuedYear { get; set; }

        
    }
}
