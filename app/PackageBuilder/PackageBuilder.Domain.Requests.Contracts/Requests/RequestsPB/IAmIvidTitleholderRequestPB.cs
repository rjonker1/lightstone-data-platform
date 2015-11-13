using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Contracts.Requests.RequestsPB
{
    public interface IAmIvidTitleholderRequestPB : IAmIvidTitleholderRequest
    {
        IAmVinNumberRequestField VinNumber { get; }
    }
}