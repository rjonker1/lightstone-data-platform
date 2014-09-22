using System;
using Lace.Models.Responses.Sources;

namespace Lace.Models.Anpr.DataObject
{
    public class AnprResponse : IProvideDataFromAnpr, ICheckIfAnprResponseWasSuccessful
    {
        public AnprResponse()
        {
        }

        public AnprResponse(string processedImage, string enhancedImage, string enhancedImageThumbnail,
            string licensePlateNumber, Guid transactionToken)
        {
            ProcessedImage = processedImage;
            EnhancedImage = enhancedImage;
            EnhancedImageThumbnail = enhancedImageThumbnail;
            LicensePlateNumber = licensePlateNumber;
            TransactionToken = transactionToken;
        }


        public string ProcessedImage { get; private set; }

        public string EnhancedImage { get; private set; }

        public string EnhancedImageThumbnail { get; private set; }

        public string LicensePlateNumber { get; private set; }

        public string ErrorMessage { get; private set; }

        public bool Successful { get; private set; }

        public Guid TransactionToken { get; private set; }

        public IProvideDataFromAnpr WasASuccess()
        {
            Successful = true;
            return this;
        }

        public IProvideDataFromAnpr WasAFailure(string errorMessage)
        {
            Successful = false;
            ErrorMessage = errorMessage;
            return this;
        }
    }
}
