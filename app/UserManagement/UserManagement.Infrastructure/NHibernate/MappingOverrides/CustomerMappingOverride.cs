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
            //mapping.References(x => x.ContactDetail).Cascade.SaveUpdate();
            mapping.References(x => x.CommercialState).Cascade.SaveUpdate();
            mapping.References(x => x.Billing).Cascade.SaveUpdate();
            mapping.HasManyToMany(x => x.Clients).Cascade.SaveUpdate().Table("ClientCustomer").ParentKeyColumn("CustomerId").ChildKeyColumn("ClientId"); ; 
            mapping.HasManyToMany(x => x.Contracts).Cascade.SaveUpdate().Table("CustomerContract").ParentKeyColumn("CustomerId").ChildKeyColumn("ContractId"); 
            mapping.HasMany(x => x.CustomerUsers).Cascade.SaveUpdate().Table("CustomerUser"); // Inverse as User entity responsible for saving
            //mapping.HasMany(Customer.Expressions.Users)
            //    .Inverse()
            //    .AsSet()
            //    .LazyLoad()
            //    .KeyColumn("CustomerId");
            mapping.HasMany(x => x.Industries).Cascade.SaveUpdate();
            mapping.HasMany(x => x.Addresses).Cascade.SaveUpdate(); 
            mapping.HasMany(x => x.Notes).Cascade.SaveUpdate(); 
            mapping.References(x => x.Individual).Cascade.SaveUpdate(); 
        }
    }
}