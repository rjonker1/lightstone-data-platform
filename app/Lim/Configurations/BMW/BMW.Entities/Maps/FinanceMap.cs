using FluentNHibernate.Mapping;

namespace Toolbox.Bmw.Entities.Maps
{
    public class FinanceMap : ClassMap<Finance>
    {
        public FinanceMap()
        {
            Table("Finances");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Guid().Column("Id");
            Map(x => x.Chassis).Column("Chassis").Nullable().Length(100);
            Map(x => x.Engine).Column("Engine").Nullable().Length(100);
            Map(x => x.RegistrationNumber).Column("RegistrationNumber").Nullable().Length(100);
            Map(x => x.Description).Column("Description").Nullable().Length(500);
            Map(x => x.RegistrationYear).Column("RegistrationYear").Nullable();
            Map(x => x.DealType).Column("DealType").Nullable().Length(100);
            Map(x => x.DealStatus).Column("DealStatus").Nullable().Length(10);
            Map(x => x.VinEngineId).Column("VinEngineId").Nullable().Length(50);
        }
    }
}