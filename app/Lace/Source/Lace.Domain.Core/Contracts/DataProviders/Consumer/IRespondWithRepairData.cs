namespace Lace.Domain.Core.Contracts.DataProviders.Consumer
{
    public interface IRespondWithRepairData
    {
        string VehicleDescription { get; }
        string Cost { get; }
        int Date { get; }
        string DriversName { get; }
        string Location { get; }
    }
}

//[{"Vehicle Desc":"HYUNDAI TUCSON","Cost":null,"Date":20110207,"dName":"Cannings","Location":"5 Cadisbrook Street,,Cape Town,8000"}]
