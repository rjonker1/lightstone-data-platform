using Lace.Domain.DataProviders.Rgt.Core.Models;

namespace Lace.Domain.DataProviders.Rgt.Core.Contracts
{
    public interface ISetupRepository
    {
        IReadOnlyRepository<CarSpecification> CarSpecificationRepository();
    }
}