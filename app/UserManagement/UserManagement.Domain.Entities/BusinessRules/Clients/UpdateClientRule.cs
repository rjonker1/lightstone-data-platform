namespace UserManagement.Domain.Entities.BusinessRules.Clients
{
    public class UpdateClientRule
    {
        public Client Entity;

        public UpdateClientRule(Client entity)
        {
            Entity = entity;
        }
    }
}