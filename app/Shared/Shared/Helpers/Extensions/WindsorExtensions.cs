using System;
using Castle.Windsor;
using Common.Logging;

namespace DataPlatform.Shared.Helpers.Extensions
{
    public static class WindsorExtensions
    {
        public static object TryResolve(this IWindsorContainer container, Type service)
        {
            var log = LogManager.GetLogger(typeof(WindsorExtensions));
            try
            {
                return container.Resolve(service);
            }
            catch (Exception exception)
            {
                log.Error(exception);
                return null;
            }
        }
    }
}