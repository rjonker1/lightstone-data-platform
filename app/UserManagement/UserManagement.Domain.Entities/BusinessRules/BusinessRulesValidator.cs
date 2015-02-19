using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities.BusinessRules.Clients;
using UserManagement.Domain.Entities.BusinessRules.Users;

namespace UserManagement.Domain.Entities.BusinessRules
{
    public class BusinessRulesValidator
    {

        private readonly IHandleMessages _handler;

        public BusinessRulesValidator(IHandleMessages handler)
        {
            _handler = handler;
        }

        //Run rules based on entity type of the currently transacted entity.
        public void CheckRules(object enity)
        {

            if (enity is User)
            {
                _handler.Handle(new CreateUserRule(enity as User));
            }
            else if (enity is Customer)
            {
                //Customer rule reference
            }
            else if (enity is Client)
            {
                _handler.Handle(new CreateClientRule(enity as Client));
            }
            else if (enity is Package)
            {
                //Package rule reference
            }

        }
    }
}