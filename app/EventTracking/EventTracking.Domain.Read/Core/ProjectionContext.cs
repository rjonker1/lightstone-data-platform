using System;
using System.Collections.Generic;
using System.Linq;
using EventStore.ClientAPI;
using EventStore.ClientAPI.Common.Log;
using EventStore.ClientAPI.Common.Utils;
using EventStore.ClientAPI.SystemData;

namespace EventTracking.Domain.Read.Core
{
    public class ProjectionContext : IProjectionContext
    {
        private readonly ProjectionsManager _projections;
        private readonly IConsole _console;

        private readonly IEnumerable<Projection> _currentProjections;

        public ProjectionContext(IConsole console)
        {
            if (console == null) throw new ArgumentNullException("console");

            var logger = new ConsoleLogger();
            _projections = new ProjectionsManager(logger, IpEndPointFactory.DefaultHttp());

            _console = console;
            _currentProjections = GetCurrentProjections();
        }

        private IEnumerable<Projection> GetCurrentProjections()
        {
            //  var all = _projections.ListAll(EventStoreCredentials.Default);

            var all = _projections.ListAll(new UserCredentials("admin", "123456"));

            var json = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(all);
            var projections = new List<Projection>();

            _console.Log("Current projections: ");

            foreach (var projection in json.projections)
            {
                var newProjection = new Projection(projection.name.Value, projection.status.Value);

                projections.Add(newProjection);
                _console.Log("> " + newProjection);
            }
            return projections;
        }

        public void EnableProjection(string name)
        {
            if (_currentProjections.Any(p => p.Name == name && p.Status != "Stopped")) return;

            //_projections.Enable(name, EventStoreCredentials.Default);
            _projections.Enable(name, new UserCredentials("admin", "123456")); ;
        }

        public void EnsureProjection(string name, string source)
        {
            if (_currentProjections.Any(n => n.Name == name))
            {
                UpdateProjection(name, source);
            }
            else
            {
                AddProjection(name, source);
            }
        }

        private void AddProjection(string name, string expectedQuery)
        {
            _console.Important("Add projection: " + name);

            //_projections.CreateContinuous(name, expectedQuery, EventStoreCredentials.Default);
            _projections.CreateContinuous(name, expectedQuery, new UserCredentials("admin", "123456"));
        }

        private void UpdateProjection(string name, string expectedQuery)
        {
            _console.Important("Update existing projection: " + name);

            //var currentQuery = _projections.GetQuery(name, EventStoreCredentials.Default);
            var currentQuery = _projections.GetQuery(name, new UserCredentials("admin", "123456"));

            if (expectedQuery != currentQuery)
            {
                _projections.UpdateQuery(name, expectedQuery, new UserCredentials("admin", "123456"));
            }
        }

        public T GetState<T>(string projectionName)
        {
            var state = _projections.GetState(projectionName);
            return state.ParseJson<T>();
        }
    }
}
