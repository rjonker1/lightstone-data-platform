using System;
using System.Runtime.Serialization;
namespace Workflow.Lace.Messages.Infrastructure
{
    [DataContract]
    public class StopWatchResults
    {
        [DataMember]
        public TimeSpan ElapsedTime { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        public StopWatchResults()
        {
            
        }

        public StopWatchResults(TimeSpan elapsedTime, string name)
        {
            ElapsedTime = elapsedTime;
            Name = name;
        }
    }
}
