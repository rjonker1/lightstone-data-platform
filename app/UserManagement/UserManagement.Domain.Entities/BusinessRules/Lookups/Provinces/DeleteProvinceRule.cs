using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Lookups.Provinces
{
    public class DeleteProvinceRule : DomainCommand
    {

        public Province Entity;

        public DeleteProvinceRule(Province entity)
        {
            Entity = entity;
        }
    }
}