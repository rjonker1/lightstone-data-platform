using System;
using Castle.Windsor;

namespace DataPlatform.Shared.Helpers.Extensions
{
    public static class WindsorExtensions
    {
        public static object TryResolve(this IWindsorContainer container, Type service)
        {
            try
            {
                return container.Resolve(service);
            }
            catch (Exception exception)
            {
                typeof(WindsorExtensions).Error(() => exception);
                return null;
            }
        }
    }
}