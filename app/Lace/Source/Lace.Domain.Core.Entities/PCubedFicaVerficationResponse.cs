using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class PCubedFicaVerficationResponse : IProvideDataFromPCubedFicaVerfication
    {
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
    }
}
