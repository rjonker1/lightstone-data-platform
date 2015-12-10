using FluentNHibernate.Mapping;

namespace Toolbox.LSAuto.Entities.Maps
{
    public class DataSetMap : ClassMap<DataSet>
    {
        public DataSetMap()
        {
            Table("DataSets");
            Not.LazyLoad();
            Id(m => m.Id).GeneratedBy.Identity().Column("Id");
            Map(m => m.AggregateId).Not.Nullable().Index("IX_DataSets_AggregateId");
            Map(m => m.Activated).Not.Nullable().Default("0");
            Map(m => m.CreatedBy).Nullable();
            Map(m => m.DateModified).Not.Nullable().Default("GETUTCDATE()").Generated.Always();
            Map(m => m.Description).Length(1000).Nullable();
            Map(m => m.ModifiedBy).Nullable();
            Map(m => m.DateCreated).Not.Nullable().Default("GETUTCDATE()").Generated.Insert();
            Map(m => m.Name).Not.Nullable().Length(100);
            Map(m => m.Version).Not.Nullable();
        }
    }
}
