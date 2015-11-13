using System;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;

namespace UserManagement.Domain.Core.Helpers
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