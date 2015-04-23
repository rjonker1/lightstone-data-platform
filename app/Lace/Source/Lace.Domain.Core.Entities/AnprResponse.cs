using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Core.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
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

        [DataMember]
        public IAmAnprRequest Request { get; private set; }

        [DataMember]
        public string ProcessedImage { get; private set; }

        [DataMember]
        public string EnhancedImage { get; private set; }

        [DataMember]
        public string EnhancedImageThumbnail { get; private set; }

        [DataMember]
        public string LicensePlateNumber { get; private set; }

        [DataMember]
        public string ErrorMessage { get; private set; }

        [DataMember]
        public bool Successful { get; private set; }

        [DataMember]
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

        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }

        public Type Type
        {
            get
            {
                return GetType();
            }
        }

        [DataMember]
        public bool Handled { get; private set; }

        public void HasNotBeenHandled()
        {
            Handled = false;
        }

        public void HasBeenHandled()
        {
            Handled = true;
        }
    }
}
