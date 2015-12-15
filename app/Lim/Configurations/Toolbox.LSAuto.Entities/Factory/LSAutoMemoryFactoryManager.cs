using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Toolbox.LSAuto.Entities.Factory
{
   /// <summary>
   /// Provides In Memory Database - to be used in unit tests etc...
   /// </summary>
    public class LightstoneAutoInMemoryFactoryManager
    {
        private static LightstoneAutoInMemoryFactoryManager _instance;
        public static LightstoneAutoInMemoryFactoryManager Instance
        {
            get { return _instance ?? (_instance = new LightstoneAutoInMemoryFactoryManager()); }
        }

        private ISessionFactory _sessionFactory;
        private Configuration _configuration;
        private LightstoneAutoInMemoryFactoryManager() { }
        public void Initialize()
        {
            _sessionFactory = CreateSessionFactory();
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Maps.DatabaseExtractMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Maps.DatabaseExtractFieldMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Maps.DatabaseViewMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Maps.DatabaseViewColumnMap>())
                .ExposeConfiguration(cfg => _configuration = cfg)
                .BuildSessionFactory();
        }
        public ISession OpenSession()
        {
            Initialize();
            ISession session = _sessionFactory.OpenSession();
            var export = new SchemaExport(_configuration);
            export.Execute(true, true, false, session.Connection, null);

            return session;
        }

        public void Dispose()
        {
            if (_sessionFactory != null)
                _sessionFactory.Dispose();

            _sessionFactory = null;
            _configuration = null;
        }
    }
}