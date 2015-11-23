using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Infrastructure.Dto.DataProvider
{
    [DataContract]
    public class DataProviderIndicatorsDto
    {
        public DataProviderIndicatorsDto()
        {

        }

        public DataProviderIndicatorsDto(IndicatorRequestLevelDto requestLevel, List<IndicatorRequestPerDataProviderDto> requestPerDataProvider, List<IndicatorRequestTimeDataProviderDto> requestTimePerDataProvider)
        {
            RequestLevel = requestLevel.DetermineSuccessRate();
            RequestPerDataProvider = requestPerDataProvider;
            RequestTimePerDataProvider = requestTimePerDataProvider;
        }

        [DataMember]
        public IndicatorRequestLevelDto RequestLevel { get; private set; }
        [DataMember]
        public List<IndicatorRequestPerDataProviderDto> RequestPerDataProvider { get; private set; }
        [DataMember]
        public List<IndicatorRequestTimeDataProviderDto> RequestTimePerDataProvider { get; private set; }
    }
}