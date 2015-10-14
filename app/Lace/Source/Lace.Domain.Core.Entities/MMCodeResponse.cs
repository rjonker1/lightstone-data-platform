using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class MMCodeResponse : IProvideDataFromMmCode
    {
        public MMCodeResponse()
        {
            ResponseState = DataProviderResponseState.NoRecords;
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

        private MMCodeResponse(DataProviderResponseState state)
        {
            ResponseState = state;
        }

        public static MMCodeResponse WithState(DataProviderResponseState state)
        {
            return new MMCodeResponse(state);
        }

        public void AddResponseState(DataProviderResponseState state)
        {
            ResponseState = state;
        }

        [DataMember]
        public DataProviderResponseState ResponseState { get; private set; }
        [DataMember]
        public string ResponseStateMessage { get { return ResponseState.Description(); } }

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