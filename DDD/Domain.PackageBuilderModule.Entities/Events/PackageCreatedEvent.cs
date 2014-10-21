using System;
using System.Data.Entity.Infrastructure;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Events
{

    public class PackageCreatedEvent : DomainEvent
    {
        private readonly ILogger _logger;

        //[JsonConstructor]
        public PackageCreatedEvent()
        {
            Id = IdentityGenerator.NewSequentialGuid();

            _logger = LoggerFactory.CreateLog();


        }
        public PackageCreatedEvent(Model.Package package)
            : this()
        {
            var context = new Model.LightstoneAppDatabaseEntities();

            context.ChangeTracker.DetectChanges();

           
            context.Packages.Add(package);

            try
            {
                context.SaveChanges();

                PackageCreated = package;

                Name = package.Name;
                Version = package.Version;
            }
            catch (DbUpdateException dbeException)
            {
                if (_logger != null) _logger.Error(dbeException.InnerException.InnerException.Message);
                throw;
            }
            catch (Exception ex)
            {
                if (_logger != null) _logger.Error("Error saving package", _logger);
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