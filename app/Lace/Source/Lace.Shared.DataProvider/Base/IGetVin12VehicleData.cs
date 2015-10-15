
namespace Lace.Toolbox.Database.Base
{
    public interface IGetVin12VehicleData
    {
        object Vin12CarInformation(object response, object request, object repository);
    }

    public interface IGetVin12VehicleData<in T1, in T2, in T3, out T4> : IGetVin12VehicleData
    {
        T4 Vin12CarInformation(T1 response, T2 request, T3 repository);
    }
}
