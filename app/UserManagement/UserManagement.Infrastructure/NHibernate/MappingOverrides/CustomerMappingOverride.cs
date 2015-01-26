using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class CustomerMappingOverride : IAutoMappingOverride<Customer>
    {
        public void Override(AutoMapping<Customer> mapping)
        {
            mapping.HasManyToMany(x => x.Users).Cascade.All().Table("UserLinkedToCustomer").ParentKeyColumn("CustomerId").ChildKeyColumn("UserId");
        }
    }
}