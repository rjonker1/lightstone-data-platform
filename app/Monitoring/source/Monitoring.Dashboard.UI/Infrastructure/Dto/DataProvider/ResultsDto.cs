using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Infrastructure.Dto.DataProvider
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