using System.Collections.Generic;
using Recoveries.Core;

namespace Recoveries.Domain.Base
{
    public interface IErrorRetry
    {
        void RetryErrors(IEnumerable<RecoveryMessage> rawErrorMessages, IQueueOptions options);
    }
}
