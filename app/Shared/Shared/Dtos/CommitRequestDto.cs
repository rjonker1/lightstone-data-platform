using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

namespace DataPlatform.Shared.Dtos
{
    [DataContract]
    public class CommitRequestDto
    {
        [DataMember]
        public Guid RequestId { get; set; }
        [DataMember]
        public string CarId { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public Vin12State State { get; set; }
    }
}