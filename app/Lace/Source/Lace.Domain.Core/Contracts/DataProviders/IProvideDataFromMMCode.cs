using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromMmCode : IPointToLaceProvider
    {
        IAmMmCodeRequest Request { get; set; }
        int MMLId { get; set; }
        int CarId { get; set; }
        string MMCode { get; set; }
    }
}