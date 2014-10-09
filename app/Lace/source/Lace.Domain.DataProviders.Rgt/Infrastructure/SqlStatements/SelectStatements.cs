namespace Lace.Domain.DataProviders.Rgt.Infrastructure.SqlStatements
{
    public class SelectStatements
    {
        public const string GetCarSpecifications =
            "select c.CarModel, c.ModelYear,m.ManufacturerName, ct.CarTypeName, c.EngineSize, c.BodyShape, c.FuelType, c.TransmissionType, c.CarFullName, c.RainSensorWindscreenWipers, c.HeadUpDisplay from Car c join Manufacturer m on m.Manufacturer_ID = c.Manufacturer_ID join CarType ct on ct.CarType_ID = c.CarType_ID where c.Car_ID = @CarId";
    }
}
