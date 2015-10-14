using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;

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

        public static string GetValue(this IAmRequestField field)
        {
            return field == null ? string.Empty : string.IsNullOrEmpty(field.Field) ? string.Empty : field.Field;
        }

        //public static bool IsCritical(this IAmDataProvider dataprovider)
        //{
        //    return dataprovider.Critical != null && dataprovider.Critical.True;
        //}

        //public static string Message(this IAmDataProvider dataprovider)
        //{
        //    return dataprovider.Critical == null ? "" : dataprovider.Critical.Message ?? "";
        //}

        //public static string Message(this ICauseCriticalFailure criticalFailure)
        //{
        //    return criticalFailure == null ? "" : criticalFailure.Message ?? "";
        //}

        //public static bool IsCritical(this ICauseCriticalFailure criticalFailure)
        //{
        //    return criticalFailure != null && criticalFailure.True;
        //}
    }
}