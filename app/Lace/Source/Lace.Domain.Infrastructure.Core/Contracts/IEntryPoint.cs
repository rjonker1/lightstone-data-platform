using System.Collections.Generic;
using System.Threading.Tasks;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Infrastructure.Core.Contracts
{
    public interface IEntryPoint
    {
        ICollection<IPointToLaceProvider> GetResponsesForCarId(ICollection<IPointToLaceRequest> request);
        ICollection<IPointToLaceProvider> GetResponses(ICollection<IPointToLaceRequest> request);
    }

    public interface IEntryPointAsync
    {
        Task<ICollection<IPointToLaceProvider>> GetResponsesForCarIdAsync(ICollection<IPointToLaceRequest> request);
        Task<ICollection<IPointToLaceProvider>> GetResponsesAsync(ICollection<IPointToLaceRequest> request);
    }
}
