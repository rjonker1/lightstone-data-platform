using System;

namespace Lace.Models.Anpr
{
    public interface IResponseFromAnpr
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
