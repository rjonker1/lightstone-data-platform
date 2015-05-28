using FluentNHibernate.Mapping;

namespace Lim.Domain.Entities.Maps {
    
    
    public class PackageResponsesMap : ClassMap<PackageResponses> {
        
        public PackageResponsesMap() {
			Table("PackageResponses");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("Id");
			Map(x => x.PackageId).Column("PackageId").Not.Nullable().Index("IX_PackageResponses_Id");
			Map(x => x.Userid).Column("UserId").Not.Nullable();
            Map(x => x.ContractId).Column("ContractId").Not.Nullable().Index("IX_PackageResponses_ContractId"); ;
			Map(x => x.AccountNumber).Column("AccountNumber").Not.Nullable();
			Map(x => x.ResponseDate).Column("ResponseDate").Not.Nullable();
			Map(x => x.RequestId).Column("RequestId").Not.Nullable();
            Map(x => x.Payload).Column("Payload").Not.Nullable().Length(10000);
			Map(x => x.HasResponse).Column("HasResponse").Not.Nullable();
            Map(x => x.CommitDate).Column("CommitDate").Not.Nullable().Default("GETUTCDATE()").Not.Nullable().Generated.Insert();
            Map(x => x.Username).Column("Username").Not.Nullable().Length(50); ;
        }
    }
}
