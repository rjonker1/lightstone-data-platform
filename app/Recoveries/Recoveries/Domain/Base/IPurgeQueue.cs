using System.Collections.Generic;
using Recoveries.Core;

namespace Recoveries.Domain.Base
{
    public interface IPurgeQueue
    {
        IEnumerable<uint> PurgeQueue(IQueueOptions options);
    }
}
