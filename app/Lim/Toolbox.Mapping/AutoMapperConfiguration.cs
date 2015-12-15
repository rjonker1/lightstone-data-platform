using System;
using System.Linq;
using AutoMapper;

namespace Toolbox.Mapping
{
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
        }
    }
}