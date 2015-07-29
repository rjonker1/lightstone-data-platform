using System;
using System.Runtime.Serialization;

namespace Recoveries.ErrorQueues.Messages
{
    [DataContract]
    public class RetryErrorsOnAllQueuesMessage
    {
        public RetryErrorsOnAllQueuesMessage(Guid id)
        {
            Id = id;
        }

        [DataMember] public readonly Guid Id;
    }

    [DataContract]
    public class RetryErrorsOnQueueMessage
    {
        public RetryErrorsOnQueueMessage(IErrorQueueConfiguration configuration)
        {
            Configuration = configuration;
        }

        [DataMember] public readonly IErrorQueueConfiguration Configuration;
    }
}
