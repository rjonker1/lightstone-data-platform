using FluentNHibernate.Mapping;

namespace Toolbox.LSAuto.Entities.Maps
{
    public class ViewMap : ClassMap<View>
    {
        public ViewMap()
        {
            Table("Views");
            Not.LazyLoad();
            Id(m => m.Id).GeneratedBy.Identity().Column("Id");
            Map(m => m.AggregateId).Not.Nullable().Index("IX_Views_AggregateId");
            Map(m => m.Name).Not.Nullable().Length(100).Unique();
            Map(m => m.DisplayName).Not.Nullable().Length(200);
            Map(m => m.Activated).Not.Nullable().Default("0");
            Map(m => m.DateCreated).Not.Nullable().Default("GETUTCDATE()").Generated.Insert();
            Map(m => m.DateModified).Not.Nullable().Default("GETUTCDATE()").Generated.Always();
            Map(m => m.Version).Not.Nullable();
            Map(m => m.ModifiedBy).Nullable();
            Map(m => m.CreatedBy).Nullable();
        }
    }
}
