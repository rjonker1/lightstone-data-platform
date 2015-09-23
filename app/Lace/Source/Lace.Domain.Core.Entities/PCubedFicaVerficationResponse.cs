using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class PCubedFicaVerficationResponse : IProvideDataFromPCubedFicaVerfication
    {
        public PCubedFicaVerficationResponse()
        {

        }

        private PCubedFicaVerficationResponse(string message)
        {
            HasCriticalFailure = true;
            CriticalFailureMessage = message;
        }

        public static PCubedFicaVerficationResponse Empty()
        {
            return new PCubedFicaVerficationResponse();
        }

        public static PCubedFicaVerficationResponse Failure(string message)
        {
            return new PCubedFicaVerficationResponse(message);
        }

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