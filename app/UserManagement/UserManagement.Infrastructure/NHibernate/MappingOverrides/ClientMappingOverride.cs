using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class ClientMappingOverride : IAutoMappingOverride<Client>
    {
        public void Override(AutoMapping<Client> mapping)
        {
            mapping.References(x => x.ClientAccountNumber).Cascade.Persist();
            mapping.HasMany(x => x.UserAliases).Cascade.SaveUpdate();
            mapping.References(x => x.CommercialState).Cascade.SaveUpdate();
            mapping.References(x => x.Billing).Cascade.SaveUpdate();
            mapping.References(x => x.ContactDetail).Cascade.SaveUpdate();
            mapping.HasManyToMany(x => x.Customers).Cascade.SaveUpdate().Table("ClientCustomer");
            mapping.HasManyToMany(x => x.Contracts).Cascade.SaveUpdate().Table("ClientContract").ParentKeyColumn("ClientId").ChildKeyColumn("ContractId");
            mapping.HasMany(x => x.Industries).Cascade.SaveUpdate(); 
            mapping.HasMany(x => x.Addresses).Cascade.SaveUpdate(); 
        }
    }
}