using System;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromAnpr : IPointToLaceProvider
    {
        string ProcessedImage { get; }
        string EnhancedImage { get; }
        string EnhancedImageThumbnail { get; }
        string LicensePlateNumber { get; }
        string ErrorMessage { get; }
        bool Successful { get; }
        Guid TransactionToken { get; }
    }
}
