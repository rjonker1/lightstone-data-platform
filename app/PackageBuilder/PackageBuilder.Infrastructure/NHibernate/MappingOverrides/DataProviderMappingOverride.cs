using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using PackageBuilder.Domain.Entities.DataProviders.Read;

namespace PackageBuilder.Infrastructure.NHibernate.MappingOverrides
{
    public class DataProviderMappingOverride : IAutoMappingOverride<DataProvider>
    {
        public void Override(AutoMapping<DataProvider> mapping)
        {
            mapping.Map(x => x.Name).CustomType<int>();
        }
    }
}