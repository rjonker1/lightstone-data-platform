using System;
using System.Runtime.Serialization;

namespace DataProvider.Infrastructure.Dto.DataProvider
{
    [DataContract]
    public class IndicatorRequestTimeDataProviderDto
    {
        public IndicatorRequestTimeDataProviderDto(double seconds, string dataProvider)
        {
            DataProvider = dataProvider;
            Seconds = Math.Round(seconds, 2);
        }

        [DataMember]
        public double Seconds { get; private set; }

        [DataMember]
        public string DataProvider { get; private set; }
    }
}