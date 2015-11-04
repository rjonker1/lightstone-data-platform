using System.Collections.Generic;
using Recoveries.Core;

namespace Recoveries.Domain.Base
{
    public interface IQueueRetrieval
    {
        IEnumerable<RecoveryMessage> GetMessagesFromQueue(IQueueOptions options);
    }
}