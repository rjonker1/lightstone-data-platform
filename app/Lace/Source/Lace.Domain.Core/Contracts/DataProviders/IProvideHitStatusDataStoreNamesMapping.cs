using System.Collections.Generic;
namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideHitStatusDataStoreNamesMapping
    {
        int HitStatus { get; }
        List<string> DataStores { get; }
    }
}
