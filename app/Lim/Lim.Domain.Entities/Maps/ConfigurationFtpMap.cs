using FluentNHibernate.Mapping;
using Lim.Entities;

namespace Lim.Domain.Entities.Maps
{
    public class ConfigurationFtpMap : ClassMap<ConfigurationFtp>
    {
        public ConfigurationFtpMap()
        {
            Table("ConfigurationFtp");
            Not.LazyLoad();
            Id(m => m.Id).GeneratedBy.Identity().Column("Id").Index("IX_ConfigurationFtp_Id");
            References(m => m.Configuration).Column("ConfigurationId").Not.Nullable().Index("IX_ConfigurationFtp_ConfigurationId").Not.LazyLoad();
            Map(m => m.Host).Not.Nullable().Length(1000);
            Map(m => m.FileName).Not.Nullable().Length(250);
            Map(m => m.Username).Not.Nullable().Length(500);
            Map(m => m.Password).Not.Nullable().Length(500);
            Map(m => m.DateCreated).Not.Nullable().Not.Nullable().Default("GETUTCDATE()").Not.Nullable().Generated.Insert();
            Map(m => m.CreatedBy).Length(100).Nullable();
        }
    }
}
