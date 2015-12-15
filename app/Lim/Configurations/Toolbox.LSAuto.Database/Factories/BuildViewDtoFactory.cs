using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Lim.Domain.Base;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Domain.Base;

namespace Toolbox.LightstoneAuto.Factories
{
    public class BuildViewDtoFactory : AbstractBuildFactory<Guid, List<DatabaseViewDto>>
    {
        private readonly List<Assembly> _assemblies = new List<Assembly>
        {
            typeof (LsAutoMarker).Assembly
        };

        public override List<DatabaseViewDto> Build(Guid id)
        {
            var viewDtos = new List<DatabaseViewDto>();

            var viewMarker = typeof(IViewMarker);
            foreach (var assembly in _assemblies)
            {
                var views = assembly.GetTypes().Where(w => w.IsClass && !w.IsAbstract && viewMarker.IsAssignableFrom(w)).ToList();
                foreach (var view in views)
                {
                    var dto = new DatabaseViewDto()
                    {
                        Name = view.Name,
                        DisplayName = view.Name,
                        AggregateId = id,
                        ViewColumns = new List<DatabaseViewColumnDto>()
                    };
                    var properties = view.GetProperties();
                    foreach (var property in properties)
                    {
                        dto.ViewColumns.Add(new DatabaseViewColumnDto
                        {
                            Name = property.Name,
                            DisplayName = property.Name
                        });
                    }

                    viewDtos.Add(dto);
                }
            }

            return viewDtos;
        }
    }
}