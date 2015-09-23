using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.DataProviders.Core.Extensions
{
    public static class ResponseExtensions
    {
        public static bool Exists<T>(this ICollection<IPointToLaceProvider> response)
        {
            if (response == null) return false;

            return response.OfType<T>().Any() && response.OfType<T>().First() != null;
        }

        public static bool HasCriticalError(this ICollection<IPointToLaceProvider> response)
        {
            if (response == null) return false;
            return response.OfType<IProvideCriticalFailure>().Any() &&
                   response.OfType<IProvideCriticalFailure>().SingleOrDefault(s => s.HasCriticalFailure) != null;
        }
    }
}