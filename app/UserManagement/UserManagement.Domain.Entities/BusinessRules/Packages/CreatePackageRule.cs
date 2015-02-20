using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Packages
{
    public class CreatePackageRule : DomainCommand
    {

        public Package Entity;

        public CreatePackageRule(Package entity)
        {
            Entity = entity;
        }
    }
}