using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmVehicleRequest : IPointToLaceRequest
    {
        IHaveUserInformation User { get; }
        IHaveVehicle Vehicle { get; }
    }
}
