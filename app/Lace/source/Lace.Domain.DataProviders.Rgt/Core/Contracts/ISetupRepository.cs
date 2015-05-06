using Lace.Shared.DataProvider.Models;

namespace Lace.Domain.DataProviders.Rgt.Core.Contracts
{
    public interface ISetupRepository
    {
        IReadOnlyRepository<CarSpecification> CarSpecificationRepository();
    }
}