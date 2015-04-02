namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IPointToVehicleRequest : IPointToLaceRequest
    {
        IHaveUser User { get; }
        IHaveVehicle Vehicle { get; }
    }
}
