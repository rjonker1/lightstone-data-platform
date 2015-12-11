namespace Lace.Toolbox.Database.Base
{ 
    public interface IGetVehicleData
    {
        IRetrieveCarInformation CarInformation(object response, object request, object query);
    }

    public interface IGetVehicleData<in T1, in T2, in T3> : IGetVehicleData
    {
        IRetrieveCarInformation CarInformation(T1 response, T2 request, T3 query);
    }
}