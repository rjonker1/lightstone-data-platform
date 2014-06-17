using System.Collections.Generic;
using Nancy;

namespace Api
{
    public interface IApiMetaDataGenerator
    {
        IEnumerable<object> GetAllModuleRouteMetaData(NancyContext context);
    }
}