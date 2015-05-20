using System;
using System.Reflection;
//using FluentMigrator;
//using FluentMigrator.Runner;
//using FluentMigrator.Runner.Announcers;
//using FluentMigrator.Runner.Initialization;
//using FluentMigrator.Runner.Processors;

namespace Lim.Database
{
//    public class Runner
//    {
//        public class MigrationOptions : IMigrationProcessorOptions
//        {
//            public MigrationOptions(bool previewOnly, string providerSwitches, int timeout)
//            {
//                PreviewOnly = previewOnly;
//                ProviderSwitches = providerSwitches;
//                Timeout = timeout;
//            }

//            public bool PreviewOnly { get; private set; }
//            public string ProviderSwitches { get; private set; }
//            public int Timeout { get; private set; }
//        }

//        public static void MigrateLatestVersion()
//        {
//            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["lim/schedule/database"].ConnectionString;
//            var version = long.Parse(System.Configuration.ConfigurationManager.AppSettings["lim/database/currentversion"]);

//            var announcer = new TextWriterAnnouncer(s => Console.WriteLine(s));
//            //var assembly = Assembly.GetExecutingAssembly();
//            var assembly = Assembly.GetAssembly(typeof (Lim.Database.Migrations.CreateLimActionTypeTable));

//            var context = new RunnerContext(announcer)
//            {
//                Namespace = "Lim.Database.Migrations"
//            };

//            //var options = new MigrationOptions(false, null, 60);
//            IMigrationProcessorOptions options = new ProcessorOptions
//            {
//                PreviewOnly = false,
//                Timeout = 60
//            };
//            var factory = new FluentMigrator.Runner.Processors.SqlServer.SqlServer2012ProcessorFactory();
//            var processor = factory.Create(connection, announcer, options);
//            var runner = new MigrationRunner(assembly, context, processor);

//#if DEBUG
//            //  runner.MigrateDown(version);
//#endif

//            runner.MigrateUp();

//        }
//    }

//    public class MigrationRunner
//    {
//        private readonly string _connectionString;

//        public MigrationRunner(string dbConnectionString)
//        {
//            _connectionString = dbConnectionString;
//        }

//        public string Up(long version)
//        {
//            var tw = new System.IO.StringWriter();
//            var announcer = new FluentMigrator.Runner.Announcers.TextWriterAnnouncer(tw);

//            ExecuteMigrations(announcer, _connectionString, MigrationTask.Up, version);
//            return tw.ToString();
//        }
//        public string Down(long version)
//        {
//            var tw = new System.IO.StringWriter();
//            var announcer = new FluentMigrator.Runner.Announcers.TextWriterAnnouncer(tw);

//            ExecuteMigrations(announcer, _connectionString, MigrationTask.Down, version);
//            return tw.ToString();
//        }
//        public void Rollback(long version) { }
//        public void RollBack() { }


//        private void ExecuteMigrations(IAnnouncer announcer, string connectionString, string migrationTask, long version = 0)
//        {

//            var runnerContext = new RunnerContext(announcer)
//            {
//                Database = "sqlserver",
//                Connection = connectionString,
//                Targets = new[] {System.Reflection.Assembly.GetAssembly(GetType()).FullName},
//                Task = String.IsNullOrEmpty(migrationTask) ? MigrationTask.Default : migrationTask,
//                Version = version
//            };

//            new TaskExecutor(runnerContext).Execute();
//        }

//        public static void RunMigration()
//        {
//            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["lim/schedule/database"].ConnectionString;
//            var migrationVersion = long.Parse(System.Configuration.ConfigurationManager.AppSettings["lim/database/currentversion"]);

//            var migrationRunner = new MigrationRunner(connectionString);

//            long? currentVersion = null;
//            try
//            {
//                using (IDbConnection connection = new SqlConnection(connectionString))
//                {
//                    if(connection.State == ConnectionState.Closed)
//                        connection.Open();
//                    var version = connection.Query<long>("select isnull(max(Version),0) from VersionInfo").FirstOrDefault();
//                    currentVersion = version;
//                }
//            }
//            catch (Exception e) { }

//            if (currentVersion != null)
//            {
//#if DEBUG
//                if (migrationVersion < currentVersion.Value) migrationRunner.Down(migrationVersion);
//#endif
//                if (migrationVersion > currentVersion.Value) migrationRunner.Up(migrationVersion);
//            }
//            else
//            {
//                migrationRunner.Up(migrationVersion);
//            }
//        }
//    }

//    public class MigrationTask
//    {
//        public const string Default = "migrate";
//        public const string Up = "migrate:up";
//        public const string Down = "migrate:down";
//        public const string Rollback = "rollback";
//        public const string RollbackToVersion = "rollback:toversion";
//        public const string RollbackAll = "rollback:all";

//    }
//}
}
