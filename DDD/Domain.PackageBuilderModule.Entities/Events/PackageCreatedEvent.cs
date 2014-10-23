using System;
using System.Diagnostics;
using System.Transactions;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Utils;
using LightstoneApp.Infrastructure.Data.Core.Commits;


namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Events
{
    public class PackageCreatedEvent : DomainEvent
    {
        private readonly ILogger _logger;
        private readonly Commit.Factory _commitFactory;

        //[JsonConstructor]
        private PackageCreatedEvent() : base(GuidUtil.NewSequentialId().ToString())
        {

            _commitFactory = new Commit.Factory();
            _logger = LoggerFactory.CreateLog();
        }
        public PackageCreatedEvent(Model.Package package)
            : this()
        {

            using (
                var transaction = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions {IsolationLevel = IsolationLevel.RepeatableRead}))
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

                    PackageCreated.EntityState = TrackState.Unchanged;

                    Name = package.Name;
                    Version = package.Version;

                    transaction.Complete();

                    
                }

                catch (Exception ex)
                {
                    Transaction.Current.Rollback();
                    Commit = null;

                    Debug.WriteLine(ex);
                    throw;
                }
                finally
                {
                    context.Dispose();
                }
            }
        }

        public Commit Commit { get; private set; }

        public new Guid Id { get; private set; }

        public string Name { get; private set; }
        public string Version { get; private set; }

        public Model.Package PackageCreated { get; private set; }
    }
}