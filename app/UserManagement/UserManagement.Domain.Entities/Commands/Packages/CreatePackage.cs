using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Packages
{
    public class CreatePackage : DomainCommand
    {

        public string LastUpdateBy;
        public DateTime LastUpdateDate;
        public string Name;
        public string Version;
        public bool? IsActivated;

        public CreatePackage(string lastUpdateBy, DateTime lastUpdateDate, string name, string version, bool? isActivated)
        {
            Id = Guid.NewGuid();
            LastUpdateBy = lastUpdateBy;
            LastUpdateDate = lastUpdateDate;
            Name = name;
            Version = version;
            IsActivated = isActivated;
        }
    }
}