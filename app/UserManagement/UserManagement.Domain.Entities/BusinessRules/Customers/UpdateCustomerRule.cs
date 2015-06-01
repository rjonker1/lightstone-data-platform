using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Customers
{
    public class UpdateCustomerRule : DomainCommand
    {
        public Customer Entity;

        public UpdateCustomerRule(Customer entity)
        {
            Entity = entity;
        }
    }
}