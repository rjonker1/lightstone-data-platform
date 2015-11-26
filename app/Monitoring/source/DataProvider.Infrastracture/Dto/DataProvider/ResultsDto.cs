using System.Runtime.Serialization;

namespace DataProvider.Infrastructure.Dto.DataProvider
{
    [DataContract] public class ResultsDto
    {
        [DataMember]
        public string ElapsedTime { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public bool HasResults { get;private set; }
    }
}