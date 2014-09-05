using FluentNHibernate.Cfg;
using NHibernate.Cfg;

namespace PackageBuilder.Data.NHibernate
{
    /// <summary>
    /// Responsible for configuring NHibernate
    /// </summary>
    public class NHibernateBootstrapper
    {
        public static Configuration Build()
        {
            var configuration = new Configuration().Configure("nhibernate.cfg.xml");

            return Fluently.Configure(configuration)
                .Mappings(cfg =>
                {
                    //cfg.FluentMappings.AddFromAssemblyOf<>();
                }).BuildConfiguration();
        }
    }
}