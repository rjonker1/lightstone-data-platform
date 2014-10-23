using System;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Events
{
    public class PackageCreatedEvent : DomainEvent
    {
        private readonly ILogger _logger;

        //[JsonConstructor]
        private PackageCreatedEvent()
        {
            //Id = new Guid(base.Id);

             

            _logger = LoggerFactory.CreateLog();
        }
        public PackageCreatedEvent(Model.Package package)
            : this()
        {

            Id = package.Id;
            var context = new Model.LightstoneAppDatabaseEntities();

            context.Configuration.ValidateOnSaveEnabled = false;

            package.EntityState = TrackState.Added;
           
            context.Packages.Add(package);

            try
            {
                context.SaveChanges();

                PackageCreated = package;

                Name = package.Name;
                Version = package.Version;
            }
           
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            finally
            {
                context.Dispose();
            }
        }

        public new Guid Id { get; private set; }

        public string Name { get; private set; }
        public string Version { get; private set; }

        public Model.Package PackageCreated { get; private set; }
    }
}