using System.Collections.Generic;
using Lim.Dtos;

namespace Lim.Domain.Client.Commands
{
    public class GetAllConfigurations : Command
    {
        public GetAllConfigurations()
        {
        }

        public void Set(IEnumerable<ConfigurationDto> configurations)
        {
            Configurations = configurations;
        }

        public IEnumerable<ConfigurationDto> Configurations { get; private set; }

    }
}