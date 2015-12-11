using FluentNHibernate.Mapping;

namespace Toolbox.LSAuto.Entities.Maps
{
    public class DatabaseExtractFieldMap : ClassMap<DatabaseExtractField>
    {
        public DatabaseExtractFieldMap()
        {
            Table("DatabaseExtractFields");
            Not.LazyLoad();
            Id(m => m.Id).GeneratedBy.Identity().Column("Id");
            References(m => m.DatabaseExtract).Column("DatabaseExtractId").Not.Nullable().Index("IX_DatabaseExtractFields_DataSetId");
            Map(m => m.Name).Not.Nullable().Length(100);
            Map(m => m.DisplayName).Not.Nullable().Length(100);
            Map(m => m.Selected).Not.Nullable().Default("0");
            Map(m => m.DateCreated).Not.Nullable().Default("GETUTCDATE()").Generated.Insert();
            Map(m => m.DateModified).Not.Nullable().Default("GETUTCDATE()").Generated.Always();
        }
    }
}
