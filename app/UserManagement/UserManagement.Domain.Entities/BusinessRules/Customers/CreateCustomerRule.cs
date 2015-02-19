using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Customers
{
    public class CreateCustomerRule : DomainCommand
    {

        public Customer Entity;

        public CreateCustomerRule(Customer entity)
        {
            Entity = entity;
        }
    }
}