using System.Collections.Generic;
using Recoveries.Core;

namespace Recoveries.Domain.Base
{
    public interface IMessageWriter
    {
        void Write(IEnumerable<RecoveryMessage> messages, IQueueOptions options);
    }
}
