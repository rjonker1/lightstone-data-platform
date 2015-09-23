using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromMmCode : IPointToLaceProvider
    {
        IAmMmCodeRequest Request { get; }
        int MMLId { get; }
        int CarId { get; }
        string MMCode { get; }
    }
}