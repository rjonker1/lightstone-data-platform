using FluentNHibernate.Mapping;

namespace Toolbox.LSAuto.Entities.Maps
{
    public class DataSetMap : ClassMap<DataSet>
    {
        public DataSetMap()
        {
            Table("DataSets");
            Not.LazyLoad();
            Id(x => x.Id).Column("Id").Index("IX_DataSets_Id");
            //TODO: Rest of mapping
        }
    }
}
