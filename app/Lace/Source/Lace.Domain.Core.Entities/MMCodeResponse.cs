using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class MMCodeResponse : IProvideDataFromMmCode
    {
        public MMCodeResponse()
        {
        }

        private MMCodeResponse(string message)
        {
            HasCriticalFailure = true;
            CriticalFailureMessage = message;
        }

        public static MMCodeResponse Empty()
        {
            return new MMCodeResponse();
        }

        public static MMCodeResponse Failure(string message)
        {
            return new MMCodeResponse(message);
        }

        public MMCodeResponse(int mmlId, int carId, string mmCode)
        {
            MMLId = mmlId;
            CarId = carId;
            MMCode = mmCode;
        }

        [DataMember]
        public IAmMmCodeRequest Request { get; private set; }
        [DataMember]
        public int MMLId { get; private set; }
        [DataMember]
        public int CarId { get; private set; }
        [DataMember]
        public string MMCode { get; private set; }

        [DataMember]
        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }
        [DataMember]
        public Type Type
        {
            get
            {
                return GetType();
            }
        }

        [DataMember]
        public bool Handled { get; private set; }

        [DataMember]
        public bool HasCriticalFailure { get; private set; }

        [DataMember]
        public string CriticalFailureMessage { get; private set; }

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