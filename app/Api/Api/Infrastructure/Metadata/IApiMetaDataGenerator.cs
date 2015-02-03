using System.Collections.Generic;
using Nancy;

namespace Api.Infrastructure.Metadata
{
    public interface IApiMetaDataGenerator
    {
        IEnumerable<object> GetAllModuleRouteMetaData(NancyContext context);
    }
}