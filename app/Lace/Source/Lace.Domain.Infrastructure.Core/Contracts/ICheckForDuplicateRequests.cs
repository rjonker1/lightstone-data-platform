using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Infrastructure.Core.Contracts
{
    public interface ICheckForDuplicateRequests
    {
        bool IsRequestDuplicated(ILaceRequest request);
    }
}
