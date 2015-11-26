using System;
using System.Runtime.Serialization;
using Monitoring.Domain;

namespace DataProvider.Infrastructure.Dto.DataProvider
{
    [DataContract]
    public class IndicatorRequestLevelDto : AbstractDto
    {
        public IndicatorRequestLevelDto()
        {

        }

        public IndicatorRequestLevelDto(string averageResponseTime, double totalRequests, double totalErrors, double totalResponses)
        {
            AverageResponseTime = averageResponseTime;
            TotalRequests = totalRequests;
            TotalErrors = totalErrors;
            TotalResponses = totalResponses;
        }

        public IndicatorRequestLevelDto DetermineSuccessRate()
        {
            SuccessRate = TotalRequests > 0 ? Math.Round(((TotalRequests - TotalErrors) / TotalRequests) * 100, 2) : 0;
            return this;
        }

        [DataMember]
        public string AverageResponseTime { get; set; }

        [DataMember]
        public double TotalRequests { get; set; }

        [DataMember]
        public double TotalResponses { get; set; }

        [DataMember]
        public double TotalErrors { get; set; }
        [DataMember]
        public double SuccessRate { get; private set; }

        [DataMember]
        public string CurrentMonth
        {
            get
            {
                return DateTime.Now.ToString("MMMM");
            }
        }
    }
}