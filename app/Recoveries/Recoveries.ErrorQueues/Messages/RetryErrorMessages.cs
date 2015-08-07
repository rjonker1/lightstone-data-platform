using System;
using System.Runtime.Serialization;
using Recoveries.Core;

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
    public class RetryErrorsOnAQueueMessage
    {
        public RetryErrorsOnAQueueMessage(IErrorQueueConfiguration configuration)
        {
            Configuration = configuration;
        }

        [DataMember] public readonly IErrorQueueConfiguration Configuration;
    }
}
