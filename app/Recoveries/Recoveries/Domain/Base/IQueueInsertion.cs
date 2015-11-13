using System.Collections.Generic;
using Recoveries.Core;

namespace Recoveries.Domain.Base
{
    public interface IQueueInsertion
    {
        void PublishMessagesToQueue(IEnumerable<RecoveryMessage> messages, IQueueOptions options);
    }

}
