using PackageBuilder.Domain.Requests.Contracts.RequestFields;
namespace PackageBuilder.Domain.Requests.Contracts.Requests
{
    public interface IAmVin12Request : IAmDataProviderRequest
    {
        IAmVinNumberRequestField VinNumber { get; }
    }
}
