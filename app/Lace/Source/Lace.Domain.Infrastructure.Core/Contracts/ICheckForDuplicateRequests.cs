using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Infrastructure.Core.Contracts
{
    public interface ICheckForDuplicateRequests
    {
        bool IsRequestDuplicated(IPointToLaceRequest request);
    }
}
