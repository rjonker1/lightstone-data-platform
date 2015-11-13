using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities.Extensions;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class PCubedFicaVerficationResponse : IProvideDataFromPCubedFicaVerfication
    {
        public PCubedFicaVerficationResponse()
        {
            ResponseState = DataProviderResponseState.NoRecords;
        }
        public static PCubedFicaVerficationResponse Empty()
        {
            return new PCubedFicaVerficationResponse();
        }

        private PCubedFicaVerficationResponse(DataProviderResponseState state)
        {
            ResponseState = state;
        }

        public static PCubedFicaVerficationResponse WithState(DataProviderResponseState state)
        {
            return new PCubedFicaVerficationResponse(state);
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
        public Guid TransactionToken { get; private set; }

        [DataMember]
        public long IdNumber { get; private set; }

        [DataMember]
        public string Initials { get; private set; }

        [DataMember]
        public string Surname { get; private set; }

        [DataMember]
        public string CellNumber { get; private set; }

        [DataMember]
        public string LifeStatus { get; private set; }

        [DataMember]
        public DateTime? DateOfBirth { get; private set; }

        [DataMember]
        public DateTime ResponseDate { get; private set; }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }

        [DataMember]
        public Type Type
        {
            get { return GetType(); }
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