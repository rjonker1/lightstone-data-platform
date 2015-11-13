using System;
using System.Collections.Generic;
using Recoveries.Core;

namespace Recoveries.Domain.Base
{
    public interface IMessageReader
    {
        IEnumerable<RecoveryMessage> ReadMessages(IQueueOptions options);
        IEnumerable<RecoveryMessage> ReadMessages(IQueueOptions options, string messageName);
    }
}
