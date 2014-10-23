

using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.BlobStorage;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.EventSourcing;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.MessageLog;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging.Implementation;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Database.Initializer
{
    class DatabaseInitializer
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.AppSettings["defaultConnection"];
            if (args.Length > 0)
            {
                connectionString = args[0];
            }

            // Use DomainContext as entry point for dropping and recreating DB
            //using (var context = new DomainContext(connectionString))
            //{
            //    if (context.Database.Exists())
            //        context.Database.Delete();

            //    context.Database.Create();
            //}

            System.Data.Entity.Database.SetInitializer<EventStoreDbContext>(null);
            System.Data.Entity.Database.SetInitializer<MessageLogDbContext>(null);
            System.Data.Entity.Database.SetInitializer<BlobStorageDbContext>(null);


            var contexts =
                new DbContext[] 
                { 
                    new EventStoreDbContext(connectionString),
                    new MessageLogDbContext(connectionString),
                    new BlobStorageDbContext(connectionString),
                };

            foreach (DbContext context in contexts)
            {
                var adapter = (IObjectContextAdapter)context;

                var script = adapter.ObjectContext.CreateDatabaseScript();

                context.Database.ExecuteSqlCommand(script);

                context.Dispose();
            }

            //using (var context = new SubDomainBoundedContextDbContext(connectionString))
            //{
            //    SubDomainBoundedContexContextInitializer.CreateIndexes(context);
            //}

            

            MessagingDbInitializer.CreateDatabaseObjects(connectionString, "SqlBus");
        }
    }
}
