using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Customers;

namespace UserManagement.Domain.CommandHandlers.Customers
{
    public class CreateCustomerHandler : AbstractMessageHandler<CreateCustomer>
    {

        public readonly IRepository<Customer> _repsoitory;

        public CreateCustomerHandler(IRepository<Customer> repsoitory)
        {
            _repsoitory = repsoitory;
        }

        public override void Handle(CreateCustomer command)
        {
            
            _repsoitory.Save(new Customer(command.Id, command.CustomerName, command.AccountOwnerName));
        }
    }
}