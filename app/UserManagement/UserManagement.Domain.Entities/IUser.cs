using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Entities
{
    public interface IUser
    {

        IEnumerable<IUserRole> UserRoles { get; } 
        IEnumerable<IClientUser> ClientUsers { get; } 
        void Add(IRole role);

    }
}
