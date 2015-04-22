using System;
using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Core.Models
{
    [DataContract]
    public class DataProviderStatisticsView
    {
        public DataProviderStatisticsView()
        {
            
        }

        public DataProviderStatisticsView(string averageResponseTime, double totalRequests, double totalResponses,
            double totalErrors)
        {
            //AverageResponseTime = averageResponseTime.Seconds;
            AverageResponseTime = averageResponseTime;
            TotalRequests = totalRequests;
            TotalErrors = totalErrors;
            TotalResponses = totalResponses;
        }
       
        public DataProviderStatisticsView DetermineSuccessRate()
        {
            SuccessRate = TotalRequests > 0 ? ((TotalRequests - TotalErrors)/TotalRequests)*100 : 0;
            return this;
        }


        [DataMember]
        public string AverageResponseTime { get; private set; }

        [DataMember]
        public double TotalRequests { get; private set; }

        [DataMember]
        public double TotalErrors { get; private set; }

        [DataMember]
        public double TotalResponses { get; private set; }

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

        //public DataProviderStatisticsView GetAverageResponseTime()
        //{

        //    if (!_elapsedTimes.Any())
        //        return this;

        //    var timeSpans = new List<TimeSpan>();
        //    _elapsedTimes.ToList().ForEach(f =>
        //    {
        //        TimeSpan dElapsedTime;
        //        if (TimeSpan.TryParse(f, out dElapsedTime))
        //            timeSpans.Add(dElapsedTime);
        //    });

        //    var ticks = Convert.ToInt64(timeSpans.Average(a => a.Ticks));
        //    AverageResponseTime = new TimeSpan(ticks);
        //    return this;
        //}


    }
}