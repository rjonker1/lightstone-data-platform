using System.Collections.Generic;
namespace Lace.Models.Responses.Sources
{
    public interface IProvideHitStatusDataStoreNamesMapping
    {
        int HitStatus { get; }
        List<string> DataStores { get; }
    }
}
