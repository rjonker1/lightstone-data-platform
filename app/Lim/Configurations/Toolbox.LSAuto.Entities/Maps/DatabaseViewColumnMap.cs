using FluentNHibernate.Mapping;

namespace Toolbox.LSAuto.Entities.Maps
{
    public class DatabaseViewColumnMap : ClassMap<DatabaseViewColumn>
    {
        public DatabaseViewColumnMap()
        {
            Table("DatabaseViewColumns");
            Not.LazyLoad();
            Id(m => m.Id).GeneratedBy.Identity();
            References(m => m.DatabaseView).Column("DatabaseViewId").Not.Nullable().Index("IX_DatabaseViewColumns_ViewId");
            Map(m => m.Name).Not.Nullable().Length(100);
            Map(m => m.DisplayName).Not.Nullable().Length(100);
            Map(m => m.DateCreated).Not.Nullable().Default("GETUTCDATE()").Generated.Insert();
            Map(m => m.DateModified).Not.Nullable().Default("GETUTCDATE()").Generated.Always();
        }
    }
}