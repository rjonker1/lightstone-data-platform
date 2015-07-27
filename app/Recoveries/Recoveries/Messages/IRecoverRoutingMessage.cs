using System;
namespace Recoveries.Messages
{
    public interface IRecoverRoutingMessage
    {
        Guid RecoveryId { get; }
    }

    public interface IRecoverMessage
    {
        string ErrorQueueName { get; }
        string PublishQueueName { get; }
    }

    public interface IRecoverMessageTask
    {
        string ErrorQueueName { get; }
        string RePublishQueueName { get; }
        string MessageOutputPath { get; }
        
    }
}
