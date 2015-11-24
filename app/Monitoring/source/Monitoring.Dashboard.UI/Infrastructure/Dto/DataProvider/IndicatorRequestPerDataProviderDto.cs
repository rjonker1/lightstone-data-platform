using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Monitoring.Domain;

namespace Monitoring.Dashboard.UI.Infrastructure.Dto.DataProvider
{
    [DataContract]
    public class IndicatorRequestPerDataProviderDto : AbstractDto
    {
        public IndicatorRequestPerDataProviderDto()
        {

        }

        [DataMember]
        public int RequestPerDataProviderCount { get; set; }

        [DataMember]
        public int DataProviderId { get; set; }

        [DataMember]
        public string DataProviderName
        {
            get
            {
                var name = (DataProviderCommandSource) DataProviderId;
                return name.ToString();
            }
        }
    }
}