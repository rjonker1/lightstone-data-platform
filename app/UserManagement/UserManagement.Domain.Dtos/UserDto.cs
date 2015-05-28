using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UserManagement.Domain.Dtos
{
    public class UserDto : EntityDto
    {
        public UserDto()
        {
            Customers = Enumerable.Empty<NamedEntityDto>();
            ClientUsers = Enumerable.Empty<ClientUserDto>();
        }

        public virtual Guid Id { get; set; }
        [Required]
        [Display(Name = "Name is required")]
        public virtual string FirstName { get; set; }
        [Required]
        [Display(Name = "Surname is required")]
        public virtual string LastName { get; set; }
        public virtual string IdNumber { get; set; }
        [Required]
        [Display(Name = "Contact number is required")]
        public virtual string ContactNumber { get; set; }
        [Required]
        [Display(Name = "Username is required")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password is required")]
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public Guid UserTypeId { get; set; }
        public string UserTypeValue { get; set; }
        public IEnumerable<Guid> RoleIds { get; set; }
        public IEnumerable<string> RoleValues { get; set; }
        public IEnumerable<Guid> CustomerIds { get; set; }
        public IEnumerable<NamedEntityDto> Customers { get; set; }
        public IEnumerable<ClientUserDto> ClientUsers { get; set; }
    }
}