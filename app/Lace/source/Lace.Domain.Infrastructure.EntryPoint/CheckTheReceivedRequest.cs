using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;

namespace Lace.Domain.Infrastructure.EntryPoint
{
    public class CheckTheReceivedRequest : ICheckForDuplicateRequests
    {
        public bool IsRequestDuplicated(ILaceRequest request)
        {
            return false;
        }
    }
}
