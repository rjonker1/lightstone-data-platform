using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Infrastructure.Dto.DataProvider
{
    [DataContract]
    public class IndicatorRequestTimeDataProviderDto
    {
        public IndicatorRequestTimeDataProviderDto(double seconds, string dataProvider)
        {
            DataProvider = dataProvider;
            Seconds = seconds;
        }

        [DataMember]
        public double Seconds { get; private set; }

        [DataMember]
        public string DataProvider { get; private set; }
    }
}