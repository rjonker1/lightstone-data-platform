using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

namespace DataPlatform.Shared.Dtos
{
    [DataContract]
    public class CommitRequestDto : ApiRequestDto
    {
        [DataMember]
        public CommitRequestState State { get; set; }
    }
}