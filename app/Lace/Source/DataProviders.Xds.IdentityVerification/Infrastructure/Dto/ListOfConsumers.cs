using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataProviders.Xds.IdentityVerification.Infrastructure.Dto
{
    [Serializable]
    [DataContract]
    public class ListOfConsumers
    {
        [DataMember]
        public ConsumerDetails ConsumerDetails { get; set; }
    }
}