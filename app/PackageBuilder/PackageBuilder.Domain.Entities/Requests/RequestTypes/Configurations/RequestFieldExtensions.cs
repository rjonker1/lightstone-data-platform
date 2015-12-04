using System.Collections.Generic;
using System.Linq;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes.Configurations
{
    public static class RequestFieldExtensions
    {
        public static T GetRequestField<T>(this ICollection<IAmRequestField> requestFields)
        {
            return requestFields.OfType<T>().Any() ? requestFields.OfType<T>().First() : default(T);
        }
    }
}
