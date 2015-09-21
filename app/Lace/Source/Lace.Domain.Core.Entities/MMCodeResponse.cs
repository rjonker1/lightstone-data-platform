using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class MMCodeResponse : IProvideDataFromMMCode
    {
        public MMCodeResponse()
        {
        }

        public static MMCodeResponse Empty()
        {
            return new MMCodeResponse();
        }

        public MMCodeResponse(int mmlId, int carId, string mmCode)
        {
            MMLId = mmlId;
            CarId = carId;
            MMCode = mmCode;
        }

        [DataMember]
        public int MMLId { get; set; }
        [DataMember]
        public int CarId { get; set; }
        [DataMember]
        public string MMCode { get; set; }

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