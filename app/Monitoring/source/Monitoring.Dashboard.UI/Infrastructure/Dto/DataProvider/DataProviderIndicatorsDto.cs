using System.Collections.Generic;
using System.Runtime.Serialization;
using Monitoring.Dashboard.UI.Infrastructure.Dto.RequestFields;

namespace Monitoring.Dashboard.UI.Infrastructure.Dto.DataProvider
{
    [DataContract]
    public class DataProviderIndicatorsDto
    {
        public DataProviderIndicatorsDto()
        {

        }

        public DataProviderIndicatorsDto(IndicatorRequestLevelDto requestLevel, List<IndicatorRequestPerDataProviderDto> requestPerDataProvider,
            List<IndicatorRequestTimeDataProviderDto> requestTimePerDataProvider, List<IndicatorRequestFieldTypeCountDto> requestFieldCounts)
        {
            RequestLevel = requestLevel.DetermineSuccessRate();
            RequestPerDataProvider = requestPerDataProvider;
            RequestTimePerDataProvider = requestTimePerDataProvider;
            RequestFieldCounts = requestFieldCounts;
        }

        [DataMember]
        public IndicatorRequestLevelDto RequestLevel { get; private set; }

        [DataMember]
        public List<IndicatorRequestPerDataProviderDto> RequestPerDataProvider { get; private set; }

        [DataMember]
        public List<IndicatorRequestTimeDataProviderDto> RequestTimePerDataProvider { get; private set; }

        [DataMember]
        public List<IndicatorRequestFieldTypeCountDto> RequestFieldCounts { get; private set; }
    }
}