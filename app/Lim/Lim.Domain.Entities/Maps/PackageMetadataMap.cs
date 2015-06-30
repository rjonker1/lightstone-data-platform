using System;
using FluentNHibernate.Mapping;

namespace Lim.Domain.Entities.Maps
{
    public class PackageMetadataMap : ClassMap<PackageMetadata>
    {
        public PackageMetadataMap()
        {
            Table("PackageMetadata");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.Payload).Column("Payload").Not.Nullable().Length(Int32.MaxValue);
            Map(x => x.Description).Column("Description").Nullable().Length(100);
            Map(x => x.DateCreated).Column("DateCreated").Not.Nullable().Default("getutcdate()").Generated.Insert();
            Map(x => x.DateUpdated).Column("DateUpdated").Nullable();
        }
    }
}
