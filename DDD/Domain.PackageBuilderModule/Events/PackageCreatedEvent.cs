using System;
using System.Diagnostics;
using LightstoneApp.Domain.PackageBuilderModule.Entities;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Utils;
using LightstoneApp.Infrastructure.Data.Core.Commits;

namespace LightstoneApp.Domain.PackageBuilderModule.Events
{
    public class PackageCreatedEvent : DomainEvent
    {
        private readonly ILogger _logger;
        private readonly Commit.Factory _commitFactory;

        //[JsonConstructor]
        private PackageCreatedEvent() : base(GuidUtil.NewSequentialId().ToString())
        {
            _commitFactory = new Commit.Factory();
            LoggerFactory.SetCurrent(new TraceSourceLogFactory());
            _logger = LoggerFactory.CreateLog();
        }
        public PackageCreatedEvent(Package package)
            : this()
        {
                try
                {
                   PackageCreated = package;

                    Name = package.Name;
                    Version = package.Version;
                }

                catch (Exception ex)
                {
                   Debug.WriteLine(ex);
                    throw;
                }
        }

        public Commit Commit { get; private set; }

        public new Guid Id { get; private set; }

        public string Name { get; private set; }
        public string Version { get; private set; }

        public Package PackageCreated { get; private set; }
    }
}