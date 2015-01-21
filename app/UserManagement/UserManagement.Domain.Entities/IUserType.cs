using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public interface IUserType : INamedEntity
    {
        string Name { get; set; }
        string Value { get; set; }
        ICollection<User> User { get; set; }
    }
}