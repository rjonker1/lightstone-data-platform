using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Customers;

namespace UserManagement.Domain.CommandHandlers.Customers
{
    public class CreateUpdateCustomerHandler : AbstractMessageHandler<CreateUpdateCustomer>
    {
        private readonly IRepository<Customer> _repository;

        public CreateUpdateCustomerHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateUpdateCustomer command)
        {
            var customer = _repository.Get(command.Id);

            if (customer == null)
                _repository.Save(new Customer(command.Id, command.CustomerName, command.AccountOwnerName, command.Province));
            else
                customer.UpdateCustomer(command.CustomerName, command.AccountOwnerName, command.Province);
        }
    }
}