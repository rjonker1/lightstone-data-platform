namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IPointToVehicleRequest : IPointToLaceRequest
    {
        IHaveUserInformation User { get; }
        IHaveVehicle Vehicle { get; }
    }
}
