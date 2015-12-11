namespace Lace.Toolbox.Database.Base
{
    public abstract class AbstractVehicleFactory<T1, T2, T3> : IGetVehicleData<T1, T2, T3>
    {
        public abstract IRetrieveCarInformation CarInformation(T1 response, T2 request, T3 query);

        public IRetrieveCarInformation CarInformation(object response, object request, object query)
        {
            return CarInformation((T1)response, (T2)request, (T3)query);
        }
    }
}
