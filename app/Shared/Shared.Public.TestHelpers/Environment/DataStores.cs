using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.SqlServer;

namespace Shared.Public.TestHelpers.Environment
{
    public class Datastores
    {
        public static void Reset(IEnumerable<IDatastore> stores)
        {
            foreach (var store in stores)
            {
                store.Clear();
            }
        }

        public static void Rebuild(string[] migrationAssemblies, string[] connectionStrings)
        {
            var migrations = GetMigrationAssemblies(migrationAssemblies).ToList();
            migrations.Reverse();

            foreach (var migration in migrations)
            {
                try
                {
                    TearDown(migration, connectionStrings);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to run migrations for {0} because {1}", migration, e);
                    throw;
                }
            }

            migrations.Reverse();
            foreach (var migration in migrations)
            {
                try
                {
                    BuildUp(migration, connectionStrings);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to run migrations for {0} because {1}", migration, e);
                    throw;
                }
            }

            foreach (var migration in migrations)
            {
                try
                {
                    Profile(migration);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        private static void Profile(Assembly migration)
        {
            foreach (var runner in CreateProfileRunner(migration).Where(r => r != null))
            {
                Console.WriteLine("Creating profile data using {0}", migration.FullName);
                runner.MigrateUp();
            }
        }

        private static void BuildUp(Assembly migrationAssembly, IEnumerable<string> connectionStrings)
        {
            foreach (var runner in CreateMigrator(migrationAssembly, connectionStrings).Where(r => r != null))
            {
                Console.WriteLine("Building up using {0}", migrationAssembly.FullName);
                runner.MigrateUp();
            }
        }

        private static void TearDown(Assembly migrationAssembly, IEnumerable<string> connectionStrings)
        {
            foreach (var runner in CreateMigrator(migrationAssembly, connectionStrings).Where(r => r != null))
            {
                Console.WriteLine("Tearing down using {0}", migrationAssembly.FullName);
                runner.MigrateDown(0);
            }
        }

        private static IEnumerable<MigrationRunner> CreateMigrator(Assembly migrationAssembly, IEnumerable<string> connectionStrings)
        {
            var nullAnnouncer = new NullAnnouncer();

            foreach (
                var connectionString in connectionStrings.Where(connectionString => ConfigurationManager.ConnectionStrings[connectionString] != null))
            {
                if (string.IsNullOrEmpty(connectionString))
                    throw new Exception(
                        string.Format("Could not find a valid connection string to run the migrations against"));

                var factory = new SqlServer2008ProcessorFactory();
                var processor =
                    factory.Create(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString,
                        nullAnnouncer,
                        new ProcessorOptions());

                var context = new RunnerContext(nullAnnouncer);

                var runner = new MigrationRunner(migrationAssembly, context, processor);

                Console.WriteLine(string.Format("Creating migration using {0}", connectionString));

                yield return runner;
            }
        }

        private static IEnumerable<MigrationRunner> CreateProfileRunner(Assembly migrationAssembly)
        {
            var nullAnnouncer = new NullAnnouncer();
            var potentialConnectionStrings = new[] {"iBrokerConnectionString", "iCimsConnectionString"};

            foreach (
                var connectionString in
                    potentialConnectionStrings.Where(connectionString => ConfigurationManager.ConnectionStrings[connectionString] != null))
            {
                if (string.IsNullOrEmpty(connectionString))
                    throw new Exception(
                        string.Format("Could not find a valid connection string to run the migrations against"));

                var factory = new SqlServer2008ProcessorFactory();
                var processor =
                    factory.Create(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString,
                        nullAnnouncer,
                        new ProcessorOptions());

                var context = new RunnerContext(nullAnnouncer)
                {
                    Profile = "Development"
                };

                var runner = new MigrationRunner(migrationAssembly, context, processor);

                yield return runner;
            }
        }


        private static IEnumerable<Assembly> GetMigrationAssemblies(string[] migrationAssemblies)
        {
            foreach (var potentialDatabase in migrationAssemblies)
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    string.Format("{0}.dll", potentialDatabase));

                if (File.Exists(path))
                {
                    Console.WriteLine("Found migration assembly at {0}", path);
                    var assembly = Assembly.Load(potentialDatabase);

                    yield return assembly;
                }
            }
        }
    }
}