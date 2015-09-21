using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromMMCode : IPointToLaceProvider
    {
        int MMLId { get; set; }
        int CarId { get; set; }
        string MMCode { get; set; }
    }
}