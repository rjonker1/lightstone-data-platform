using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Shared.Extensions
{
    public static class RequestExtensions
    {
        public static bool RequestContains<T>(this ICollection<IPointToLaceRequest> request)
        {
            return (request.OfType<T>().Any() && request.OfType<T>().First() != null);
        }

        public static T GetFromRequest<T>(this ICollection<IPointToLaceRequest> request)
        {
            return request.OfType<T>().First();
        }

        public static T GetRequest<T>(this IAmDataProvider dataprovider)
        {
            return dataprovider.Request.OfType<T>().First();
        }
    }
}
