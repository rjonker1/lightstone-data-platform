using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Lim.Domain.Base;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Domain.Base;

namespace Toolbox.LightstoneAuto.Factories
{
    public class BuildViewDtoFactory : AbstractBuildFactory<Guid, List<ViewDto>>
    {
        private readonly List<Assembly> _assemblies = new List<Assembly>
        {
            typeof (LsAutoMarker).Assembly
        };

        public override List<ViewDto> Build(Guid id)
        {
            var viewDtos = new List<ViewDto>();

            var viewMarker = typeof(IViewMarker);
            foreach (var assembly in _assemblies)
            {
                var views = assembly.GetTypes().Where(w => w.IsClass && !w.IsAbstract && viewMarker.IsAssignableFrom(w)).ToList();
                foreach (var view in views)
                {
                    var dto = new ViewDto()
                    {
                        Name = view.Name,
                        DisplayName = view.Name,
                        ViewColumns = new List<ViewColumnDto>()
                    };
                    var properties = view.GetProperties();
                    foreach (var property in properties)
                    {
                        dto.ViewColumns.Add(new ViewColumnDto
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