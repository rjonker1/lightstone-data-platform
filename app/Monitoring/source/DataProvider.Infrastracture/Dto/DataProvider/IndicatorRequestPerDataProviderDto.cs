using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Monitoring.Domain;

namespace DataProvider.Infrastructure.Dto.DataProvider
{
    [DataContract]
    public class IndicatorRequestPerDataProviderDto : AbstractDto
    {
        public IndicatorRequestPerDataProviderDto()
        {

        }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public int DataProviderId { get; set; }

        [DataMember]
        public string DataProviderName
        {
            get
            {
                var name = (DataProviderCommandSource) DataProviderId;
                return name.Description();
            }
        }
    }
}