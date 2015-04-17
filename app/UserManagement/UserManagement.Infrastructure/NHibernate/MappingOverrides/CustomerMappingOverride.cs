using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class CustomerMappingOverride : IAutoMappingOverride<Customer>
    {
        public void Override(AutoMapping<Customer> mapping)
        {
            mapping.References(x => x.CustomerAccountNumber).Cascade.Persist();
            mapping.References(x => x.ContactDetail).Cascade.SaveUpdate();
            mapping.References(x => x.CommercialState).Cascade.SaveUpdate();
            mapping.References(x => x.PlatformStatus).Cascade.SaveUpdate();
            mapping.References(x => x.Billing).Cascade.SaveUpdate();
            mapping.References(x => x.CreateSource).Cascade.SaveUpdate(); 
            mapping.HasManyToMany(x => x.Contracts).Cascade.SaveUpdate().Table("CustomerContract"); // Inverse as User entity responsible for saving
            mapping.HasManyToMany(x => x.Users).Cascade.SaveUpdate().Table("CustomerUser"); // Inverse as User entity responsible for saving
        }
    }
}