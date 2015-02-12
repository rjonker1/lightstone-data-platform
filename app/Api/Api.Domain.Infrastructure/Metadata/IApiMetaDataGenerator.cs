using System.Collections.Generic;
using Nancy;

namespace Api.Domain.Infrastructure.Metadata
{
    public interface IApiMetaDataGenerator
    {
        IEnumerable<object> GetAllModuleRouteMetaData(NancyContext context);
    }
}