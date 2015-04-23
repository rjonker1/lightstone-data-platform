using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Core.Requests.Contracts.Requests;

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
