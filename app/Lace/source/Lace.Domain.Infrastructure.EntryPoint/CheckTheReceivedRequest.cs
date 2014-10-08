using Lace.Domain.Core.Contracts.Requests;
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
