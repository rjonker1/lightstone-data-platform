namespace Lace.Toolbox.Database.Base
{
    public abstract class AbstractVin12VehicleFactory<T1, T2, T3, T4> : IGetVin12VehicleData<T1, T2, T3, T4>
    {
        public abstract T4 Vin12CarInformation(T1 response, T2 request, T3 repository);

        public object Vin12CarInformation(object response, object request, object repository)
        {
            return (T4) Vin12CarInformation((T1)response, (T2) request, (T3) repository);
        }
    }
}
