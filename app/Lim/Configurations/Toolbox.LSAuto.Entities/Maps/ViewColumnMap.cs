using FluentNHibernate.Mapping;

namespace Toolbox.LSAuto.Entities.Maps
{
    public class ViewColumnMap : ClassMap<ViewColumn>
    {
        public ViewColumnMap()
        {
            Table("ViewColumns");
            Not.LazyLoad();
            Id(m => m.Id).GeneratedBy.Identity();
            References(m => m.View).Column("ViewId").Not.Nullable().Index("IX_ViewColumns_ViewId");
            Map(m => m.Name).Not.Nullable().Length(100);
            Map(m => m.DisplayName).Not.Nullable().Length(100);
            Map(m => m.DateCreated).Not.Nullable().Default("GETUTCDATE()").Generated.Insert();
            Map(m => m.DateModified).Not.Nullable().Default("GETUTCDATE()").Generated.Always();
        }
    }
}