using System;
using System.Linq;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Toolbox.LightstoneAuto;
using Toolbox.LightstoneAuto.Domain.Mapping;
using Toolbox.Mapping;

namespace Lim.Schedule.Service.Installers
{
    public class MappingInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            AutoMapperConfiguration.Configure();
        //    LightstoneAutoMapperConfiguration.Configure();
            Mapper.Configuration.ConstructServicesUsing(container.Resolve);
        }

        public class AutoMapperConfiguration
        {
            public static void Configure()
            {
                Mapper.Initialize(m => AddProfiles(Mapper.Configuration));
            }

            private static void AddProfiles(IConfiguration configuration)
            {
                var mapProfiles = typeof(MappingMarker).Assembly.GetTypes().Where(w => typeof(Profile).IsAssignableFrom(w));
                foreach (var profile in mapProfiles)
                {
                    configuration.AddProfile(Activator.CreateInstance(profile) as Profile);
                }

                var lightstoneProfiles = typeof(LsAutoMarker).Assembly.GetTypes().Where(w => typeof(Profile).IsAssignableFrom(w));
                foreach (var profile in lightstoneProfiles)
                {
                    configuration.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            }
        }
    }
}
