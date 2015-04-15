namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IPointToVehicleRequest : IPointToLaceRequest
    {
        IHaveVehicle Vehicle { get; }
    }
}
