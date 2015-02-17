using System;
using System.Collections.Generic;
using System.Linq;

namespace UserManagement.Domain.Dtos
{
    public class UserDto
    {
        public UserDto()
        {
            Customers = Enumerable.Empty<NamedEntityDto>();
            ClientUsers = Enumerable.Empty<ClientUserDto>();
        }

        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string IdNumber { get; set; }
        public virtual string ContactNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public Guid UserTypeId { get; set; }
        public IEnumerable<Guid> RoleIds { get; set; }
        public IEnumerable<Guid> CustomerIds { get; set; }
        public IEnumerable<NamedEntityDto> Customers { get; set; }
        public IEnumerable<ClientUserDto> ClientUsers { get; set; }
    }
}