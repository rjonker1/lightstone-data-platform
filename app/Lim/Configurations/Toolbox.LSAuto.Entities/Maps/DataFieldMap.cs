using FluentNHibernate.Mapping;

namespace Toolbox.LSAuto.Entities.Maps
{
    public class DataFieldMap : ClassMap<DataField>
    {
        public DataFieldMap()
        {
            Table("DataFields");
            Not.LazyLoad();
            Id(m => m.Id).GeneratedBy.Identity().Column("Id");
            References(m => m.DataSet).Column("DataSetId").Not.Nullable().Index("IX_DataField_DataSetId");
            Map(m => m.Name).Not.Nullable().Length(100);
            Map(m => m.DisplayName).Not.Nullable().Length(100);
            Map(m => m.Selected).Not.Nullable().Default("0");
            Map(m => m.Activated).Not.Nullable().Default("0");
            Map(m => m.DateCreated).Not.Nullable().Default("GETUTCDATE()").Generated.Insert();
            Map(m => m.DateModified).Not.Nullable().Default("GETUTCDATE()").Generated.Always();

        }
    }
}
