namespace Lace.Domain.DataProviders.RgtVin.Infrastructure.SqlStatements
{
    public class SelectStatements
    {
        public const string GetVehicleVin = "select v.* from Vin v where v.VIN = @Vin";
    }
}
