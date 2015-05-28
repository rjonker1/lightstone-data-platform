using System;
using FluentNHibernate.Mapping;

namespace Lim.Domain.Entities.Maps {
    
    
    public class ClientMap : ClassMap<Client> {
        
        public ClientMap() {
			Table("Client");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("Id").Index("IX_Client_Id");
			Map(x => x.IsActive).Column("IsActive").Not.Nullable();
			Map(x => x.Name).Column("Name").Not.Nullable().Length(50);
            Map(x => x.Email).Column("Email").Not.Nullable().Length(100);
            Map(x => x.ContactPerson).Column("ContactPerson").Not.Nullable().Length(50);
            Map(x => x.ContactNumber).Column("ContactNumber").Not.Nullable().Length(20);
            Map(x => x.DateCreated).Column("DateCreated").Default("GETUTCDATE()").Not.Nullable().Generated.Insert();
            Map(x => x.CreatedBy).Column("CreatedBy").Length(50).Not.Nullable().Insert();
			Map(x => x.DateModified).Column("DateModified");
            Map(x => x.ModifiedBy).Column("ModifiedBy").Length(50);
        }
    }
}
