using System;
using System.Collections.Generic;
using System.Linq;
using EventStore.ClientAPI;
using EventStore.ClientAPI.Common.Log;
using EventStore.ClientAPI.Common.Utils;
using EventTracking.Domain.Core;

namespace EventTracking.Measurement
{
    public class ProjectionContext : IProjectionContext
    {
        private readonly ProjectionsManager _projections;

        private readonly IEnumerable<Projection> _currentProjections;

        public ProjectionContext()
        {
            var logger = new ConsoleLogger();
            _projections = new ProjectionsManager(logger, IpEndPointFactory.DefaultHttp());

            _currentProjections = GetCurrentProjections();
        }

        private IEnumerable<Projection> GetCurrentProjections()
        {
            var all = _projections.ListAll(EventStoreCredentials.Default);

            var json = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(all);
            var projections = new List<Projection>();

            Console.WriteLine("Current projections: ");

            foreach (var projection in json.projections)
            {
                var newProjection = new Projection(projection.name.Value, projection.status.Value);

                projections.Add(newProjection);
                 Console.WriteLine("> " + newProjection);
            }
            return projections;
        }

        public void EnableProjection(string name)
        {
            if (_currentProjections.Any(p => p.Name == name && p.Status != "Stopped")) return;

            _projections.Enable(name, EventStoreCredentials.Default);
            
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
            Console.WriteLine("Add projection: " + name);

            _projections.CreateContinuous(name, expectedQuery, EventStoreCredentials.Default);
            
        }

        private void UpdateProjection(string name, string expectedQuery)
        {
            Console.WriteLine("Update existing projection: " + name);

            var currentQuery = _projections.GetQuery(name, EventStoreCredentials.Default);

            if (expectedQuery != currentQuery)
            {
                _projections.UpdateQuery(name, expectedQuery, EventStoreCredentials.Default);
            }
        }

        public T GetState<T>(string projectionName)
        {
            var state = _projections.GetState(projectionName);
            return state.ParseJson<T>();
        }
    }
}
