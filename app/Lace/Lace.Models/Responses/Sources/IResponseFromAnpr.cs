using System;

namespace Lace.Models.Responses.Sources
{
    public interface IResponseFromAnpr : IPointToLaceSource
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
