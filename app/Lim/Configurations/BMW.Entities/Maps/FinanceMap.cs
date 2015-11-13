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
            Map(x => x.FinanceHouse).Column("FinanceHouse").Nullable().Length(200);
            Map(x => x.DealReference).Column("DealReference").Nullable().Length(300).Index("IX_Bmw_Finance_DealReference");
            Map(x => x.StartDate).Column("StartDate").Nullable();
            Map(x => x.ExpireDate).Column("ExpireDate").Nullable();
            Map(x => x.Chassis).Column("Chassis").Nullable().Length(100).Index("IX_Bmw_Finance_Chassis");
            Map(x => x.Engine).Column("Engine").Nullable().Length(100).Index("IX_Bmw_Finance_Engine");
            Map(x => x.RegistrationNumber).Column("RegistrationNumber").Nullable().Length(100).Index("IX_Bmw_Finance_RegNumber");
            Map(x => x.Description).Column("Description").Nullable().Length(500);
            Map(x => x.RegistrationYear).Column("RegistrationYear").Nullable();
            Map(x => x.DealType).Column("DealType").Nullable().Length(100);
            Map(x => x.DealStatus).Column("DealStatus").Nullable().Length(10);
            Map(x => x.ClientNumber).Column("ClientNumber").Nullable().Length(25);
            Map(x => x.VinEngineId).Column("VinEngineId").Nullable().Length(50).Index("IX_Bmw_Finance_VinEngineId");
            Map(x => x.DateAdded).Column("DateAdded").Not.Nullable().Default("GETUTCDATE()").Generated.Insert();
        }
    }
}