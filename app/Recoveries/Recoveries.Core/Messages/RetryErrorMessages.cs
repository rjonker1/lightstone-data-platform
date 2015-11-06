using System;
using System.Runtime.Serialization;

namespace Recoveries.Core.Messages
{
    [DataContract]
    public class RetryErrorsOnAllQueuesMessage : IRecoverMessage
    {
        public RetryErrorsOnAllQueuesMessage(Guid id)
        {
            Id = id;
        }

        [DataMember] public Guid Id { get; private set; }
    }

    [DataContract]
    public class RetryErrorsOnAQueueMessage : IRecoverMessage
    {
        public RetryErrorsOnAQueueMessage(IErrorQueueConfiguration configuration)
        {
            Configuration = configuration;
        }

        [DataMember]
        public IErrorQueueConfiguration Configuration { get; private set; }
    }
}