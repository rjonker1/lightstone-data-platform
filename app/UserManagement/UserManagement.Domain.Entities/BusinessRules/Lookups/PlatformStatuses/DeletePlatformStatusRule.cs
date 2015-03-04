using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Lookups.PlatformStatuses
{
    public class DeletePlatformStatusRule : DomainCommand
    {

        public PlatformStatus Entity;

        public DeletePlatformStatusRule(PlatformStatus entity)
        {
            Entity = entity;
        }
    }
}