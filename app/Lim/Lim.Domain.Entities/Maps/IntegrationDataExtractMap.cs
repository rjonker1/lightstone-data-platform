using FluentNHibernate.Mapping;
using Lim.Entities;

namespace Lim.Domain.Entities.Maps
{
    public class IntegrationDataExtractMap : ClassMap<IntegrationDataExtract>
    {
        public IntegrationDataExtractMap()
        {
            Table("IntegrationDataExtracts");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id").Index("IX_IntegrationDataExtracts_Id");
            References(x => x.Configuration).Column("ConfigurationId").Index("IX_IntegrationDataExtracts_ConfigurationId"); ;
            Map(x => x.DataExtractId).Not.Nullable().Index("IX_IntegrationDataExtracts_DataExtractId"); 
            Map(x => x.DateCreated).Default("GETUTCDATE()").Not.Nullable().Generated.Insert();
            Map(x => x.CreatedBy).Length(100);
            Map(x => x.DateModified);
            Map(x => x.ModifiedBy).Length(100); 
        }
    }
}
