using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Nancy.Authentication.Forms;

namespace CentralInterfuseApplication.Api.Helpers.Installers
{
    public class UserMapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUserMapper>().ImplementedBy<UserMapper>());
        }
    }
}