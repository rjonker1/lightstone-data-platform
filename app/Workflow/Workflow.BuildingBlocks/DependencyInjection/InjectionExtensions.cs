using Castle.Windsor;
using EasyNetQ;

namespace Workflow.BuildingBlocks.DependencyInjection
{
    public static class InjectionExtensions
    {
        public static void RegisterAsEasyNetQContainerFactory(this IWindsorContainer container)
        {
            RabbitHutch.SetContainerFactory(() => new WindsorAdapter(container));
        }
    }
}