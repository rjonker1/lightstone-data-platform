using Lace.Domain.DataProviders.RgtVin.Core.Models;

namespace Lace.Domain.DataProviders.RgtVin.Core.Contracts
{
    public interface ISetupRepository
    {
        IReadOnlyRepository<Vin> VinRepository();
    }
}