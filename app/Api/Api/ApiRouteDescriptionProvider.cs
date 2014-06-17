using System;
using System.Collections.Generic;
using System.Linq;
using Api.Modules;
using Nancy;
using Nancy.Routing;

namespace Api
{
    public class ApiRouteDescriptionProvider : IRouteDescriptionProvider
    {
        private readonly IEnumerable<Tuple<string, string, string>> _moduleDescriptions = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>(typeof(IndexModule).ToString(), "/", "IndexModule Test Description")
        };

        public string GetDescription(INancyModule module, string path)
        {
            var moduleMethod = _moduleDescriptions.FirstOrDefault(x => x.Item1 == module.ToString() && x.Item2 == path);
            return moduleMethod != null ? moduleMethod.Item3 : "";
        }
    }
}