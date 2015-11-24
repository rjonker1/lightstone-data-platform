using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Infrastructure.Dto.RequestFields
{
    [DataContract]
    public class IndicatorRequestFieldTypeCountDto
    {
        public IndicatorRequestFieldTypeCountDto(string requestField, int count)
        {
            RequestField = requestField;
            Count = count;
        }

        [DataMember]
        public string RequestField { get; private set; }
        [DataMember]
        public int Count { get; private set; }
    }
}