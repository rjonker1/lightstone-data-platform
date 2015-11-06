using System.Collections.Generic;
using Recoveries.Core;

namespace Recoveries.Domain.Base
{
    public interface IDeleteFiles
    {
        IEnumerable<int> DeleteMessages(IQueueOptions options);
    }
}
