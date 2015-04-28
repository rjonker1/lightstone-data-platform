using System;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromAnpr : IPointToLaceProvider
    {
        IAmAnprRequest Request { get; }
        string ProcessedImage { get; }
        string EnhancedImage { get; }
        string EnhancedImageThumbnail { get; }
        string LicensePlateNumber { get; }
        string ErrorMessage { get; }
        bool Successful { get; }
        Guid TransactionToken { get; }
    }
}
