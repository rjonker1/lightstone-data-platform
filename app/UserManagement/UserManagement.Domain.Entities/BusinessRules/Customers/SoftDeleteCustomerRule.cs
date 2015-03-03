using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Customers
{
    public class SoftDeleteCustomerRule : DomainCommand
    {

        public Customer Entity;

        public SoftDeleteCustomerRule(Customer entity)
        {
            Entity = entity;
        }
    }
}