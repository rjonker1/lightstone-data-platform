using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lim.Database
{
    //public class MigrationRunner
    //{
    //    public class Options : IMigrationProcessorOptions
    //    {
    //        public Options(bool previewOnly, string providerSwitches, int timeout)
    //        {
    //            PreviewOnly = previewOnly;
    //            ProviderSwitches = providerSwitches;
    //            Timeout = timeout;
    //        }

    //        public bool PreviewOnly { get; private set; }
    //        public string ProviderSwitches { get; private set; }
    //        public int Timeout { get; private set; }
    //    }

    //    public static void MigrateToLatestVersion(string connection)
    //    {
    //        var announcer = new TextWriterAnnouncer
    //    }
    //}

    public class MigrationRunner
    {
        private readonly string _connectionString;

        public MigrationRunner(string dbConnectionString)
        {
            _connectionString = dbConnectionString;
        }

        public string Up(long version)
        {
            var tw = new System.IO.StringWriter();
            var announcer = new FluentMigrator.Runner.Announcers.TextWriterAnnouncer(tw);

            ExecuteMigrations(announcer, _connectionString, MigrationTask.Up, version);
            return tw.ToString();
        }
        public string Down(long version)
        {
            var tw = new System.IO.StringWriter();
            var announcer = new FluentMigrator.Runner.Announcers.TextWriterAnnouncer(tw);

            ExecuteMigrations(announcer, _connectionString, MigrationTask.Down, version);
            return tw.ToString();
        }
        public void Rollback(long version) { }
        public void RollBack() { }


        private void ExecuteMigrations(IAnnouncer announcer, string connectionString, string migrationTask, long version = 0)
        {

            var runnerContext = new RunnerContext(announcer)
            {
                Database = "sqlserver",
                Connection = connectionString,
                Target = System.Reflection.Assembly.GetAssembly(GetType()).FullName,
                Task = String.IsNullOrEmpty(migrationTask) ? MigrationTask.Default : migrationTask,
                Version = version
            };

            new TaskExecutor(runnerContext).Execute();
        }

        public static void RunStartupMigrationCheck()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            var migrationVersion = long.Parse(System.Configuration.ConfigurationManager.AppSettings["RecipmeMigrationVersion"]);

            var migrationRunner = new MigrationRunner(connectionString);


            long? currentVersion = null;
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    if(connection.State == ConnectionState.Closed)
                        connection.Open();
                    var version = connection.Query<long>("select max(Version) from VersionInfo").FirstOrDefault();
                    currentVersion = version;
                }
            }
            catch (Exception e) { }

            if (currentVersion != null)
            {
#if DEBUG
                if (migrationVersion < currentVersion.Value) migrationRunner.Down(migrationVersion);
#endif
                if (migrationVersion > currentVersion.Value) migrationRunner.Up(migrationVersion);
            }
            else
            {
                migrationRunner.Up(migrationVersion);
            }
        }
    }

    public class MigrationTask
    {
        public const string Default = "migrate";
        public const string Up = "migrate:up";
        public const string Down = "migrate:down";
        public const string Rollback = "rollback";
        public const string RollbackToVersion = "rollback:toversion";
        public const string RollbackAll = "rollback:all";

    }
}
