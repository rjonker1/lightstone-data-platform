using FluentNHibernate.Mapping;

namespace Lim.Domain.Entities.Maps {
    public class FrequencyTypeMap : ClassMap<FrequencyType> {
        
        public FrequencyTypeMap() {
			Table("FrequencyType");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.Type).Column("Type").Not.Nullable().Length(50);
			Map(x => x.IsActive).Column("IsActive").Not.Nullable();
        }
    }
}
