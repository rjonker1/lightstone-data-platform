using FluentNHibernate.Mapping;
using Lim.Entities;

namespace Lim.Domain.Entities.Maps {
    public class ActionTypeMap : ClassMap<ActionType> {
        
        public ActionTypeMap() {
			Table("ActionType");
			Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.Type).Column("Type").Not.Nullable().Length(50);
			Map(x => x.IsActive).Column("IsActive").Not.Nullable();
        }
    }
}
