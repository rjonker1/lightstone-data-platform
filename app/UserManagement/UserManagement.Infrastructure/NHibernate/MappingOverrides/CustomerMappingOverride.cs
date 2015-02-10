using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class CustomerMappingOverride : IAutoMappingOverride<Customer>
    {
        public void Override(AutoMapping<Customer> mapping)
        {
            mapping.References(x => x.ContactDetail).Cascade.All();
            mapping.HasManyToMany(x => x.Users).Cascade.All().Table("CustomerUser").ParentKeyColumn("CustomerId").ChildKeyColumn("UserId");

        }
    }
}