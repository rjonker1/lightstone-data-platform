using System.Linq;
using System.Reflection;
using PackageBuilder.Api.Installers;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.EventHandlers.Packages;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.Installers
{
    public class when_installing_command_handlers : BaseTestHelper
    {
        public when_installing_command_handlers()
        {
            Container.Install(new WindsorInstaller());
        }

        public override void Observe()
        {
            
        }

        [Observation]
        public void should_resolve_IHandleMessages()
        {
            Container.Resolve<IHandleMessages>().ShouldBeType<MessagesHandlerResolver>();
        }

        [Observation]
        public void should_resolve_all_handlers()
        {
            var registeredHandlers = Core.Helpers.Extensions.TypeExtensions.FindDerivedTypesFromAssembly(Assembly.GetAssembly(typeof(PackageCreatedHandler)), typeof(IHandleMessages<>), true, false).OrderBy(x => x.Name);
            var resolvedHandlers = Container.ResolveAll<IHandleMessages>().Select(x => x.GetType()).Where(x => x != typeof(MessagesHandlerResolver)).OrderBy(x => x.Name);
                
             registeredHandlers.ShouldEqual(resolvedHandlers);
        }
    }
}